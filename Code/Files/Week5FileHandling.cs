using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Code.Files
{
	class Week5FileHandling
	{
		private static readonly RNGCryptoServiceProvider RngCsp = new RNGCryptoServiceProvider();

		public static int Mod(int x, int m)
		{
			return (x % m + m) % m;
		}

		public static void WriteSentences(string filename)
		{
			var myDocuments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				$"{filename}.txt");
			if (File.Exists(myDocuments))
			{
				var fileStr = File.AppendText(myDocuments);
				while (true)
				{
					Console.WriteLine("Enter sentence");
					var userInput = Console.ReadLine();
					if (userInput == "")
					{
						fileStr.Close();
						break;
					}

					fileStr.WriteLine(userInput);
				}

				fileStr.Close();
			}
			//It's unnecessary for this bit to exist, but for some reason I can't access the streamwriter outside of the if block which is really weird.
			else
			{
				var fileStr = File.CreateText(myDocuments);
				while (true)
				{
					Console.WriteLine("Enter sentence");
					var userInput = Console.ReadLine();
					if (userInput == "")
					{
						fileStr.Close();
						break;
					}

					fileStr.WriteLine(userInput);
				}

				fileStr.Close();
			}
		}

		public static void GenerateRandom(int limit, int numbers, string filename)
		{
			var randomNumbers = new byte[numbers];
			RngCsp.GetBytes(randomNumbers);
			//This is probably unncessary but I'm making sure it's as random as possible :)
			for (var i = 0; i < randomNumbers.Length; i++)
				randomNumbers[i] = (byte) Mod(randomNumbers[i], limit);
			//Mod of the limit will ensure that the cryptographically secure random integers are then truncated to the limit.

			var myDocuments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				$"{filename}.txt");
			var fileStr = File.AppendText(myDocuments);
			foreach (int i in randomNumbers) fileStr.WriteLine(i);

			fileStr.Close();
		}

		public static IEnumerable<int> ShellSort(List<int> inputList)
		{
			var n = inputList.Count;
			var counter = 0;
			for (var interval = n / 2; interval > 0; interval /= 2)
			for (var i = interval; i < n; i++)
			{
				var workInt = inputList[i];
				for (counter = i;
					counter >= interval && inputList[counter - interval] > workInt;
					counter -= interval)
					inputList[counter] = inputList[counter - interval];

				inputList[counter] = workInt;
			}

			return inputList;
		}

		public static void FileSorter(string filename)
		{
			var myDocuments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				$"{filename}.txt");
			var readLines = File.ReadLines(myDocuments);
			var sortingIntegers = readLines.Select(line => Convert.ToInt32(line)).ToList();
			var sortedIntegers = ShellSort(sortingIntegers);
			var fileStr = File.AppendText(myDocuments);
			foreach (var i in sortedIntegers) fileStr.WriteLine(i);

			fileStr.Close();
		}

		public static List<string> TubeChecker(string checkWord)
		{
			var myDocuments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				"stations.txt");
			var readLines = File.ReadAllLines(myDocuments);
			var stations = new List<string>();
			var invalid = false;
			foreach (var line in readLines)
			{
				var stationName = line.Split(',').Take(1).ToString();
				if (checkWord.Any(letter => stationName != null && stationName.Contains(letter))) invalid = true;

				if (invalid == false) stations.Add(stationName);
			}

			return stations;
		}

		public static List<string> SameLetters()
		{
			var myDocuments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				"stations.txt");
			var readLines = File.ReadAllLines(myDocuments);

			return readLines.Select(line => line.Split(',').Take(1).ToString()).Where(stationName =>
				stationName != null && stationName.Split(' ')[0][0] == stationName.Split(' ')[1][0]).ToList();
		}

		public static List<string> DisplayTextFile(string filename)
		{
			var myDocuments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				$"{filename}.txt");
			var readLines = File.ReadAllLines(myDocuments);
			var words = new List<string>();
			foreach (var line in readLines)
			{
				Console.WriteLine(line);
				foreach (var word in line.Split(' ')) words.Add(word.ToLower());
			}

			words.Sort();
			/*
			//This will spit everything out, but I'm also using this function to make my distribution algorithm a lot cleaner.
			foreach(string word in words){
			    Console.WriteLine(word);
			}
			*/
			return words;
		}

//+96
		public static Dictionary<string, int> DistributionList(string filename)
		{
			List<string> allWords = DisplayTextFile(filename);
			var frequency = new Dictionary<string, int>();
			for (var i = 0; i < allWords.Count - 1; i++)
			{
				if (allWords[i] != allWords[i + 1]) continue;
				if (frequency.ContainsKey(allWords[i]))
					frequency[allWords[i]] += 1;
				else
					frequency.Add(allWords[i], 1);
			}

			return frequency;
		}

		static void FileInvert(string option, string filename)
		{
			var myDocuments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				$"{filename}.txt");
			var readlines = File.ReadAllLines(myDocuments);
			var reversedLines = readlines.Reverse();
			var fileWrite = File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				$"{filename}-inverted.txt"));
			foreach(var reverseLine in reversedLines) fileWrite.WriteLine(reverseLine);
			//I am interpreting this as reversing every word per line after reversing the lines themselves.  
			foreach(var newLine in reversedLines) fileWrite.WriteLine(String.Join("", newLine.Split(' ').Reverse()));
			//Interpreting this same as above except reversing every single character.
			foreach(var newLine in reversedLines) fileWrite.WriteLine(String.Join("", newLine.ToCharArray().Reverse()));
		}
	}
}
