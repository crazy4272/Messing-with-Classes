using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messing_with_Classes_and_Memory
{
    public partial class Form1 : Form
    {
        //Global Variables
        time openingTime, closingTime, currentTime;
        int orderNumber;
        double simSpeed = 1.0;
        Boolean openCloseParsed, neverClose, notAcceptingOrders;
        menuItem[] menu = new menuItem[10];
        List<order> currentOrders = new List<order>();
        
        public Form1()
        {
            InitializeComponent();
            //Set the initial value of the combo box as I can't find the right thing in the properties menu
            simSpeedComboBox.SelectedItem = "1.0";

            orderNumber = 0;

            

            //Be sure that the program doesn't initially assume opening and closing time have already been parsed successfully
            openCloseParsed = false;
            notAcceptingOrders = false;
            //Create our menu
            menuItem fries = new menuItem("Fries", 3.50, 3);
            menuItem burger = new menuItem("Burger", 5.50, 5);
            menuItem drink = new menuItem("Drink", 2.80, 1);
            menuItem pizza = new menuItem("Pizza", 8.30, 7);
            menuItem garlicBread = new menuItem("Garlic bread", 3.20, 2);
            menuItem iceCream = new menuItem("Ice cream", 4.10, 1);
            menuItem curry = new menuItem("Curry", 5.20, 6);
            menuItem salad = new menuItem("Salad", 5.40, 3);
            menuItem buffet = new menuItem("Buffet", 15.00, 11);
            menuItem friedFish = new menuItem("Fried fish", 3.90, 3);

            //There's probably a much better way to do this haha
            menu[0] = fries;
            menu[1] = burger;
            menu[2] = drink;
            menu[3] = pizza;
            menu[4] = garlicBread;
            menu[5] = iceCream;
            menu[6] = curry;
            menu[7] = salad;
            menu[8] = buffet;
            menu[9] = friedFish;

            //Print it off so we know we got it right...
            //for(int i = 0; i < menu.Length; i++)
            //{
            //    currentOrdersTextBox.Text += menu[i].print() + "\r\n";
            //}

            //Set currentTime to a value so we know if we have neveer started the simulation
            currentTime = new time(-1, -1);
        }

        private void OpeningTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            openCloseParsed = false;
        }

        private void closingTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            openCloseParsed = false;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            openCloseParsed = false;
            //Also reset the currenttime so we can start again if we want
            currentTime.setHour(-1);
        }

        private void simSpeedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void simSpeedComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //currentOrdersTextBox.Text += "Selection changed to: ";
            string simSpeedString = simSpeedComboBox.Text;
            //currentOrdersTextBox.Text += simSpeedString + "\r\n";
            simSpeed = Convert.ToDouble(simSpeedString);
        }

        private void startPauseButton_Click(object sender, EventArgs e)
        {
            //currentOrdersTextBox.Text += "button\r\n";
            //As this will be start and pause button the input may not necessarily change so no need to jump through hoops to process it again
            if (!openCloseParsed)
            {
                //currentOrdersTextBox.Text += "starting checks\r\n";
                //Gather the inputs
                string openTime = OpeningTimeTextBox.Text;
                string closeTime = closingTimeTextBox.Text;
                //currentOrdersTextBox.Text += "gathered string inputs\r\n";

                //Check inputs and see if they can be converted into our basic time class
                string[] opening = openTime.Split(':');
                string[] closing = closeTime.Split(':');
                //currentOrdersTextBox.Text += "split them\r\n";

                //First check that the split has created two strings that we can then check further
                if (opening.Length == 2 && closing.Length == 2)
                {
                    //currentOrdersTextBox.Text += "split successful\r\n";
                    //Now check that we can actually convert the two strings we have into integers
                    int openHour, openMin, closeHour, closeMin;
                    //Doing the checks now to save the results not only because it makes telling the user exactly what went wrong a lot easier but is also tidier
                    Boolean openHCheck = int.TryParse(opening[0], out openHour);
                    Boolean openMCheck = int.TryParse(opening[1], out openMin);
                    Boolean closeHCheck = int.TryParse(closing[0], out closeHour);
                    Boolean closeMCheck = int.TryParse(closing[1], out closeMin);

                    //Check them all
                    if (openHCheck && openMCheck && closeHCheck && closeMCheck)
                    {
                        //All of them succeeded now just need to be sure that they fit into the usual constraints of hours and minutes
                        //*IF they don't we know they are still integers so we shall continue just shift them logically using mod to get them to a correct time
                        //* and inform the user
                        //currentOrdersTextBox.Text += "allParseFine\r\n";

                        Boolean inputChange = false;

                        //Set up start of message to user if a value is changed
                        String userMessage = "The following values were changed to there modular equivalents as they were outside the constraints of 24 Hour Time\r\n";
                        if (!(openHour >= 0 && openHour < 24) || !(openMin >= 0 && openMin < 60))
                        {
                            //currentOrdersTextBox.Text += "openValueChange\r\n";
                            //So at least one of the opening time values need to change
                            userMessage += "Opening time has been edited from " + openHour.ToString() + ":" + openMin.ToString() + " to ";
                            //Change them to their modular equivalents
                            openHour = openHour % 24;
                            openMin = openMin % 60;

                            userMessage += openHour + ":" + openMin + "\r\n";
                            inputChange = true;
                        }

                        if (!(closeHour >= 0 && closeHour < 24) || !(closeMin >= 0 && closeMin < 60))
                        {
                            //currentOrdersTextBox.Text += "closeValueChange\r\n";
                            //At least one of the closing values need to change
                            userMessage += "Closing time has been edited from " + closeHour.ToString() + ":" + closeMin.ToString() + " to ";
                            //Change them to their modular equivalents
                            closeHour = closeHour % 24;
                            closeMin = closeMin % 60;

                            userMessage += closeHour + ":" + closeMin + "\r\n";
                            inputChange = true;
                        }

                        //Send off the message if anything did change
                        if (inputChange)
                        {
                            String messageTitle = "Input Change";
                            MessageBox.Show(userMessage, messageTitle);
                        }

                        //I know I am putting too much detail into this one aspect of the application at this point but last check I swear
                        //If the open and closing time are the same then that means we never close and just keep going
                        if (openHour == closeHour && openMin == closeMin)
                        {
                            neverClose = true;
                        }

                        //Set our global variable and time etc
                        openingTime = new time(openHour, openMin);
                        closingTime = new time(closeHour, closeMin);
                        openCloseParsed = true;

                        OpeningTimeTextBox.Text = openingTime.printTime();
                        closingTimeTextBox.Text = closingTime.printTime();
                    }
                    else
                    {
                        //Something didn't parse successfully.... time for a slightly arrogant error message muhahaha!
                        String errorMessage = "The ";
                        if (!openHCheck || !openMCheck)
                        {
                            //At the very least the opening input failed
                            errorMessage += "opening time ";
                            //Now check the closing time input to see if it failed as well
                            if (!closeHCheck || !closeMCheck)
                            {
                                //Now we know both time inputs failed to parse correctly
                                errorMessage += " and closing time inputs could not be parsed.\r\nPlease ensure they are in the format: HOUR:MINUTE";
                            }
                        }
                        else
                        {
                            //This means only the closing time input failed so finish the error message and continue on
                            errorMessage += "closing time input could not be parsed.\r\nPlease ensue it is in the format: HOUR:MINUTE";
                        }
                        String errorTitle = "Input Format";
                        MessageBox.Show(errorMessage, errorTitle);
                    }
                }
                else
                {
                    //Can't explain it but am suddenly emjoying making informative error messages
                    String errorMessage = "Please ensure your Opening Time and Closing Time inputs \r\nare seperated by a single ':'";
                    String errorTitle = "Input Format";
                    MessageBox.Show(errorMessage, errorTitle);
                }
            }

            //currentOrdersTextBox.Text += "Checked time inputs \r\n";

            ////Get timing for sleep thing down to a nice thing and have it
            //for (int i = 0; i < 10; i++)
            //{
            //    currentOrdersTextBox.Text += "simSpeed = " + simSpeed.ToString();
            //    currentOrdersTextBox.Refresh();
            //    double sleepTime = 1000 / simSpeed;
            //    int minuteTime = (int) Math.Round(sleepTime);
            //    System.Threading.Thread.Sleep(minuteTime);
            //}




            //Set the current time **NEED to check if this restarting after a pause
            if(currentTime.getHour() == -1)
            {
                //This means that is a fresh start and so 
                currentTime = new time(openingTime.getHour(), openingTime.getMinute());
            }
            

            //Ok now to start randomly creating orders.... i've made this much more complex than it needed to be haha
            //if(neverClose)
            if(false)
            {
                //We never need to stop.... oh my
                //currentOrdersTextBox.Text += "I WILL NEVER SURRENDER";

            }
            else
            {
                // currentOrdersTextBox.Text += "closing time equivalent: " + closingTime.getIntEquivalent().ToString() + "\r\n";
                //The loop that makes every minute go by
                for (int i = currentTime.getIntEquivalent(); (i != closingTime.getIntEquivalent() && !notAcceptingOrders) || currentOrders.Count != 0 ;i++)
                {
                    //Display the currentTime to the usr
                    currentTimeTextBox.Text = currentTime.printTime();
                    currentTimeTextBox.Refresh();
                    //If we're no longer accepting orders we can skip all this stuff that creates orders
                    if (!notAcceptingOrders)
                    {
                        
                        //currentOrdersTextBox.Text += "-- Still Creating --";
                        //Decide how many orders are coming in at this minute NOTE- not really realistic..... SURPRISE!
                        Random numberGenerator = new Random();
                        //I think zero to three orders could be fine for a reasonably busy place wouldn't be this consistent but oh well haha
                        int numOrders = numberGenerator.Next(0, 4);
                        //This is 0 to 3 because for some reason the first value is inclusive and the second is not... not sure why it's done that way haha
                        int orderAmount = 0;
                        int menuSelect;
                        double totalCost = 0.0;

                        //Just creating these variables here so I can print them without issue as the next two for loops are not code guaranteed to run

                        //Now we have our number of orders we need to actually generate them and do necessary calculations to complete them
                        for (int j = 0; j < numOrders; j++)
                        {
                            //the number of things for that order - 1 to 4 is just out of the air
                            orderAmount = numberGenerator.Next(1, 5);

                            //New order so reset things we calculated for the last one
                            totalCost = 0.0;
                            int longestItemTime = 0;

                            List<string> orderContents = new List<string> { };

                            for (int k = 0; k < orderAmount; k++)
                            {
                                menuSelect = numberGenerator.Next(0, 10);
                                totalCost += menu[menuSelect].getCost();
                                //Calculate the time will be longest item in order + 1 minute for everything else in the order
                                //A vague attempt to show that things can be done at the same time but more items still adds more time
                                if (menu[menuSelect].getTimeToMake() > longestItemTime)
                                {
                                    longestItemTime = menu[menuSelect].getTimeToMake();
                                }
                                //Collect the string of what the order will contain
                                orderContents.Add(menu[menuSelect].getName());
                            }
                            //Final bit of time calculation
                            longestItemTime += orderAmount - 1;

                            orderNumber++;
                            time orderTime = new time(currentTime.getHour(), currentTime.getMinute());
                            time orderTimeComplete = currentTime.addMinutes(longestItemTime, currentTime);
                            //Create the order with the info we've gathered
                            order addition = new order(orderTime, orderTimeComplete, totalCost, longestItemTime, orderNumber, orderContents);
                            //Print off because chances are something's gone wrong haha
                            currentOrdersTextBox.Text += addition.print() + "\r\n";

                            //Add the order to the current list of orders and that's the end of the creation side of this stuff.... WOW this is now a mess haha
                            currentOrders.Add(addition);
                        }
                    }





                    //ACTUAL SIMULATION BIT
                    //Ok check if any of the current orders are finished if they are move them to print in the completed text box
                    for (int j = 0; j < currentOrders.Count; j++)
                    {
                        if ((currentOrders[j].getFinishTime().getIntEquivalent()) == currentTime.getIntEquivalent())
                        {
                            //The order is finished so print, then remove from the list
                            CompletedOrdersTextBox.Text += currentOrders[j].print() + "\r\n";

                            currentOrders.RemoveAt(j);

                            //Current text box also needs updating ** BETTER WAY OF DOING THIS, will do for now but could be much better
                            currentOrdersTextBox.Clear();
                            if (currentOrders.Count > 0)
                            {
                                for (int k = 0; k < currentOrders.Count; k++)
                                {
                                    currentOrdersTextBox.Text += currentOrders[k].print() + "\r\n";
                                }

                            }
                            //Because we've just removed an entry we must now also reduce our index counter to make sure we don't skip an entry
                            j--;

                            //Must refresh the textbox aswell otherwise it doesn't update until the enitire loop is finished which may be a while
                            CompletedOrdersTextBox.Refresh();

                            

                        }
                    }


                    //Check this works as intended
                    //currentOrdersTextBox.Text += "i= " + i.ToString() + "\tCT= " + currentTime.printTime() + "\tNO= " + numOrders.ToString() + " "
                        //+ orderAmount.ToString() + " " + totalCost.ToString() + "\r\n";

                    //To create the cyclic nature for our little integer
                    if (i % 100 == 60)
                    {
                        //This is to fix the 100 to 60 minute thing
                        i += 40;
                        //If because of this we're at 2400 then the day is done and we go back to zero
                        if (i == 2400)
                        {
                            i = 0;
                        }
                    }

                    //Same for the time variable
                    currentTime.tick();
                    //Sleep for a bit so it doesn't just zoom past and the random generator seems to give repeats if the program runs too fast
                    double sleepTime = 1000 / simSpeed;
                    int minuteTime = (int)Math.Round(sleepTime);
                    System.Threading.Thread.Sleep(minuteTime);
                    currentOrdersTextBox.Refresh();

                    //CompletedOrdersTextBox.Text += "Checking "  + i.ToString() +  " and " + closingTime.getIntEquivalent().ToString() + "\r\n";

                    //Clock just ticked if we are now closed we need need to stop accepting orders
                    if (i == closingTime.getIntEquivalent())
                    {
                        notAcceptingOrders = true;
                        //currentOrdersTextBox.Text += "\r\nNO MORE ORDERS\r\nNumber of Orders processed" + orderNumber.ToString();
                    }

                    if(notAcceptingOrders && currentOrders.Count < 1)
                    {
                        break;
                    }
                    
                    
                }
                //currentOrdersTextBox.Text += "\r\n Made OutSide Simulation Loop";
            }
            
        }

        class order
        {
            //When it's been recieved, when it finished, time to complete the order, the stuff in the order, cost, current status
            //I've made this far more complex than I needed to didn't I?..... oh well
            time timeRecieved, timeCompleted;
            int minutesToMake, orderNumber;
            List<string> contents;
            double cost;

            //Constructor
            public order(time t, time tf, double c, int m, int n, List<string> i)
            {
                this.timeRecieved = t;
                this.timeCompleted = tf;
                this.cost = c;
                this.minutesToMake = m;
                this.orderNumber = n;
                this.contents = i;
            }


            public time getFinishTime()
            {
                return timeCompleted;
            }
            public string print()
            {
                if(timeCompleted == null)
                {
                    //Going to print out the whole order as best we can to look tidy
                    string returnString = orderNumber.ToString() + "\t" + timeRecieved.printTime() + "\t$" +
                        cost.ToString() + "0\r\n";
                    for (int i = 0; i < contents.Count; i++)
                    {
                        returnString += contents[i] + " ";
                    }

                    return returnString;
                }
                else
                {
                    //Going to print out the whole order as best we can to look tidy
                    string returnString = "*Order I.D - " + orderNumber.ToString() + "\tStart - " + timeRecieved.printTime() + "\tFinish - " + 
                        timeCompleted.printTime() + "\tPrice - $" + cost.ToString() + "0\r\n" + "Order: ";
                    for (int i = 0; i < contents.Count; i++)
                    {
                        returnString += contents[i];
                        if(i + 1 < contents.Count)
                        {
                            returnString += ", ";
                        }
                    }

                    return returnString;
                }
                
                
            }
        }

        class menuItem
        {
            string name;
            double cost;
            int timeToMake;

            //Constructor
            public menuItem(string n, double c, int t)
            {
                this.name = n;
                this.cost = c;
                this.timeToMake = t;
            }

            public string print()
            {
                return name + "\t $" + cost.ToString() + "\t " + timeToMake.ToString() + " minutes";
            }

            public string getName()
            {
                return name;
            }

            public double getCost()
            {
                return cost;
            }

            public int getTimeToMake()
            {
                return timeToMake;
            }
        }


        class time
        {
            //What it holds
            int hour;
            int minute;

            //Constructor
            public time(int h, int m)
            {
                this.hour = h;
                this.minute = m;
            }

            public int getHour()
            {
                return hour;
            }

            public int getMinute()
            {
                return minute;
            }

            public void setHour(int h)
            {
                this.hour = h;
            }

            public void setMinute(int m)
            {
                this.minute = m;
            } 

            public int getIntEquivalent()
            {
                return hour * 100 + minute;
            }

            public void tick()
            {
                minute++;
                //Check if we've hit an hour
                if(minute == 60)
                {
                    minute = 0;
                    //and advance an hour
                    hour++;
                    //also need to check if we've hit the end of the day
                    if(hour == 24)
                    {
                        hour = 0;
                    }
                }
            }

            public time addMinutes(int m, time t) //** if minutes is ever over 61 minutes or over it could fail at this point that's impossible but still
            {
                time returnTime = new time(0,0);
                int minutes = t.getMinute() + m;
                //Check if the minutes is at or above 60
                if(minutes >= 60)
                {
                    //Reduce it down to something below 60 with mod
                    minutes = minutes % 60;
                    //Check if adding an hour will take us over a day
                    if(!(t.getHour() + 1 >= 24))
                    {
                        //Because we already set it at zero we only need to hange something if not the special case
                        returnTime.setHour(t.getHour() + 1);
                    }

                    returnTime.setMinute(minutes);
                    return returnTime;

                }
                else
                {
                    returnTime.setHour(t.getHour());
                    returnTime.setMinute(minutes);
                    return returnTime;
                }

                
            }

            //Simple print method since we will be doing this a lot
            public string printTime()
            {
                if(this.hour < 10 || this.minute < 10)
                {
                    //To make it look more official just to manually put a zero in front to make it look like time
                    if(this.hour < 10)
                    {
                        if(this.minute < 10)
                        {
                            return "0" + (this.hour).ToString() + ":0" + (this.minute).ToString();
                        }
                        else
                        {
                            return "0" + (this.hour).ToString() + ":" + (this.minute).ToString();
                        }
                    }
                    else
                    {
                        return (this.hour).ToString() + ":0" + (this.minute).ToString();
                    }
                }
                return (this.hour).ToString() + ":" + (this.minute).ToString();
            }
        }
    }
}
