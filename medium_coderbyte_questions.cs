/*   Question#1
*            CODERBYTE BRACKET COMBINATIONS CHALLENGE          *
 *                                                              *
 * Problem Statement                                            *
 * Have the function BracketCombinations(num) read num which    *
 * will be an integer greater than or equal to zero, and return *
 * the number of valid combinations that can be formed with num *
 * pairs of parentheses.                                        *
 *                                                              *
 * For example, if input is 3, then the possible combinations   *
 * of 3 pairs of parenthesis,                                   *
 * namely: ()()(), are ()()(), ()(()), (())(), ((())), & (()()) *
 *                                                              *
 * There are 5 total combinations when the input is 3, so your  *
 * program should return 5.                                     *
 *                                                              *
 * Examples                                                     *
 * Input 1: 3                                                   *
 * Output 1: 5                                                  *
 *                                                              *
 * Input 2: 2                                                   *
 * Output 2: 2                                                  *
 *                                                              *
 ***************************************************************/

using System;

class MainClass {

  public static long BracketCombinations(int num) {

    long res = Factorial(2*num)/(Factorial(num+1)*Factorial(num)); 
    return res;

  }

  public static long Factorial(int num){
    if (num == 0){
      return 1;
    }
    else{
      long result = 1;
      for(int i = 2 ; i<=num ; i++){
        result *= i;
      }
        return result;
    }
  }

}
...................................................................
//Question#2
/*              CODERBYTE RUN LENGTH CHALLENGE                  *
 *                                                              *
 * Problem Statement                                            *
 * Have the function RunLength(str) take the str parameter being*
 * passed and return a compressed version of the string using   *
 * the Run-length encoding algorithm. This algorithm works by   *
 * taking the occurrence of each repeating character and        *
 * outputting that number along with a single character of the  *
 * repeating sequence.                                          *
 * For example: "wwwggopp" would return 3w2g1o2p.               *
 * The string will not contain any numbers, punctuation,        *
 * or symbols.                                                  *
 *                                                              *
 * Examples                                                     *
 * Input 1: "aabbcde"                                           *
 * Output 1: 2a2b1c1d1e                                         *
 *                                                              *
 * Input 2: "wwwbbbw"                                           *
 * Output 2: 3w3b1w                                             *
 *                                                              *
                                                   
 ***************************************************************/

class MainClass {
    public static string RunLength(string str) {
        if (string.IsNullOrEmpty(str)) return "";

        string result = "";
        int count = 1;

        for (int i = 1; i < str.Length; i++) {
            if (str[i] == str[i - 1]) {
                // If the current character is the same as the previous one, increment the count
                count++;
            } else {
                // Otherwise, append the count and the previous character to the result
                result += count.ToString() + str[i - 1];
                // Reset the count for the new character
                count = 1;
            }
        }

        // Append the count and the last character
        result += count.ToString() + str[str.Length - 1];

        return result;
    }
}

 ............................................................
 //Question#3
 /****************************************************************
 *             CODERBYTE PALINDROME TWO CHALLENGE               *
 *                                                              *
 * Problem Statement                                            *
 * Have the function PalindromeTwo(str) take the str parameter  * 
 * being passed and return the string true if the parameter is  *
 * a palindrome, (the string is the same forward as it is       *
 * backward) otherwise return the string false. The parameter   *
 * entered may have punctuation and symbols but they should not *
 * affect whether the string is in fact a palindrome.           *
 * For example: "Anne, I vote more cars race Rome-to-Vienna"    *
 * should return true.                                          *
 *                                                              *
 * Examples                                                     *
 * Input 1: "Noel - sees Leon"                                  *
 * Output 1: true                                               *
 *                                                              *
 * Input 2: "A war at Tarawa!"                                  *
 * Output 2: true                                               *
 *                                                              *
 * Solution Efficiency                                          *
 * The user scored higher than 33.1% of users who solved this   *
 * challenge.                                                   *
 *                                                              *
 ***************************************************************/
class MainClass {

  public static bool PalindromeTwo(string str) {

    str = str.ToLower();
    char[] arr = str.ToCharArray();
    List<char> list = new List<char>();

    for(int i=0; i<arr.Length;i++){
      if(char.IsLetter(arr[i])){
        list.Add(arr[i]);
      }
    }

    char[] filteredArray = list.ToArray();
    int length = filteredArray.Length;

    for(int i=0; i<length; i++){
      if(filteredArray[i] != filteredArray[length-1-i]){
        return false;
      }
    }
    return true;

  }
}

 .....................................................................................
 //Question#4
 /****************************************************************
 *             CODERBYTE STRING SCRAMBLE CHALLENGE              *
 *                                                              *
 * Problem Statement                                            *
 * Have the function StringScramble(str1,str2) take both        * 
 * parameters being passed and return the string true if a      *
 * portion of str1 characters can be rearranged to match str2,  *
 * otherwise return the string false.                           *
 * For example: if str1 is "rkqodlw" and str2 is "world" the    *
 * output should return true. Punctuation and symbols will not  *
 * be entered with the parameters.                              *
 *                                                              *
 * Examples                                                     *
 * Input 1: "cdore" & "coder"                                   *
 * Output 1: true                                               *
 *                                                              *
 * Input 2: "h3llko" & "hello"                                  *
 * Output 2: false                                              *
 *                                                              *
 * Solution Efficiency                                          *
 * The user scored higher than 37.5% of users who solved this   *
 * challenge.                                                   *
 *                                                              *
 ***************************************************************/

using System;
using System.Collections.Generic;

class MainClass {

  public static string StringScramble(string str1, string str2) {
    // Convert the strings to character arrays
    char[] arr1 = str1.ToCharArray();
    char[] arr2 = str2.ToCharArray();
    
    // Create a dictionary to count the frequency of each character in str1
    Dictionary<char, int> charCount = new Dictionary<char, int>();

    // Count the characters in str1
    foreach (char c in arr1) {
      if (char.IsLetter(c)) { // Only consider alphabetic characters
        if (charCount.ContainsKey(c)) {
          charCount[c]++;
        } else {
          charCount[c] = 1;
        }
      }
    }

    // Check if str2 can be formed by the characters in str1
    foreach (char c in arr2) {
      if (char.IsLetter(c)) { // Only consider alphabetic characters
        if (charCount.ContainsKey(c) && charCount[c] > 0) {
          charCount[c]--;
        } else {
          return "false";
        }
      }
    }

    return "true";
  }

  static void Main() {
    // Examples
    Console.WriteLine(StringScramble("cdore", "coder")); // Output: true
    Console.WriteLine(StringScramble("h3llko", "hello")); // Output: false
    Console.WriteLine(StringScramble("rkqodlw", "world")); // Output: true
    Console.WriteLine(StringScramble("abc123", "cba")); // Output: true
    Console.WriteLine(StringScramble("123", "abc")); // Output: false
  }
}

 ..................................................
 //Question#5
 /****************************************************************
 *             CODERBYTE ARRAY ADDITION I CHALLENGE             *
 *                                                              *
 * Problem Statement                                            *
 * Have the function ArrayAdditionI(arr) take the array of      *
 * numbers stored in arr and return the string true if any      *
 * combination of numbers in the array (excluding the largest   *
 * number) can be added up to equal the largest number in the   *
 * array, otherwise return the string false.                    *
 * For example: if arr contains [4, 6, 23, 10, 1, 3] the output *
 * should return true because 4 + 6 + 10 + 3 = 23. The array    *
 * will not be empty, will not contain all the same elements,   *
 * and may contain negative numbers.                            *
 *                                                              *
 * Examples                                                     *
 * Input 1: [5,7,16,1,2]                                        *
 * Output 1: false                                              *
 *                                                              *
 * Input 2: [3,5,-1,8,12]                                       *
 * Output 2: true                                               *
 *                                                              *
 ***************************************************************/

























 .......................................................................................
  //Question#6
 /****************************************************************
 *              CODERBYTE BINARY CONVERTER CHALLENGE            *
 *                                                              *
 * Problem Statement                                            *
 * Have the function BinaryConverter(str) return the decimal    *
 * form of the binary value. For example: if 101 is passed      *
 * return 5, or if 1000 is passed return 8.                     *
 *                                                              *
 * For example: the number 10 is Happy because 1^2 + 0^2	*
 * converges to 1.       					*
 *                                                              *
 * Examples                                                     *
 * Input 1: "100101" 		                                *
 * Output 1: 37                                                 *
 *                                                              *
 * Input 2: "011"                                               *
 * Output 2: 3                                                  *
 *                                                              *
 ***************************************************************/

using System;
using System.Collections.Generic;

class MainClass {

  public static string ArrayAdditionI(int[] arr) {
    // Find the largest number
    int max = int.MinValue;
    foreach (int num in arr) {
      if (num > max) {
        max = num;
      }
    }

    // Remove the largest number from the array
    List<int> numbers = new List<int>(arr);
    numbers.Remove(max);

    // Check if any combination sums to the largest number
    return CanSumToTarget(numbers, max) ? "true" : "false";
  }

  public static bool CanSumToTarget(List<int> numbers, int target) {
    return CanSumToTargetHelper(numbers, target, 0);
  }

  private static bool CanSumToTargetHelper(List<int> numbers, int target, int startIndex) {
    if (target == 0) return true;
    if (target < 0) return false;

    for (int i = startIndex; i < numbers.Count; i++) {
      if (CanSumToTargetHelper(numbers, target - numbers[i], i + 1)) {
        return true;
      }
    }

    return false;
  }

  static void Main() {
    // Examples
    Console.WriteLine(ArrayAdditionI(new int[] {5, 7, 16, 1, 2})); // Output: false
    Console.WriteLine(ArrayAdditionI(new int[] {3, 5, -1, 8, 12})); // Output: true
    Console.WriteLine(ArrayAdditionI(new int[] {4, 6, 23, 10, 1, 3})); // Output: true
  }
}

 ...............................................................
 // //Question#7
 /****************************************************************
 *               CODERBYTE FORMATTED DIVISION CHALLENGE         *
 *                                                              *
 * Problem Statement                                            *
 * Have the function FormattedDivision(num1,num2) take both     *
 * parameters being passed, divide num1 by num2, and return the *
 * result as a string with properly formatted commas and 4      *
 * significant digits after the decimal place.                  * 
 *                                                              *
 * For example: if num1 is 123456789 and num2 is 10000          *
 * the output should be "12,345.6789".                          *
 * The output must contain a number in the one's place even     *
 * if it is a zero.                                             *
 *                                                              *
 * Examples                                                     *
 * Input 1: 2 and 3                                             *
 * Output 1: 0.6667                                             *
 *                                                              *
 * Input 2: 10 and 10                                           *
 * Output 2: 1.0000                                             *
 *                                                              *
 * Solution Efficiency                                          *
 * This user scored higher than 53.8% of users who solved this  * 
 * challenge.                                                   *
 *                                                              *
 ***************************************************************/

class MainClass {
    public static string FormattedDivision(int num1, int num2) {
        double result = (double)num1 / num2;
        string resultStr = result.ToString("F4", CultureInfo.InvariantCulture);

        // Split the string into integer and fractional parts
        string[] parts = resultStr.Split('.');

        // Format the integer part with commas
        string integerPart = Int32.Parse(parts[0]).ToString("N0", CultureInfo.InvariantCulture);

        // Combine the formatted integer part and the fractional part
        string formattedResult = integerPart + "." + parts[1];

        return formattedResult;
    }
}



...................................................................................
 //Question#8
/****************************************************************
 *             CODERBYTE CAESAR CIPHER CHALLENGE                *
 *                                                              *
 * Problem Statement                                            *
 * Have the function CaesarCipher(str,num) take the str         *
 * parameter and perform a Caesar Cipher shift on it using the  *
 * num parameter as the shifting number. A Caesar Cipher works  *
 * by shifting each letter in the string N places in the        *
 * alphabet (in this case N will be num). Punctuation, spaces,  *
 * and capitalization should remain intact.                     *
 * For example if the string is "Caesar Cipher" and num is 2    *
 * the output should be "Ecguct Ekrjgt".                        *
 *                                                              *
 * Examples                                                     *
 * Input 1: "Hello" and num = 4                                 *
 * Output 1: Lipps                                              *
 *                                                              *
 * Input 2: "abc" and num = 0                                   *
 * Output 2: abc                                                *
 *                                                              *
 *                                                              *
 * Solution Efficiency                                          *
 * The user scored higher than 49.2% of users who solved this   *
 * challenge.                                                   *
 *                                                              *
 ***************************************************************/









 ..................................................................................
  //Question#9
 /****************************************************************
 *             CODERBYTE COUNTING MINUTES ONE CHALLENGE         *
 *                                                              *
 * Problem Statement                                            *
 * Have the function CountingMinutesI(str) take the str         *
 * parameter being passed which will be two times               *
 * (each properly formatted with a colon and am or pm)          *
 * separated by a hyphen and return the total number of minutes *
 * between the two times. The time will be in a 12 hour clock   *
 * format.                                                      * 
 * For example: if str is 9:00am-10:00am then the               *
 * output should be 60. If str is 1:00pm-11:00am the output     *
 * should be 1320.                                              *
 *                                                              *
 * Examples                                                     *
 * Input 1: "12:30pm-12:00am"                                   *
 * Output 1: 690                                                *
 *                                                              *
 * Input 2: "1:23am-1:08am"                                     *
 * Output 2: 1425                                               *
 *                                                              *
 * Solution Efficiency                                          *
 * The user scored higher than 44.7% of users who solved this   *
 * challenge.                                                   *
 *                                                              *
 ***************************************************************/

-----------------My Solution----------------
using System;
using System.Text.RegularExpressions;

class MainClass {
    public static int CountingMinutes(string str) {
      char[] arr = str.ToCharArray();
      char first ='$';
      char second ='$';
      bool toAdd = false;

      char[] delimiters = new char[] { ':', '-', 'p', 'a' };
      string[] buffer = str.Split(delimiters);


      int hour_1 = Convert.ToInt32(buffer[0]);
      int min_1 = Convert.ToInt32(buffer[1]);
      int hour_2 = Convert.ToInt32(buffer[3]);
      int min_2 = Convert.ToInt32(buffer[4]);
     

      int total = (hour_2*60 + min_2) - (hour_1*60 + min_1);
      
 

      if(arr[4] == 'a' || arr[5]== 'a'){
        first = 'a';
      }
      if(arr[4] == 'p' || arr[5]== 'p'){
        first = 'p';
      }
      if(arr[arr.Length-2] == 'a'){
        second = 'a';
      }
      if(arr[arr.Length-2] == 'p'){
        second = 'p';
      }
      if(first != second){
        toAdd = true;
      }

      if(toAdd){
        total = total+720;
      }
      if(total<0){
        total = total+1440;
      }


        return total;
    }
    

    

    static void Main() {
        // keep this function call here
        Console.WriteLine(CountingMinutes(Console.ReadLine()));
    }
}

---------------------CHATGPT solution-------------------

using System;
using System.Globalization;

class MainClass {
    public static int CountingMinutes(string str) {
        string[] times = str.Split('-');

        DateTime startTime = DateTime.ParseExact(times[0], "h:mmtt", CultureInfo.InvariantCulture);
        DateTime endTime = DateTime.ParseExact(times[1], "h:mmtt", CultureInfo.InvariantCulture);

        // Calculate the difference in minutes
        TimeSpan difference = endTime - startTime;

        // If the end time is before the start time, add 24 hours to the end time
        if (difference.TotalMinutes < 0) {
            difference += TimeSpan.FromDays(1);
        }

        return (int)difference.TotalMinutes;
    }

    static void Main() {
        // keep this function call here
        Console.WriteLine(CountingMinutes(Console.ReadLine()));
    }
}





 .............................................................
  //Question#10
 /****************************************************************
 *               CODERBYTE NUMBER SEARCH CHALLENGE              *
 *                                                              *
 * Problem Statement                                            *
 * Have the function NumberSearch(str) take the str parameter,  *
 * search for all the numbers in the string, add them together, *
 * then return that final number divided by the total amount of *
 * letters in the string. For example: if str is                *
 * "Hello6 9World 2, Nic8e D7ay!" the output should be 2.       *
 * First if you add up all the numbers, 6 + 9 + 2 + 8 + 7       *
 * you get 32. Then there are 17 letters in the string.         *
 * 32 / 17 = 1.882, and the final answer should be rounded to   *
 * the nearest whole number, so the answer is 2. Only single    *
 * digit numbers separated by spaces will be used throughout    *
 * the whole string,                                            *
 * (So this won't ever be the case: hello44444 world).          *
 * Each string will also have at least one letter.              *
 *                                                              *
 * Examples                                                     *
 * Input 1: "H3ello9-9"		                                *
 * Output 1: 4                                                  *
 *                                                              *
 * Input 2: "One Number*1*"                                     *
 * Output 2: 0                                                  *
 *                                                              *
 ***************************************************************/


class MainClass {
    public static int NumberSearch(string str) {
        
    char[] arr = str.ToCharArray();
    int total = 0;
    int count = 0;
    for(int i=0; i<arr.Length; i++){
      if(char.IsNumber(arr[i])){
        total += arr[i]-'0';
      }
      if(char.IsLetter(arr[i])){
        count++;
      }
    }
    double result = (double) total/count;
    int output = (int)Math.Round(result);


        return output;
    }
}




 ......................................................................
  //Question#11

 /****************************************************************
 *             CODERBYTE SWIPE CASE TWO CHALLENGE               *
 *                                                              *
 * Problem Statement                                            *
 * Have the function SwapII(str) take the str parameter and swap*
 * the case of each character. Then, if a letter is between two *
 * numbers (without separation), switch the places of the two   *
 * numbers.                                                     *
 * For example: if str is "6Hello4 -8World, 7 yes3"             *
 * the output should be 4hELLO6 -8wORLD, 7 YES3.                *
 *                                                              *
 * Examples                                                     *
 * Input 1: "Hello -5LOL6"                                      *
 * Output 1: hELLO -6lol5                                       *
 *                                                              *
 * Input 2: "2S 6 du5d4e"                                       *
 * Output 2: 2s 6 DU4D5E                                        *
 *                                                              *
 * Solution Efficiency                                          *
 * The user scored higher than 51.8% of users who solved this   *
 * challenge.                                                   *
 *                                                              *
 ***************************************************************/
















 ..............................................................
  //Question#12
 /****************************************************************
 *             CODERBYTE DASH INSERT TWO CHALLENGE              *
 *                                                              *
 * Problem Statement                                            *
 * Have the function DashInsertII(str) insert dashes ('-')      *
 * between each two odd numbers and insert asterisks ('*')      *
 * between each two even numbers in str.                        *
 *                                                              *
 * For example: if str is 4546793 the output should be          *
 * 454*67-9-3. Don't count zero as an odd or even number.       *
 *                                                              *
 * Examples                                                     *
 * Input 1: 99946                                               *
 * Output 1: 9-9-94*6                                           *
 *                                                              *
 * Input 2: 56647304                                            *
 * Output 2: 56*6*47-304                                        *
 *                                                              *
 * Solution Efficiency                                          *
 * The user scored higher than 36.2% of users who solved this   *
 * challenge.                                                   *
 *                                                              *
 ***************************************************************/












 .........................................................
 //Question#13
/****************************************************************
 *             CODERBYTE PERMUTATION STEP CHALLENGE             *
 *                                                              *
 * Problem Statement                                            *
 * Have the function PermutationStep(num) take the num parameter*
 * being passed & return the next number greater than num using *
 * the same digits.                                             *
 *                                                              *
 * For example: if num is 123 return 132, if it's 12453 return  *
 * 12534. If a number has no greater permutations,              *
 * return -1 (ie. 999).                                         *
 *                                                              *
 * Examples                                                     *
 * Input 1: 11121		                                *
 * Output 1: 11211                                              *
 *                                                              *
 * Input 2: 41352                                               *
 * Output 2: 41523                                              *
 *                                                              *
 * Input 3: 897654321                                           *
 * Output 3: 912345678                                          *
 *                                                              *
 * Input 4: 76666666                                            *
 * Output 4: -1                                                 *
 *                                                              *
 ***************************************************************/





















....................................................................
 //Question#14
/*************************************************************************
*                                                                        *
*  Have the function MostFreeTime(strArr) *
*  read the strArr parameter being passed which will represent a full    *
*  day and will be filled with events that span from time X to time Y in *
*  the day. The format of each event will be hh:mmAM/PM-hh:mmAM/PM.      *
*  For example, strArr may be                                            *
*  ["10:00AM-12:30PM","02:00PM-02:45PM","09:10AM-09:50AM"]. Your program *
*  will have to output the longest amount of free time available         *
*  between the start of your first event and the end of your last event  *
*  in the format: hh:mm. The start event should be the earliest event    *
*  in the day and the latest event should be the latest event in the     *
*  day. The output for the previous input would therefore be 01:30       *
*  (with the earliest event in the day starting at 09:10AM and the       *
*  latest event ending at 02:45PM). The input will contain at least 3    *
*  events and the events may be out of order.                            *
*                                                                        *
*************************************************************************/
















............................................................
 //Question# 15
/*'''
Have the function StockPicker(arr) take the array of numbers stored
in arr which will contain integers that represent the amount in dollars
that a single stock is worth, and return the maximum profit that could
have been made by buying stock on day x and selling stock on day y 
where y > x. For example: if arr is [44, 30, 24, 32, 35, 30, 40, 38,
15] then your program should return 16 because at index 2 the stock 
was worth $24 and at index 6 the stock was then worth $40, so if you 
bought the stock at 24 and sold it at 40, you would have made a profit
of $16, which is the maximum profit that could have been made with this
list of stock prices.

If there is not profit that could have been made with the stock prices,
then your program should return -1. For exmaple: arr is [10, 9, 8, 2]
then your program should return -1.

Examples:

Input: [10, 12, 4, 5, 9]
Output: 5

'''
*/












...............................................................
 //Question#16
/*
Using the Python language, have the function BitmapHoles(strArr) 
take the array of strings stored in strArr, which will be a 2D matrix 
of 0 and 1's, and determine how many holes, or contiguous regions of 0's, 
exist in the matrix. A contiguous region is one where there is a 
connected group of 0's going in one or more of four directions: up, 
down, left, or right. For example: if strArr is 
["10111", "10101", "11101", "11111"], then this looks like the following matrix: 
1 0 1 1 1
1 0 1 0 1
1 1 1 0 1
1 1 1 1 1 
For the input above, your program should return 2 because
there are two separate contiguous regions of 0's, which create 
"holes" in the matrix. You can assume the input will not be empty. 

Input:"01111", "01101", "00011", "11110"
Output:3

Input:"1011", "0010"
Output:2
"""
*/













..................................................................................
 //Question#17
/**
 *
 * Using the C# language, have the function FoodDistribution(arr) read the array of numbers stored in arr which will represent
 * the hunger level of different people ranging from 0 to 5 (0 meaning not hungry at all, 5 meaning very hungry).
 * You will also have N sandwiches to give out which will range from 1 to 20.
 * The format of the array will be [N, h1, h2, h3, ...]
 * where N represents the number of sandwiches you have and the rest of the array will represent the hunger levels of different people.
 *
 * Your goal is to minimize the hunger difference between each pair of people in the array using the sandwiches you have available.
 *
 * For example:
 * if arr is [5, 3, 1, 2, 1], this means you have 5 sandwiches to give out. You can distribute them in the following
 * order to the people: 2, 0, 1, 0. Giving these sandwiches to the people their hunger levels now become: [1, 1, 1, 1].
 * The difference between each pair of people is now 0, the total is also 0, so your program should return 0.
 * Note: You may not have to give out all, or even any, of your sandwiches to produce a minimized difference.
 *
 * Another example:
 * if arr is [4, 5, 2, 3, 1, 0] then you can distribute the sandwiches in the following order: [3, 0, 1, 0, 0]
 * which makes all the hunger levels the following: [2, 2, 2, 1, 0].
 * The differences between each pair of people is now: 0, 0, 1, 1 and so your program should return the final minimized
 * difference of 2.
 
 */











 ...........................................................................
  //Question#18
 // Have the function EightQueens(strArr) read strArr which will be an array
// consisting of the locations of eight Queens on a standard 8x8 chess board
// with no other pieces on the board. The structure of strArr will be the
// following: ["(x,y)", "(x,y)", ...] where (x,y) represents the position of the
// current queen on the chessboard (x and y will both range from 1 to 8 where
// 1,1 is the bottom-left of the chessboard and 8,8 is the top-right). Your
// program should determine if all of the queens are placed in such a way where
// none of them are attacking each other. If this is true for the given input,
// return the string "true" otherwise return the first queen in the list that is
// attacking another piece in the same format it was provided.
// 
// For example: if strArr is ["(2,1)", "(4,2)", "(6,3)", "(8,4)", "(3,5)",
// "(1,6)", "(7,7)", "(5,8)"] then your program should return the string true.





















...................................................................
 //Question#19
// For this challenge you will be helping a dog collect all the food in a grid.
/*
have the function CharlietheDog(strArr) read the array of strings stored in strArr which will be a 4x4 matrix of the characters 'C', 'H', 'F', 'O', where C represents Charlie the dog, H represents its home, F represents dog food, and O represents and empty space in the grid. Your goal is to figure out the least amount of moves required to get Charlie to grab each piece of food in the grid by moving up, down, left, or right, and then make it home right after. Charlie cannot move onto the home before all pieces of food have been collected. For example: if strArr is ["FOOF", "OCOO", "OOOH", "FOOO"], then this looks like the following grid:


For the input above, the least amount of steps where the dog can reach each piece of food, and then return home is 11 steps, so your program should return the number 11. The grid will always contain between 1 and 8 pieces of food.
*/

















.....................................................
 //Question#20
/****************************************************************
 *             CODERBYTE STRING CALCULATE CHALLENGE             *
 *                                                              *
 * Problem Statement                                            *
 * Have the function StringCalculate(str) take the str parameter*
 * being passed and evaluate the mathematical expression within *
 * in. The double asterisks (**) represent exponentiation.      *
 * For example, if str were "(2+(3-1)*3)**3" the output should  *
 * be 512. Another example: if str is "(2-0)(6/2)" the output   *
 * should be 6. There can be parenthesis within the string so   *
 * you must evaluate it properly according to the rules of      *
 * arithmetic.                                                  *
 * The string will contain the operators: +, -, /, *, (, ),     *
 * and **. If you have a string like this: #/#*# or #+#(#)/#,   *
 * then evaluate from left to right. So divide then multiply,   *
 * and for the second one multiply, divide, then add.           *
 * The evaluations will be such that there will not be any      *
 * decimal operations, so you do not need to account for        *
 * rounding.                                                    *
 *                                                              *
 * Examples                                                     *
 * Input 1: "6*(4/2)+3*1"                                       *
 * Output 1: 15                                                 *
 *                                                              *
 * Input 2: "100*2**4"                                          *
 * Output 2: 1600                                               *
 *                                                              *
 ***************************************************************/

















 ...................................................................................
  //Question#21
 /****************************************************************
 *                  CODERBYTE PLUS MINUS CHALLENGE              *
 *                                                              *
 * Problem Statement                                            *
 * Have the function PlusMinus(num) read the num parameter being*
 * passed which will be a combination of 1 or more single       *
 * digits, and determine if it's possible to separate the digits*
 * with either a plus or minus sign to get the final expression *
 * to equal zero.                                               *
 *                                                              *
 * For example: if num is 35132 then it's possible to separate  *
 * the digits the following way, 3 - 5 + 1 + 3 - 2, and this    *
 * expression equals zero.                                      *
 *                                                              *
 * Your program should return a string of the signs you used, so*
 * for this example your program should return -++-. If it's not* 
 * possible to get the digit expression to equal zero, return   *
 * the string not possible.                                     *
 *                                                              *
 * If there are multiple ways to get the final expression to    *
 * equal zero, choose the one that contains more minus          *
 * characters. For example: if num is 26712 your program        *
 * should return -+-- and not +-+-.                             *
 *                                                              *
 * Examples                                                     *
 * Input 1: 199                                                 *
 * Output 1: not possible                                       *
 *                                                              *
 * Input 2: 26712                                               *
 * Output 2: -+--                                               *
 *                                                              *
 ***************************************************************/






























 ..............................................................................................
  //Question#22
 /****************************************************************
 *             CODERBYTE STRING EXPRESSION CHALLENGE            *
 *                                                              *
 * Problem Statement                                            *
 * Have the function StringExpression(str) read the str         *
 * parameter being passed which will contain the written out    *
 * version of the numbers 0-9 and the words "minus" or "plus" & *
 * convert the expression into an actual final number written   *
 * out as well.                                                 *
 * For example: if str is "foursixminustwotwoplusonezero" then  *
 * this converts to "46 - 22 + 10" which evaluates to 34 and    *
 * your program should return the final string threefour.       *
 * If your final answer is negative it should include the       *
 * word "negative."                                             *
 *                                                              *
 * Examples                                                     *
 * Input 1: "onezeropluseight"                                  *
 * Output 1: oneeight                                           *
 *                                                              *
 * Input 2: oneminusoneone                                      *
 * Output 2: negativeonezero                                    *
 *                                                              *
 ***************************************************************/






















 ......................................................
  //Question#23
 /****************************************************************
 *             CODERBYTE LONGEST CONSECUTIVE CHALLENGE          *
 *                                                              *
 * Problem Statement                                            *
 * Have the function LongestConsecutive(arr) take the array of  *
 * positive integers stored in arr and return the length of the *
 * longest consecutive subsequence (LCS).                       *
 * An LCS is a subset of the original list where the numbers    *
 * are in sorted order, from lowest to highest, and are in a    *
 * consecutive, increasing order. The sequence does not need to *
 * be contiguous and there can be several different subsequences*
 *                                                              *
 * For example: if arr is [4, 3, 8, 1, 2, 6, 100, 9] then a few *
 * consecutive sequences are [1, 2, 3, 4], and [8, 9].          *
 * For this input, your program should return 4 because that is *
 * the length of the longest consecutive subsequence.           *
 *                                                              *
 * If there are less than four numbers in the array your program*
 * should return the sum of all the numbers in the array.       *
 *                                                              *
 * Examples                                                     *
 * Input 1: [6, 7, 3, 1, 100, 102, 6, 12]                       *
 * Output 1: 2                                                  *
 *                                                              *
 * Input 2: [5, 6, 1, 2, 8, 9, 7]                               *
 * Output 2: 5                                                  *
 *                                                              *
 ***************************************************************/




































 ...........................................................................
  //Question#24
 /****************************************************************
 *               CODERBYTE OFF BINARY CHALLENGE                 *
 *                                                              *
 * Problem Statement                                            *
 * Have the function OffBinary(strArr) read the array of strings* 
 * stored in strArr, which will contain two elements, the first *
 * will be a positive decimal number and the second element will* 
 * be a binary number. Your goal is to determine how many digits* 
 * in the binary number need to be changed to represent the     *
 * decimal number correctly (either 0 change to 1 or vice versa)*
 *                                                              * 
 * For example: if strArr is ["56", "011000"] then your program *
 * should return 1 because only 1 digit needs to change in the  *
 * binary number (the first zero needs to become a 1) to        *
 * correctly represent 56 in binary.                            *
 *                                                              *
 * Examples                                                     *
 * Input 1: ["5624", "0010111111001"]                           *
 * Output 1: 2                                                  *
 *                                                              *
 * Input 2: ["44", "111111"]                                    *
 * Output 2: 3                                                  *
 *                                                              *
 ***************************************************************/































 .................................................................................
  //Question#25
 /****************************************************************
 *             CODERBYTE STRING ZIGZAG CHALLENGE                *
 *                                                              *
 * Problem Statement                                            *
 * Have the function StringZigzag(strArr) read the array of     *
 * strings stored in strArr, which will contain two elements,   *
 * the first some sort of string and the second element will be *
 * a number ranging from 1 to 6. The number represents how many *
 * rows to print the string on so that it forms a zig-zag       *
 * pattern. For example: if strArr is ["coderbyte", "3"] then   *
 * this word will look like the following if you print it in a  *
 * zig-zag pattern with 3 rows:                                 *
 * Your program should return the word formed by combining the  *
 * characters as you iterate through each row, so for this      *
 * example your program should return the string creoebtdy.     *
 *                                                              *
 * Examples                                                     *
 * Input 1: ["cat", "5"]                                        *
 * Output 1: cat                                                *
 *                                                              *
 * Input 2: ["kaamvjjfl", "4"]                                  *
 * Output 2: kjajfavlm                                          *
 *                                                              *
 ***************************************************************/




















 .................................................................
  //Question#26
 /****************************************************************
 *              CODERBYTE SIMPLE PASSWORD CHALLENGE             *
 *                                                              *
 * Problem Statement                                            *
 * Have the function SimplePassword(str) take the str parameter *
 * being passed and determine if it passes as a valid password  *
 * that follows the list of constraints:                        *
 * 1. It must have a capital letter.                            *
 * 2. It must contain at least one number.                      *
 * 3. It must contain a punctuation mark.                       *
 * 4. It cannot have the word "password" in the string.         *
 * 5. It must be longer than 7 characters and                   * 
 *    shorter than 31 characters.                               *
 * If all the above constraints are met within the string, the  *
 * your program should return the string true, otherwise your   *
 * program should return the string false.                      *
 * For example: if str is "apple!M7" then your program should   *
 * return "true".                                               *
 *                                                              *
 * Examples                                                     *
 * Input 1: "passWord123!!!!"                                   *
 * Output 1: false                                              *
 *                                                              *
 * Input 2: "turkey90AAA="                                      *
 * Output 2: true                                               *
 *                                                              *
 ***************************************************************/





























 .........................................................................
  //Question#27
 /****************************************************************
 *           CODERBYTE MATCHING CHARACTERS CHALLENGE            *
 *                                                              *
 * Problem Statement                                            *
 * Have the function MatchingCharacters(str) take the str       *
 * parameter being passed and determine the largest number of   *
 * unique characters that exists between a pair of matching     *
 * letters anywhere in the string.                              *
 *                                                              *
 * For example: if str is "ahyjakh" then there are only two     *
 * pairs of matching letters, the two a's and the two h's.      *
 * Between the pair of a's there are 3 unique characters:       *
 * h, y, and j.                                                 *
 * Between the h's there are 4 unique characters: y, j, a, & k. *
 * So for this example your program should return 4.            *
 *                                                              *
 * Another example: if str is "ghececgkaem" then your program   *
 * should return 5 because the most unique characters exists    *
 * within the farthest pair of e characters. The input string   *
 * may not contain any character pairs, and in that case your   *
 * program should just return 0. The input will only consist of *
 * lowercase alphabetic characters.                             *
 *                                                              *
 * Examples                                                     *
 * Input 1: "mmmerme"                                           *
 * Output 1: "3"                                                *
 *                                                              *
 * Input 2: "abccdefghi"                                        *
 * Output 2: "0"                                                *
 *                                                              *
 * Solution Efficiency                                          *
 * This user scored higher than 67.3% of users who solved this  * 
 * challenge.                                                   *
 ***************************************************************/


































 ..............................................................................................
  //Question#28
 /****************************************************************
 *          CODERBYTE PALINDROMIC SUBSTRING CHALLENGE		*
 *                                                              *
 * Problem Statement                                            *
 * Have the function PalindromicSubstring(str) take the str     *
 * parameter being passed and find the longest palindromic      *
 * substring, which means the longest substring which is read   *
 * the same forwards as it is backwards.                        *
 * For example: if str is "abracecars" then your program should *
 * return the string racecar because it is the longest          *
 * palindrome within the input string.                          *
 *                                                              *
 * The input will only contain lowercase alphabetic characters. *
 * The longest palindromic substring will always be unique,     *
 * but if there is none that is longer than 2 characters,       *
 * return the string none.                                      *
 *                                                              *
 * Examples                                                     *
 * Input 1: "hellosannasmith"                                   *
 * Output 1: sannas                                             *
 *                                                              *
 * Input 2: "abcdefgg"                                          *
 * Output 2: none                                               *
 *                                                              *
 ***************************************************************/






........................................................................................
 //Question#29
/************************************************************************
 *                 CODERBYTE WORD SPLIT CHALLENGE                       *
 *                                                                      *
 * Problem Statement                                                    *
 * Have the function WordSplit(strArr) read the array of strings stored *
 * strArr, which will contain 2 elements: the first element will be a   *
 * sequence of characters, and the second element will be a long string *
 * of comma-separated words, in alphabetical order, that represents a   *
 * dictionary of some arbitrary length. For example: strArr can be:     *
 * ["hellocat", "apple,bat,cat,goodbye,hello,yellow,why"].              *
 *                                                                      *
 * Your goal is to determine if the first element in the input can be   *
 * split into two words, where both words exist in the dictionary that  *
 * is provided in the second input. In this example, the first element  *
 * can be split into two words: hello and cat because both of those     *
 * words are in the dictionary. Your program should return the two words*
 * that exist in the dictionary separated by a comma. So for the example*
 * above,your program should return hello,cat. There will only be one   *
 * correct way to split the first element of characters into two words. *
 * If there is no way to split string into two words that exist in the  *
 * dictionary, return the string not possible. The first element itself *
 * will never exist in the dictionary as a real word.                   *
 *                                                                      *
 * Examples                                                             *
 * Input 1: ["baseball", "a,all,b,ball,bas,base,cat,code,d,e,quit,z"]   *
 * Output 1: base,ball                                                  *
 *                                                                      *
 * Input 2: ["abcgefd", "a,ab,abc,abcg,b,c,dog,e,efd,zzzz"]             *
 * Output 2: abcg,efd                                                   *
 *                                                                      *
 ***********************************************************************/












........................................................................................
 //Question#30
/****************************************************************
 *                 CODERBYTE MATRIX SPIRAL CHALLENGE            *
 *                                                              *
 * Problem Statement                                            *
 * Have the function MatrixSpiral(strArr) read the array of     *
 * strings stored in strArr which will represent a 2D N matrix, *
 * and your program should return the elements after printing   *
 * them in a clockwise, spiral order. You should return the     *
 * newly formed list of elements as a string with the numbers   *
 * separated by commas.                                         *
 *                                                              *
 * For example: strArr is "[1, 2, 3]", "[4, 5, 6]", "[7, 8, 9]" *
 * then this looks like the following 2D matrix:                *
 *                              1 2 3                           *
 *                              4 5 6                           *
 *                              7 8 9                           *
 * So your program should return the elements of this matrix in *
 * a clockwise, spiral order which is: 1,2,3,6,9,8,7,4,5        *
 *                                                              *
 * Examples                                                     *
 * Input 1: ["[1, 2]", "[10, 14]"]                              *
 * Output 1: 1,2,14,10                                          *
 *                                                              *
 * Input 2: ["[4, 5, 6, 5]", "[1, 1, 2, 2]", "[5, 4, 2, 9]"]    *
 * Output 2: 4,5,6,5,2,9,2,4,5,1,1,2                            *
 *                                                              *
 ***************************************************************/











........................................................................................
 //Question#31
/****************************************************************
 *          CODERBYTE NEAREST SMALLER VALUES CHALLENGE		*
 *                                                              *
 * Problem Statement                                            *
 * Have the function NearestSmallerValues(arr) take the array of*
 * integers stored in arr, and for each element in the list,    *
 * search all the previous values for the nearest element that  *
 * is smaller than (or equal to) the current element and create *
 * a new list from these numbers. If there is no element before *
 * a certain position that is smaller, input a -1.              *
 * For example: if arr is [5, 2, 8, 3, 9, 12] then the nearest  *
 * smaller values list is [-1, -1, 2, 2, 3, 9].                 *
 * The logic is as follows: For 5, there is no smaller previous *
 * value so the list so far is [-1]. For 2, there is also no    *
 * smaller previous value, so the list is now [-1, -1].         *
 * For 8, the nearest smaller value is 2 so the list is now     *
 * [-1, -1, 2]. For 3, the nearest smaller value is also 2,     *
 * so the list is now [-1, -1, 2, 2]. This goes on to produce   *
 * the answer above. Your program should take this final list   *
 * and return the elements as a string separated by a           *
 * space: -1 -1 2 2 3 9                                         *
 *                                                              *
 * Examples                                                     *
 * Input 1: [5, 3, 1, 9, 7, 3, 4, 1]                            *
 * Output 1: -1 -1 -1 1 1 1 3 1                                 *
 *                                                              *
 * Input 2: [2, 4, 5, 1, 7]                                     *
 * Output 2: -1 2 4 -1 1                                        *
 *                                                              *
 ***************************************************************/


























........................................................................................
 //Question#32
/****************************************************************
 *               CODERBYTE EVEN PAIRS CHALLENGE		        *
 *                                                              *
 * Problem Statement                                            *
 * Have the function EvenPairs(str) take the str parameter being*
 * passed & determine if a pair of adjacent even numbers exists *
 * anywhere in the string. If a pair exists, return the string  *
 * true, otherwise return false. For example: if str is         *
 * "f178svg3k19k46" then there are two even numbers at the end  *
 * of the string, "46" so your program should return the string *
 * true. Another example: if str is "7r5gg812" then the pair is *
 * "812" (8 & 12) so your program should return the string true *
 *                                                              *
 * Examples                                                     *
 * Input 1: "3gy41d216"                                         *
 * Output 1: true                                               *
 *                                                              *
 * Input 2: "f09r27i8e67"                                       *
 * Output 2: false                                              *
 *                                                              *
 ***************************************************************/















........................................................................................
 //Question#33
/****************************************************************
 *             CODERBYTE ARRAY MIN JUMPS CHALLENGE              *
 *                                                              *
 * Problem Statement                                            *
 * Have the function ArrayMinJumps(arr) take the array of       *
 * integers stored in arr, where each integer represents the    *
 * maximum number of steps that can be made from that position, *
 * and determine the least amount of jumps that can be made to  *
 * reach the end of the array.                                  *
 * For example: if arr is [1, 5, 4, 6, 9, 3, 0, 0, 1, 3] then   *
 * your program should output the number 3 because you can reach*
 * the end of the array from the beginning via the following    *
 * steps: 1 -> 5 -> 9 -> END or 1 -> 5 -> 6 -> END.             *
 * Both of these combinations produce a series of 3 steps.      *
 * And as you can see, you don't always have to take the maximum*
 * number of jumps at a specific position, you can take less    *
 * jumps even though the number is higher.                      *
 *                                                              *
 * If it's not possible to reach the end of the array, return -1*
 *                                                              *
 * Examples                                                     *
 * Input 1: [3, 4, 2, 1, 1, 100]                                *
 * Output 1: 2                                                  *
 *                                                              *
 * Input 2: [1, 3, 6, 8, 2, 7, 1, 2, 1, 2, 6, 1, 2, 1, 2]       *
 * Output 2: 4                                                  *
 *                                                              *
 ***************************************************************/























........................................................................................
 //Question#34

/****************************************************************
 *              CODERBYTE MISSING DIGIT CHALLENGE               *
 *                                                              *
 * Problem Statement                                            *
 * Have the function MissingDigit(str) take the str parameter,	*
 * which will be simple mathematical formula with three numbers,*
 * a single operator (+, -, *, or /) and an equal sign (=) and  *
 * return the digit that completes the equation.                *
 *                                                              *
 * In one of the numbers in the equation, there will be an x    *
 * character, and your program should determine what digit is   *
 * missing.                                                     *
 *                                                              *
 * For example, if str is "3x + 12 = 46" then your program      *
 * should output 4. The x character can appear in any of the    *
 * three numbers and all three numbers will be greater than or  *
 * equal to 0 and less than or equal to 1000000.                *
 *                                                              *
 *                                                              *
 * Examples                                                     *
 * Input 1: "4 - 2 = x"		                                *
 * Output 1: 2                                                  *
 *                                                              *
 * Input 2: "1x0 * 12 = 1200"		                        *
 * Output 2: 0                                                  *
 *                                                              *
 ***************************************************************/
























........................................................................................
 //Question#35
/****************************************************************
 *                 CODERBYTE MAX SUBARRAY CHALLENGE             *
 *                                                              *
 * Problem Statement                                            *
 * Have the function MaxSubarray(arr) take the array of numbers *
 * stored in arr and determine the largest sum that can be      *
 * formed by any contiguous subarray in the array.              *
 * For example, if arr is [-2, 5, -1, 7, -3] then your program  *
 * should return 11 because the sum is formed by the subarray   *
 * [5, -1, 7]. Adding any element before or after this subarray *
 * would make the sum smaller.                                  *
 *                                                              *
 * Examples                                                     *
 * Input 1: [1, -2, 0, 3]                                       *
 * Output 1: 3                                                  *
 *                                                              *
 * Input 2: [3, -1, -1, 4, 3, -1]                               *
 * Output 2: 8                                                  *
 *                                                              *
 ***************************************************************/


















........................................................................................
 //Question#36
/****************************************************************
 *              CODERBYTE DISTINCT LIST CHALLENGE               *
 *                                                              *
 * Problem Statement                                            *
 * Have the function DistinctList(arr) take the array of numbers*
 * stored in arr and determine the total number of duplicate    *
 * entries. For example if the input is [1, 2, 2, 2, 3] then    *
 * your program should output 2 because there are two duplicates*
 * of one of the elements.                                      *
 *                                                              *
 * Examples                                                     *
 * Input 1: [0,-2,-2,5,5,5]                                     *
 * Output 1: 3                                                  *
 *                                                              *
 * Input 2: [100,2,101,4]                                       *
 * Output 2: 0                                                  *
 *                                                              *
 ***************************************************************/










........................................................................................
 //Question#37

/****************************************************************
 *             CODERBYTE STRING REDUCTION CHALLENGE             *
 *                                                              *
 * Problem Statement                                            *
 * Have the function StringReduction(str) take the str parameter*
 * being passed and return the smallest number you can get      *
 * through the following reduction method.                      *
 * The method is: Only the letters a, b, and c will be given in *
 * str and you must take two different adjacent characters and  *
 * replace it with the third. For example "ac" can be replaced  *
 * with "b" but "aa" cannot be replaced with anything.          *
 * This method is done repeatedly until the string cannot be    *
 * further reduced, and the length of the resulting string is   *
 * to be outputted.                                             *
 *                                                              *
 * For example: if str is "cab", "ca" can be reduced to "b"     *
 * and you get "bb" (you can also reduce it to "cc").           *
 * The reduction is done so the output should be 2.             *
 *                                                              *
 * If str is "bcab", "bc" reduces to "a", so you have "aab",    *
 * then "ab" reduces to "c", and the final string "ac" is       *
 * reduced to "b" so the output should be 1.                    *
 *                                                              *
 * Examples                                                     *
 * Input 1: "abcabc"                                            *
 * Output 1: 2                                                  *
 *                                                              *
 * Input 2: cccc                                                *
 * Output 2: 4                                                  *
 *                                                              *
 * Solution Efficiency                                          *
 * The user scored more than 53.0% of users who solved this     *
 * challenge                                                    *
 *                                                              *
 ***************************************************************/






















........................................................................................
