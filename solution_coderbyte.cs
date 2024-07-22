
using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_CSharp.Easy_Challenges
{
    class StringIntersection
    {
        // Have the function FindIntersection(strArr) read the array of strings stored 
        // in strArr which will contain 2 elements: the first element will represent a 
        // list of comma - separated numbers sorted in ascending order, the second 
        // element will represent a second list of comma - separated numbers(also sorted).
        // Your goal is to return a comma - separated string containing the numbers that 
        // occur in elements of strArr in sorted order.If there is no intersection, 
        // return the string false.

        // For example : if strArr contains["1, 3, 4, 7, 13", "1, 2, 4, 13, 15"] the 
        // output should return "1,4,13" because those numbers appear in both strings.
        // The array given will not be empty, and each string inside the array will be 
        // of numbers sorted in ascending order and may contain negative numbers.

    using System;

class MainClass {

  public static string FindIntersection(string[] strArr) {

    string result = "";
    string[] strArr1 = strArr[0].Split(",");
    string[] strArr2 = strArr[1].Split(",");
    
    foreach (string item1 in strArr1)
    {
        foreach (string item2 in strArr2)
        {
            // If there is a match, add it to the result string
            if (item1.Trim() == item2.Trim())
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result += ",";
                }
                result += item1.Trim();
            }
        }
    }
    
    return result;

  }

  static void Main() {  

    // keep this function call here
    Console.WriteLine(FindIntersection(Console.ReadLine()));
    
  } 

}

        

.....................................................................

using System;
using System.Text;

namespace Coderbyte_CSharp.Easy_Challenges
{
    class StringPeriod
    {
    
        // For this challenge you will need to find the largest repeating substring.

        // The function StringPeriods(str) take the str parameter being passed and 
        // determine if there is some substring K that can be repeated N > 1 times 
        // to produce the input string exactly as it appears. Your program should 
        // return the longest substring K, and if there is none it should return 
        // the string -1.

        // For example: if str is "abcababcababcab" then your program should return 
        // abcab because that is the longest substring that is repeated 3 times to 
        // create the final string. 

        // Another example: if str is "abababababab" then your program should return 
        // ababab because it is the longest substring. 

        // If the input string contains only a single character, your program should 
        // return the string -1.
 using System;

class MainClass {
    public static string StringPeriods(string str) {
        int n = str.Length;

        // Loop from half the length of the string down to 1
        for (int len = n / 2; len > 0; len--) {
       // Check if the current length is a divisor of the string length
            if (n % len == 0) {
       // Calculate the number of times the substring would need to repeat
                int numRepeats = n / len;
                // Get the substring
                string substring = str.Substring(0, len);            
                // Build the repeated string
                string repeatedStr = "";
                for (int i = 0; i < numRepeats; i++) {
                    repeatedStr += substring;
                }
                
                // Check if the repeated string matches the original string
                if (repeatedStr == str) {
                    return substring;
                }
            }
        }
        
        // If no repeating substring is found, return "-1"
        return "-1";
    }

    static void Main() {
        // keep this function call here
        Console.WriteLine(StringPeriods(Console.ReadLine()));
    }
}

    }
}
...................................................................................

using System;
using System.Text.RegularExpressions;

namespace Coderbyte_CSharp._1_Easy_Challenges
{
    class UsernameValidation
    {
        //Have the function CodelandUsernameValidation(str) take the str parameter being
        //    passed and determine if the string is a valid username according to the
        //following rules :

        //1. The username is between 4 and 25 characters.
        //2. It must start with a letter.
        //3. It can only contain letters, numbers, and the underscore character.
        //4. It cannot end with an underscore character.

        //If the username is valid then your program should return the string true,
        //otherwise return the string false.
        

        public static string CodelandUsernameValidation(string str) {
        // Rule 1: Check if the username is between 4 and 25 characters
        if (str.Length < 4 || str.Length > 25) {
            return "false";
        }
        
        // Rule 2: Check if it starts with a letter
        if (!char.IsLetter(str[0])) {
            return "false";
        }
        
        // Rule 3: Check if it only contains letters, numbers, and underscores
        // Rule 4: Check if it does not end with an underscore
        string pattern = @"^[a-zA-Z0-9_]*[a-zA-Z0-9]$";
        if (!Regex.IsMatch(str, pattern)) {
            return "false";
        }
        
        // If all checks passed, the username is valid
        return "true";
    }

    static void Main() {
        // keep this function call here
        Console.WriteLine(CodelandUsernameValidation(Console.ReadLine()));
    }
}
}
....................................................................



using System;

class MainClass {
    Min Window Substring
// Have the function MinWindowSubstring(strArr) take the array of strings stored in strArr, which will contain only two strings, the first parameter being the string N and the second parameter being a string K of some characters, and your goal is to determine the smallest substring of N that contains all the characters in K. For example: if strArr is ["aaabaaddae", "aed"] then the smallest substring of N that contains the characters a, e, and d is "dae" located at the end of the string. So for this example your program should return the string dae.

// Another example: if strArr is ["aabdccdbcacd", "aad"] then the smallest substring of N that contains all of the characters in K is "aabd" which is located at the beginning of the string. Both parameters will be strings ranging in length from 1 to 50 characters and all of K's characters will exist somewhere in the string N. Both strings will only contains lowercase alphabetic characters.

  public static string MinWindowSubstring(string[] strArr) {
        string N = strArr[0];
        string K = strArr[1];
        int strArr1Size = N.Length;
        int strArr2Size = K.Length;

        // Start with the smallest possible window size, which is the length of K
        for (int limit = strArr2Size; limit <= strArr1Size; ++limit) {
            // Slide the window across N
            for (int start = 0; start + limit <= strArr1Size; ++start) {
                // Get the current window substring
                string subStr = N.Substring(start, limit);
                
                // Convert both K and the current window substring into character arrays
                char[] strArr1ChArr = K.ToCharArray();
                char[] subStrChArr = subStr.ToCharArray();
                bool checkNext = true;

                // Check if all characters in K are in the current window
                for (int i = 0; i < K.Length; i++) {
                    if (checkNext) {
                        bool found = false;
                        for (int j = 0; j < subStr.Length; j++) {
                            if (strArr1ChArr[i] == subStrChArr[j]) {
                                // Mark characters as found by setting them to space
                                subStrChArr[j] = strArr1ChArr[i] = ' ';
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            checkNext = false;
                    } else
                        break;
                }

                // If all characters are found, return the current window substring
                if (String.Concat(strArr1ChArr).Trim().Length == 0)
                    return subStr;
            }
        }
        
        // Return an empty string if no valid window is found
        return "";
    }

    static void Main() {
        // Keep this function call here
        // Read input from the console and split it into an array
        string input = Console.ReadLine();
        string[] inputArr = input.Split(',');
        Console.WriteLine(MinWindowSubstring(inputArr));
    }
}
    }
............................................................................................


using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_CSharp.Medium_Challenges
{
    class NumberEncoder
    {
        // For this challenge you will encode a given string following a specific rule.
        // The function NumberEncoding(str) with str parameter and encode the 
        // message according to the following rule: encode every letter into its 
        // corresponding numbered position in the alphabet. Symbols and spaces will also 
        // be used in the input. 

        // For example: if str is "af5c a#!" then your program should return 1653 1#!. 

        public static string NumberEncoding(string str) {
        string result = "";

        foreach (char c in str) {
            if (char.IsLetter(c)) {
                if (char.IsLower(c)) {
                    // For lowercase letters
                    result += (c - 'a' + 1).ToString();
                } else {
                    // For uppercase letters
                    result += (c - 'A' + 1).ToString();
                }
            } else {
                // If it's not a letter, keep the character as it is
                result += c;
            }
        }

        return result;
    }

    static void Main() {
        // Keep this function call here
        Console.WriteLine(NumberEncoding(Console.ReadLine()));
    }
}
}
}
...........................................................

using System;
using System.Text;

namespace Coderbyte_CSharp.Medium_Challenges
{
    class StringCompression
    {
        // For this challenge you will determine the Run Length Encoding of a string.
        // The function RunLength(str) take the str parameter being passed and return 
        // a compressed version of the string using the Run-length encoding algorithm. 
        // This algorithm works by taking the occurrence of each repeating character 
        // and outputting that number along with a single character of the repeating 
        // sequence. 

        // For example: "wwwggopp" would return 3w2g1o2p. The string will not contain 
        // any numbers, punctuation, or symbols. 
        using System;

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

    static void Main() {
        // Keep this function call here
        Console.WriteLine(RunLength(Console.ReadLine()));
    }
}
    }
}

.....................................................................



using Coderbyte_CSharp.Easy_Challenges;

namespace Coderbyte_CSharp._3_Hard_Challenges
{
    class ChessBoard
    {
        // Have the function ChessboardTraveling(str) read str which will be a string 
        // consisting of the location of a space on a standard 8x8 chess board with 
        // no pieces on the board along with another space on the chess board. The 
        // structure of str will be the following: "(x y)(a b)" where (x y) represents 
        // the position you are currently on with x and y ranging from 1 to 8 and 
        // (a b) represents some other space on the chess board with a and b also 
        // ranging from 1 to 8 where a > x and b > y. Your program should determine 
        // how many ways there are of traveling from (x y) on the board to (a b) 
        // moving only up and to the right. For example: if str is (1 1)(2 2) then your 
        // program should output 2 because there are only two possible ways to travel 
        // from space (1 1) on a chessboard to space (2 2) while making only moves up 
        // and to the right.
        using System;

class MainClass {
    public static int ChessboardTraveling(string str) {
        // Parse the input string
        int x = int.Parse(str.Substring(1, 1));
        int y = int.Parse(str.Substring(3, 1));
        int a = int.Parse(str.Substring(6, 1));
        int b = int.Parse(str.Substring(8, 1));
        
        // Calculate the number of steps needed in each direction
        int rightSteps = a - x;
        int upSteps = b - y;
        
        // Calculate the total number of steps
        int totalSteps = rightSteps + upSteps;
        
        // Calculate the binomial coefficient (totalSteps choose rightSteps)
        return BinomialCoefficient(totalSteps, rightSteps);
    }

    // Function to calculate binomial coefficient C(n, k)
    public static int BinomialCoefficient(int n, int k) {
        if (k > n - k) k = n - k; // C(n, k) == C(n, n - k)
        int result = 1;
        for (int i = 0; i < k; ++i) {
            result *= (n - i);
            result /= (i + 1);
        }
        return result;
    }

    static void Main() {
        // Keep this function call here
        Console.WriteLine(ChessboardTraveling(Console.ReadLine()));
    }
}
}
}
........................................................................


using System.Collections.Generic;
using System.Linq;

namespace Coderbyte_CSharp.Hard_Challenges
{
    class Kaprekar
    {
        // Have the function KaprekarsConstant(num) take the num parameter being passed 
        // which will be a 4-digit number with at least two distinct digits. Your program 
        // should perform the following routine on the number: Arrange the digits in 
        // descending order and in ascending order (adding zeroes to fit it to a 4-digit 
        // number), and subtract the smaller number from the bigger number. Then repeat 
        // the previous step. Performing this routine will always cause you to reach a 
        // fixed number: 6174. Then performing the routine on 6174 will always give you 
        // 6174 (7641 - 1467 = 6174). Your program should return the number of times 
        // this routine must be performed until 6174 is reached. 

        // For example: if num is 3524 your program should return 3 because of the 
        // following steps: (1) 5432 - 2345 = 3087, (2) 8730 - 0378 = 8352, 
        // (3) 8532 - 2358 = 6174.

       
     using System;

class MainClass {
    public static int KaprekarsConstant(int num) {
        int count = 0;
        
        while (num != 6174) {
            // Convert the number to a 4-digit string
            string numStr = num.ToString("D4");
            
            // Sort the digits in descending order
            char[] descending = numStr.ToCharArray();
            Array.Sort(descending);
            Array.Reverse(descending);
            int descNum = int.Parse(new string(descending));
            
            // Sort the digits in ascending order
            char[] ascending = numStr.ToCharArray();
            Array.Sort(ascending);
            int ascNum = int.Parse(new string(ascending));
            
            // Subtract the smaller number from the larger number
            num = descNum - ascNum;
            
            // Increment the count
            count++;
        }
        
        return count;
    }

    static void Main() {
        // Keep this function call here
        Console.WriteLine(KaprekarsConstant(int.Parse(Console.ReadLine())));
    }
}

}

}


..............................................................................
