using System;

namespace Code.TheBasics
{
    public class Week1Introductory
    {
        private static void Main(string[] args)
        {
            bool validInput = false;
            char userCont = 'Y';
            while (userCont == 'Y') {
                Console.WriteLine("Choose a program:\n1) Speed Calculator\n2) Multiplication Tables\n3) Circle Helper\n");
                int ProgramString = 0;
                while (validInput == false) {
                    try {              
                        //Attempts integer conversion to check if a number has been inputted. It will fail if it's a letter prompting user to input choice again.  
                        ProgramString = Convert.ToInt32(Console.ReadLine());
                        //Checks integer is within range (1-3), fails if not within range prompting for reinput.
                        //I raise a FormatException so only one catch block is required to mitigate the error. 
                        if (ProgramString < 1 || ProgramString > 3) {
                            throw new FormatException();
                        }
                        else {
                            validInput = true;
                            break;
                        }
                    }
                    //Catching errors from range or integer conversion and displaying error message.
                    catch (FormatException) {
                        Console.WriteLine("Invalid Input. Please enter a number from 1-3 to select the program.\n");
                    }              
                }
                //Selecting Race program - Syntax is identical to C++ for if else if else loops!
                if (ProgramString == 1) {
                    try {
                        //Taking inputs for distance and time ran - with error handling and optional distance metric incorporated. 
                        Console.WriteLine("Enter the distance ran in km (Default = 10): ");
                        double userDistance = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the time in whole minutes: ");
                        int userMinutes = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the seconds remainder: ");
                        int userSeconds = Convert.ToInt32(Console.ReadLine());  
                        //Main function call with values. 
                        Race(userMinutes, userSeconds, userDistance);                 

                    }
                    catch (FormatException) {
                        //Format exception is Python's ValueError equivalent - I can throw this error for any other reason I choose and retry input, saving code space and execution cycles. Nice.
                        Console.WriteLine("Invalid input. Please try again\n");
                    }
                }
                else if (ProgramString == 2) {
                    try {
                        //Getting inputs for the times table program and converting to int32 to check if it's a number as well as actually turning it into a number for the function. Handy!
                        Console.WriteLine("Enter the times table you want to see: ");
                        int userMultiplier = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("How far do you want to go: ");
                        int userDistance = Convert.ToInt32(Console.ReadLine());
                        //Main function call here
                        MultTable(userMultiplier, userDistance);
                    }
                    catch (FormatException) {
                        Console.WriteLine("Invalid Input. Please try again\n");
                    }
                }
                else if (ProgramString == 3) {
                    try {
                        //Inputs for circle calculator
                        Console.WriteLine("Enter the area, circumference or radius to calculate values from: ");
                        int userCircleInput = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the letter (a, c, r) for the value you entered: ");
                        char userCircleOption = Convert.ToChar(Console.ReadLine());
                        //Checking if the characters inputted are valid or not, and if valid I call the function. 
                        if (userCircleOption == 'a' || userCircleOption == 'c' || userCircleOption == 'r'){
                            CircleCalc(userCircleInput, userCircleOption);
                        }
                        else {
                            //Same thing as above, raising FormatException so the one catch block can handle both errors. 
                            throw new FormatException();
                        }
                    }
                    catch (FormatException) {
                        Console.WriteLine("Invalid Input. Please try again\n");
                    }
                }
                validInput = false;
                Console.WriteLine("Continue? Y/N: ");
                userCont = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
            }
        }
        public static void Race(int minutes, int seconds, double distance = 10.0)
		{
            /// <summary>
            /// Function to calculate the speed of a run. Takes three arguments - int minutes, int seconds, int distance
            /// </summary>
            double distanceMetres = distance * 1000;
            double distanceMiles = (double)distance / 1.609;
            int timeSeconds = (minutes * 60) + seconds;
            double timeHours = (double)timeSeconds / 3600;
            Console.WriteLine ($"Speed is {Math.Round((distanceMetres/timeSeconds), 3)}m/s\n");
            Console.WriteLine ($"Speed is {Math.Round((distanceMiles/timeHours), 3)}mph");
        }
        public static void MultTable(int multiplier, int rows)
        {
            for (int i = 1; i <= rows; i ++)
            {
                Console.CursorLeft = Console.BufferWidth - ($"{i} x {multiplier} = {i*multiplier}".Length);
                Console.WriteLine($"{i} x {multiplier} = {i*multiplier}");
            }

        }
        public static void CircleCalc(int circleInput, char circleOption)
        {
            if (circleOption == 'a')
            {
                double circleRadius = Math.Round(Math.Sqrt((circleInput/Math.PI)), 3);
                double circleCircum = 2*Math.PI*circleRadius;
                Console.WriteLine($"Radius is {Math.Round(circleRadius, 3)}, Circumference is {Math.Round(circleCircum)}");
            }
            else if (circleOption == 'r')
            {
                double circleArea = Math.PI*Math.Pow(circleInput, 2);
                double circleCircum = 2*Math.PI*circleInput;
                Console.WriteLine($"Area is {Math.Round(circleArea, 3)}, Circumference is {Math.Round(circleCircum, 3)}");
            }
            else if (circleOption == 'c')
            {
                double circleRadius = (circleInput/(2*Math.PI));
                double circleArea = Math.PI*Math.Pow(circleRadius, 2);
                Console.WriteLine($"Radius is {Math.Round(circleRadius, 3)}, Area is {Math.Round(circleArea, 3)}");
            }
        }
    }
}
