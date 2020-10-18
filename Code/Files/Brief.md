# Exercises - File Handling

1) Create a function to ask the user for several sentences (until they just press Enter with an empty string)
    1) store them in a text file named "sentences.txt" 
    2) Extend this to take in the file name as a parameter to the function 
    3) Check if the file already exists, if it does, return a suitable message 
    4) if the file exists, the new content should be appended to its end, otherwise create a new one. 
2) Building on last week’s list sorting work, create a function to generate a given number of random integers (between 1 and a given limit), writing them to a file, one per line. (Calling it something like unsorted.txt)  
    1) Write a second function to read in the integers, sort them, then rewrite them to a second file (e.g. sorted.txt). 

Using the file `‘stations.txt’`:

3) Which tube stations share no letters with the following words: 
   1)  Mackerel
   2)  Piranha
   3)  Sturgeon
   4)  Bacteria

4) Which tube stations are formed of two words, each beginning with the same letter? 

For these questions, use the text file `‘thirty-nine-steps.txt’` for testing your functions. 

5) Create a function to display all the contents of a text file on screen. The name of the file will be a parameter to the function 
    1) Extend to output the words in alphabetical order - stripping out all punctuation and converting to lower-case

6) Create a function that will take a text file’s name as a parameter and return a `dictionary<string, int>` showing the frequency of words in the file.  

7) Write a function that inverts a text file, e.g. `filename.txt` and writes to a file called `filename-inverted.txt`
    1) Invert line by line 
    2) Invert word by word 
    3) Invert character by character 

