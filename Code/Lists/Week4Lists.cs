using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Code.Lists
{
    class Week4Lists
    {
        static void Main(string[] args)
        {
            //Will be able to use these two lists for both duplicates() and issubset() functions
            List<int> duplicateTest = new List<int> {0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 7, 8};
            List<int> duplicateAnswer = new List<int> {1, 2, 3, 4, 5};
            List<int> reverseAnswer = new List<int> {5, 4, 3, 2, 1};
            List<int> shellTest = new List<int> {3, 2, 5, 6, 88, 7, 55, 44, 33, 22, 6, 2, 39};
            List<int> shellAnswer = new List<int> {2, 2, 3, 5, 6, 6, 7, 22, 33, 39, 44, 55, 88};
            Debug.Assert(Duplicates(duplicateTest).SequenceEqual(duplicateAnswer) == true);
            Debug.Assert(IsSubset(duplicateTest, duplicateAnswer) == true);
            Debug.Assert(InPlaceReverse(duplicateAnswer).SequenceEqual(reverseAnswer) == true);
            Debug.Assert(ShellSort(shellTest).SequenceEqual(shellAnswer) == true);
			Debug.Assert(BinarySearch(duplicateTest, 1) == true);
			Debug.Assert(BinarySearch(duplicateTest, 89) == false);

        }
		static int Sum(List<int> inputList)
		{
			var total = 0;
			foreach(int number in inputList) total += number;
			return total;
		}
		static int Max(List<int> inputList)
		{
			var max = 1;
			foreach(int number in inputList) if (number > max){ max = number;}
			return max;
		}
		static int Min(List<int> inputList)
		{
			var min = 10;
			foreach(int number in inputList) if (number < min){ min = number;}
			return min;
		}
		static bool BinarySearch(List<int> inputList, int item)
		{
			var index = inputList.Count/2;
		   	bool done = false;
			while (done == false)
			{
				if (index < 0 || index > inputList.Count) break;
				else if (item > inputList[index]) index += index/2;
				else if (item < inputList[index]) index -= index/2;
				else if (item == inputList[index]) return true;
			}
			return false;
		}
        static List<int> Duplicates(List<int> inputList){
            inputList.Sort();
            List<int> duplicateints = new List<int>();
            for (int i = 0; i < inputList.Count-1; i ++){
                if (inputList[i] == inputList[i+1]){
                    if (duplicateints.Contains(inputList[i]) == false){
                        duplicateints.Add(inputList[i]);
                    }
                }
            }
            return duplicateints;
        }
        static bool IsSubset(List<int> firstList, List<int> secondList){
            bool notsubset = false;
            if (firstList.Count < secondList.Count){
                foreach (int i in firstList){
                    if (secondList.Contains(i) == false) notsubset = true;
                }
                if (notsubset == false) return true;
                else return false;
            }
            else{
                foreach (int i in secondList){ 
                    if (firstList.Contains(i) == false) notsubset = true;
                }
                if (notsubset == false) return true;
                else return false;
            }
        }

        static List<int> InPlaceReverse(List<int> inputList){
            int temp = 0;
            for(int i = 0; i < inputList.Count/2; i ++){
                temp = inputList[i];
                inputList[i] = inputList[inputList.Count-(i+1)];
                inputList[inputList.Count-(i+1)] = temp;
            }
            return inputList;
        }

        static List<int> ShellSort(List<int> inputList){
            int n = inputList.Count;
            int workInt = 0;
            int counter = 0;
            for (int interval = n/2; interval > 0; interval /= 2){
                for(int i = interval; i < n; i++){
                    workInt = inputList[i];
                    for (counter = i; counter >= interval && inputList[counter-interval] > workInt; counter -= interval){
                        inputList[counter] = inputList[counter - interval];
                    }
                    inputList[counter] = workInt;                      
                }
            }
            return inputList;
        }
    }
}