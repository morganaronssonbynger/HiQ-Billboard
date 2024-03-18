using System;
using System.Collections;

namespace Billboard.Models
{
    public class WeekOutputHandler
    {

        DAL d = new DAL();


        // Method that returns the current month as a string
        public string GetMonth()
        {
            DateTime dt = DateTime.Today;
            int monthNbr = dt.Month;
            string month = "";


            if(monthNbr == 1)
            {
                month = "Januari";
            }
            else if(monthNbr == 2)
            {
                month = "Februari";
            }
            else if (monthNbr == 3)
            {
                month = "Mars";
            }
            else if (monthNbr == 4)
            {
                month = "April";
            }
            else if (monthNbr == 5)
            {
                month = "Maj";

            }
            else if (monthNbr == 6)
            {
                month = "Juni";
            }
            else if (monthNbr == 7)
            {
                month = "Juli";
            }
            else if (monthNbr == 8)
            {
                month = "Augusti";

            }
            else if (monthNbr == 9)
            {
                month = "September";
            }
            else if (monthNbr == 10)
            {
                month = "Oktober";
            }
            else if (monthNbr == 11)
            {
                month = "November";
            }
            else if (monthNbr == 12)
            {
                month = "December";
            }

            return month;
        }

        //Method that returns an arraylist of todays birthdays
        public ArrayList GetTodaysBirthdays()
        {
            DateTime todaysDate = DateTime.Today.Date;
            var myTask = Task.Run(() => d.GetJson());
            NotificationModel.NotificationContainer result = myTask.Result;
            ArrayList birthdays = new ArrayList();

            foreach (var Notification in result.value)
            {
                if (Notification.birthday != null)
                {
                    string dayMonth = todaysDate.ToString().Substring(5, 5);
                    string empDayMonth = Notification.birthday.Substring(5, 5);


                    if (dayMonth.Equals(empDayMonth))
                    {

                        birthdays.Add(Notification.firstName + " " + Notification.lastName);
                    }

                }

            }
            return birthdays;
        }

        // Method that returns a three dimensional array with the names of employees that have events in the current week, it is sorted after both the day and what event it is
        public string[,][] GetThisWeeksActivities()
        {
            //Getting the method to know which dates to handle
            WeekCalculator wc = new WeekCalculator();
            ArrayList week = wc.GetThisWeeksDates();
            
            var myTask = Task.Run(() => d.GetJson());
            NotificationModel.NotificationContainer result = myTask.Result;

            //We create a three dimensional array with [5, 5] since there are five dates and 5 type of events
            string[,][] eventArray = new string[5, 5][];

            //We create an int array that has with the right number of indexes per date and per event
            int[] intArray = EmployeeCounter();

           
            // Here we do a forloop to create the right number of indexes in our three dimensional array

            int employee = 0;

            for (int date = 0; date < 5; date++)
            {
                for (int eventType = 0; eventType < 5; eventType++)
                {
                        string[] array = new string[intArray[employee]];
                        eventArray[date, eventType] = array;
                        employee++;
                    

                }
            }


            int day = 0;

            foreach (string date in week)
            {
                int assignmentStart = 0;
                int assignmentEnd = 0;
                int vacationStart = 0;
                int vacationEnd = 0;
                int birthday = 0;


                foreach (var emp in result.value)
                {

                    //We look for assignment start dates and end dates
                    foreach (var assignment in emp.assignments)
                    {

                        if (week[day].Equals(assignment.start))
                        {
                            eventArray[day, 0][assignmentStart] = emp.firstName + " " + emp.lastName;
                            assignmentStart++;
                        }
                        else if (week[day].Equals(assignment.end))
                        {

                            eventArray[day, 1][assignmentEnd] = emp.firstName + " " + emp.lastName;
                            assignmentEnd++;

                        }
                    }
                    //We look at vacation start dates and end dates
                    foreach (var vacation in emp.vacations)
                    {
                        if (week[day].Equals(vacation.start))
                        {

                            eventArray[day, 2][vacationStart] = emp.firstName + " " + emp.lastName;
                            vacationStart++;
                        }
                        else if (week[day].Equals(vacation.end))
                        {

                            eventArray[day, 3][vacationEnd] = emp.firstName + " " + emp.lastName;
                            vacationEnd++;
                        }
                    }

                    //We look after birthdays
                    if (emp.birthday != null)
                    {
                        string dayMonth = week[day].ToString().Substring(5, 5);
                        string empDayMonth = emp.birthday.Substring(5, 5);


                        if (dayMonth.Equals(empDayMonth))
                        {

                            eventArray[day, 4][birthday] = emp.firstName + " " + emp.lastName;
                            birthday++;
                        }
                    }

                }
                day++;
            }

            return eventArray;

        }

        //Method that returns todays and tommorows weather with matching icons
        public string[] GetWeather()
        {
            var myTask = Task.Run(() => d.GetWeather());
            string[] output = new string[6];
            string link = "https://openweathermap.org/img/wn/";
            string end = "@2x.png";
            UserModel.Root result = myTask.Result;
            //Importing Weather, temp and icon for today
            output[0] = result.current.weather[0].main;
            output[1] = Math.Round(result.current.temp, 0).ToString() + "°C";
            //Formatting the link to the icons, referrenced from here: https://openweathermap.org/weather-conditions#Weather-Condition-Codes-2
            output[2] = link+result.current.weather[0].icon+end;
            //Importing Weather, temp and icon for tomorrow
            output[3] = result.daily[0].weather[0].main;
            output[4] = Math.Round(result.daily[0].temp.day, 0).ToString() + "°C";
            //Formatting the link to the icons, referrenced from here: https://openweathermap.org/weather-conditions#Weather-Condition-Codes-2
            output[5] = link+result.daily[0].weather[0].icon+end;
            return output; 
        }


        //Method that counts how many employees there are for each event and date
        public int[] EmployeeCounter()
        {
            //Getting the method to know which dates to handle
            WeekCalculator wc = new WeekCalculator();
            ArrayList week = wc.GetThisWeeksDates();
            var myTask = Task.Run(() => d.GetJson());
            NotificationModel.NotificationContainer result = myTask.Result;
            int[] counter = new int[25];

           

            int day = 0;
            int assignmentStart1 = 0;
            int assignmentStart2 = 0;
            int assignmentStart3 = 0;
            int assignmentStart4 = 0;
            int assignmentStart5 = 0;
            int assignmentEnd1 = 0;
            int assignmentEnd2 = 0;
            int assignmentEnd3 = 0;
            int assignmentEnd4 = 0;
            int assignmentEnd5 = 0;
            int vacationStart1 = 0;
            int vacationStart2 = 0;
            int vacationStart3 = 0;
            int vacationStart4 = 0;
            int vacationStart5 = 0;
            int vacationEnd1 = 0;
            int vacationEnd2 = 0;
            int vacationEnd3 = 0;
            int vacationEnd4 = 0;
            int vacationEnd5 = 0;
            int birthday1 = 0;
            int birthday2 = 0;
            int birthday3 = 0;
            int birthday4 = 0;
            int birthday5 = 0;


            foreach(string date in week)
            {

                foreach (var Notification in result.value)
                {
                    foreach (var assignment in Notification.assignments)
                    {

                        if (week[day].Equals(assignment.start))
                        {
                            if(day == 0)
                            {
                                assignmentStart1++;
                            }
                            else if (day == 1)
                            {
                                assignmentStart2++;
                            }
                            else if (day == 2)
                            {
                                assignmentStart3++;
                            }
                            else if (day == 3)
                            {
                                assignmentStart4++;
                            }
                            else if (day == 4)
                            {
                                assignmentStart5++;
                            }

                        }
                        else if (week[day].Equals(assignment.end))
                        {
                            if (day == 0)
                            {
                                assignmentEnd1++;
                            }
                            else if (day == 1)
                            {
                                assignmentEnd2++;
                            }
                            else if (day == 2)
                            {
                                assignmentEnd3++;
                            }
                            else if (day == 3)
                            {
                                assignmentEnd4++;
                            }
                            else if (day == 4)
                            {
                                assignmentEnd5++;
                            }

                        }
                    }
                    
                    foreach (var vacation in Notification.vacations)
                    {
                        if (week[day].Equals(vacation.start))
                        {
                            if (day == 0)
                            {
                                vacationStart1++;
                            }
                            else if (day == 1)
                            {
                                vacationStart2++;
                            }
                            else if (day == 2)
                            {
                                vacationStart3++;
                            }
                            else if (day == 3)
                            {
                                vacationStart4++;
                            }
                            else if (day == 4)
                            {
                                vacationStart5++;
                            }



                        }
                        else if (week[day].Equals(vacation.end))
                        {

                            if (day == 0)
                            {
                                vacationEnd1++;
                            }
                            else if (day == 1)
                            {
                                vacationEnd2++;
                            }
                            else if (day == 2)
                            {
                                vacationEnd3++;
                            }
                            else if (day == 3)
                            {
                                vacationEnd4++;
                            }
                            else if (day == 4)
                            {
                                vacationEnd5++;
                            }


                        }
                    }

                    if (Notification.birthday != null)
                    {
                        string dayMonth = week[day].ToString().Substring(5, 5);
                        string empDayMonth = Notification.birthday.Substring(5, 5);


                        if (dayMonth.Equals(empDayMonth))
                        {

                            if (day == 0)
                            {
                                birthday1++;
                            }
                            else if (day == 1)
                            {
                                birthday2++;
                            }
                            else if (day == 2)
                            {
                                birthday3++;
                            }
                            else if (day == 3)
                            {
                                birthday4++;
                            }
                            else if (day == 4)
                            {
                                birthday5++;
                            }

                        }
                    }

                }
                day++;
            }
            counter[0] = assignmentStart1;
            counter[1] = assignmentEnd1;
            counter[2] = vacationStart1;
            counter[3] = vacationEnd1;
            counter[4] = birthday1;
            counter[5] = assignmentStart2;
            counter[6] = assignmentEnd2;
            counter[7] = vacationStart2;
            counter[8] = vacationEnd2;
            counter[9] = birthday2;
            counter[10] = assignmentStart3;
            counter[11] = assignmentEnd3;
            counter[12] = vacationStart3;
            counter[13] = vacationEnd3;
            counter[14] = birthday3;
            counter[15] = assignmentStart4;
            counter[16] = assignmentEnd4;
            counter[17] = vacationStart4;
            counter[18] = vacationEnd4;
            counter[19] = birthday4;
            counter[20] = assignmentStart5;
            counter[21] = assignmentEnd5;
            counter[22] = vacationStart5;
            counter[23] = vacationEnd5;
            counter[24] = birthday5;


            return counter;
        }



    }
}

