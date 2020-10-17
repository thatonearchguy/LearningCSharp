using System;

namespace Code.TheBasics
{
   public class Week2Selection{     
        public static bool IsEqual(int x, int y){
            //Self explanatory. if x is equal to y it'll return true
            if (x == y) return true;
            else return false;
        }
        public static bool IsEven(int x){
            //If x is divisible by 2, it's even so it returns true.
            if (x % 2 == 0) return true;
            else return false;
        }
        public static bool IsLeapYear(int x){
            //Same thing except when divisible by 4 as leap years are divisible by 4
            if (x % 4 ==  0) return true;
            else return false;
        }
        public static int GreatestThree(int x, int y, int z){
            //There are several cases that could lead to x or y or z being the greatest, so I had to take all of these into account. 
            if (x > y && x > z) return x;
            else if (y > x && y > z) return y;
            else return z;
        }
        public static int QuadrantCircle(double xCoordinate, double yCoordinate, double radius, double xCord2, double yCord2, int option){
            //Again, like my CLI UI implementation of this function, the actual "brains" of this function are probably really not that elegant at all. 
            if (option == 1){
                if (xCoordinate > 0 && yCoordinate > 0) return 1;
                else if (xCoordinate < 0 && yCoordinate > 0) return 2;
                else if (xCoordinate < 0 && yCoordinate < 0) return 3;
                else if (xCoordinate > 0 && yCoordinate < 0) return 4;
            }
            else if (option == 2){
                if ((Math.Pow(xCoordinate, 2) + Math.Pow(yCoordinate, 2)) >= Math.Pow(radius, 2)) return 1;
            }
            else if (option == 3){
                if ((Math.Pow((xCoordinate - xCord2), 2) + Math.Pow((yCoordinate - yCord2), 2)) >= Math.Pow(radius, 2)) return 1;
            }
            return 0;
        }
        public static string StudentGrade (double QuizScore, double BlockTest, double FinalScore){
            //Classic if else if brackets with && operators to include multiple cases and save code space. 
            double averageScore = (QuizScore+BlockTest+FinalScore)/3;
            if (averageScore >= 90) return "A*";
            else if (averageScore >= 80 && averageScore < 90) return "A";
            else if (averageScore >= 70 && averageScore < 80) return "B";
            else if (averageScore >= 50 && averageScore < 70) return "C";
            else if (averageScore < 50) return "F";
            else return "Error";
        }
        public static string Triangle (double x, double y, double z){
            //Using the triangle inequality rule - if two sides don't add up to be greater than the third, the triangle is impossible.
            //If the sides are all the same length, then it's an equilateral, and if two sides are the same but one side is not, then it's isosceles. 
            if (x == y && y == z) return "Equilateral";
            else if (x == y 
            && y != z || x == z 
            && z != y || y == z 
            && z != x) return "Isosceles";
            else if (x + y > z) return "Scalene";
            else return "Impossible";
        }
    }
}