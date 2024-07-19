using System;

namespace Coderbyte_CSharp.Easy_Challenges
{
    class ChangeLetter
    {
        // Have the function LetterChanges(str) take the str parameter being passed and 
        // modify it using the following algorithm. Replace every letter in the string 
        // with the letter following it in the alphabet (ie. c becomes d, z becomes a). 
        // Then capitalize every vowel in this new string (a, e, i, o, u) and finally 
        // return this modified string.
        public string LetterChanges(string str)
        {
            string result   = String.Empty;
            char[] chars    = str.ToCharArray();
            //chars[index] = newChar;


            // 1st increment ascii value, wrap z to a
            // 2nd capitalize vowels  
            for (int index = 0; index < chars.Length; index++)
            {
                char c = chars[index];

                if (Char.IsLetter(chars[index]) && chars[index] != 'z')
                {
                    chars[index]++;
                }

                else if (chars[index] == 'z')
                {
                    chars[index] = 'a';
                }

                c = chars[index];
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    chars[index] = Char.ToUpper(c);
                }
            }

            result = new string(chars);

            return result;
        }

        // Have the function LetterCapitalize(str) take the str parameter being passed 
        // and capitalize the first letter of each word. Words will be separated by 
        // only one space.
        public string LetterCapitalize(string str)
        {
            string result = String.Empty;
            char[] chars  = str.ToCharArray();


            for ( int index = 0; index < chars.Length; index++)
            {
                if (index == 0 && Char.IsLower(str[index]))
                {
                    chars[index] = Char.ToUpper(chars[index]);
                }

                if (index > 0 && chars[index - 1] == ' ')
                {
                    chars[index] = Char.ToUpper(chars[index]);
                }
            }

            result = new string(chars);

            return result;
        }
    }
}

.....................................................................

using System;
using System.Collections.Generic;
using System.Text;

namespace Coderbyte_CSharp.Easy_Challenges
{
    class MathProduct
    {
        // Challenge
        // function ProductDigits(num) has a num parameter, which is a positive integer.  
        // Determine the least amount of digits you need to multiply to produce the 
        // value .

        // For example : if num is 24 then you can multiply 8 by 3 which produces 24, 
        // so your program should return 2 because there is a total of only 2 digits 
        // that are needed.

        // Another example : if num is 90, you can multiply 10 * 9, so in this case 
        // your program should output 3 because you cannot reach 90 without using a 
        // total of 3 digits in your multiplication.

        //Sample Test Cases
        //  Input : 6
        //	Output : 2
        //	Input : 23
        //	Output : 3
        public int ProductDigits(int num)
        {
            int result = num.ToString().Length + 1; 

            int factor;
            int value;
            for (int index = 1; index <= Math.Sqrt(num); index++)
            {
                // Is index a factor of num
                if (num % index == 0)
                {
                    factor = num / index;
                    value = index.ToString().Length + factor.ToString().Length ;
                    result = Math.Min(result, value);
                }
            }


            return result;
        }

        // Have the function OtherProducts(arr) take the array of numbers stored in arr 
        // and return a new list of the products of all the other numbers in the array 
        // for each element. 

        // For example: if arr is [1, 2, 3, 4, 5] then the new array, 
        // where each location in the new array is the product of all other elements, 
        // is [120, 60, 40, 30, 24]. The following calculations were performed to get 
        // this answer: [(2*3*4*5), (1*3*4*5), (1*2*4*5), (1*2*3*5), (1*2*3*4)]. You 
        // should generate this new array and then return the numbers as a string 
        // joined by a hyphen: 120-60-40-30-24. The array will contain at most 10 
        // elements and at least 1 element of only positive integers.
        public string OtherProducts(int[] arr, int length)
        {
            // ReSharper disable once RedundantAssignment
            string      result          = String.Empty;
            List<int>   productValues   = new List<int>(length);
            // ReSharper disable once TooWideLocalVariableScope
            int         product = 1;

            for (int index = 0; index < length; index++)
            {
                product = ComputeProduct(arr, index);
                productValues.Add(product);
            }

            StringBuilder sb = new StringBuilder();

            foreach (int item in productValues)
            {
                sb.Append(item);
                sb.Append("-");
            }

            result = sb.ToString();
            result = result.Remove(result.Length - 1);

            return result;
        }

        protected int ComputeProduct(int[] arr, int index)
        {
            int result = 1;
            int length = arr.Length;

            for (int i = 0; i < length; i++)
            {
                if (i == index) { continue; }
                result *= arr[i];
            }

            return result;
        }
    }
}

......................................................................

using System;

namespace Coderbyte_CSharp.Easy_Challenges
{
    class MathSequence
    {
        // The function ArithGeo(arr) takes an array of numbers stored in arr and return 
        // the string "Arithmetic" if the sequence follows an arithmetic pattern or return 
        // "Geometric" if it follows a geometric pattern.If the sequence doesn't follow 
        // either pattern return -1. An arithmetic sequence is one where the difference 
        // between each of the numbers is consistent, where as in a geometric sequence, 
        // each term after the first is multiplied by some constant or common ratio. 

        // Arithmetic example: [2, 4, 6, 8] and Geometric example: [2, 6, 18, 54]. 
        // Negative numbers may be entered as parameters, 0 will not be entered, and 
        // no array will contain all the same elements.

        public string ArithGeo(int[] arr, int length)
        {
            string result = String.Empty;

            if (IsArithematicSequence(arr, length))
            {
                result = "Arithmetic";
            }

            else if (IsGeometricSequence(arr, length))
            {
                result = "Geometric";
            }

            else
            {
                result = "-1";
            }

            return result;
        }

        protected bool IsArithematicSequence(int[] arr, int length)
        {
            bool result = false;
            bool isSequence = true;

            if (length >= 2)
            {
                int diff = arr[1] - arr[0];

                // Check is the difference is true for all elements
                // If true than the array is arithmetic
                for (int index = 0; index < length - 1 && isSequence; index++)
                {
                    isSequence = false;
                    if (arr[index] + diff == arr[index + 1])
                    {
                        isSequence = true;
                    }
                }
            }

            result = isSequence;
            return result;
        }
        protected bool IsGeometricSequence(int[] arr, int length)
        {
            bool result = false;
            bool isSequence = true;

            if (length >= 2)
            {
                int diff = arr[1] / arr[0];

                // Iterate through array
                for (int index = 0; index < length - 1 && isSequence; index++)
                {
                    isSequence = false;

                    // Check for geometric pattern
                    if (arr[index] * diff == arr[index + 1])
                    {
                        isSequence = true;
                    }
                }
            }

            result = isSequence;
            return result;
        }
    }
}

...................................................................

using System;

namespace Coderbyte_CSharp.Easy_Challenges
{
    class QuestionMarkSum
    {
        // Have the function QuestionsMarks(str) take the str string parameter, which 
        // will contain single digit numbers, letters, and question marks, and check 
        // if there are exactly 3 question marks between every pair of two numbers 
        // that add up to 10. If so, then your program should return the string true, 
        // otherwise it should return the string false.If there aren't any two numbers 
        // that add up to 10 in the string, then your program should return false as well.

        // For example : if str is "arrb6???4xxbl5???eee5" then your program should return 
        // true because there are exactly 3 question marks between 6 and 4, and 3 question 
        // marks between 5 and 5 at the end of the string.
        public string QuestionsMarks(string str)
        {
            string result    = String.Empty;
            bool   pass      = false;
            int    firstPos  = -1;
            int    secondPos = -1;
            int    index     = 0;

            while (index < str.Length)
            {
                if (FindNumbersInString(str, index, out firstPos, out secondPos))
                {

                    int first  = (int)Char.GetNumericValue(str[firstPos]);
                    int second = (int)Char.GetNumericValue(str[secondPos]);


                    // 2 integers must equal 10
                    if ((first + second) == 10)
                    {
                        // There must be exactly 3 question marks between 2 integers
                        pass = IsQuestionMarksExist(str, firstPos, secondPos);
                    }

                    index = secondPos + 1;
                }

                // No numbers found in string
                else
                {
                    pass = false;
                    break;
                }
            }

            result = pass ? "true" : "false";

            return result;
        }

        protected bool FindNumbersInString(string str, int start, out int first, out int second)
        {
            bool    result = false;
                    first = -1;
                    second = -1;

            if (start == str.Length - 1)
            {
                return false;
            }

            for (int index = start; index < str.Length; index++)
            {
                if (Char.IsDigit(str[index]))
                {
                    if (first == -1)
                    {
                        first = index;
                    }

                    else
                    {
                        second = index;
                        break;
                    }
                }
            }

            result = (first != -1 && second != -1);

            return result;
        }

        protected  bool IsQuestionMarksExist(string str, int start, int end)
        {
            bool result = false;

            int num1  = start + 1;
            int num2  = end;
            int count = 0;

            if (num2 - num1 >= 3)
            {
                for (int index = num1; index < num2; index++)
                {
                    if (str[index] == '?')
                    {
                        count++;
                    }
                }

                result = (count == 3);
            }


            return result;
        }
    }
}

............................................................................

using System.Collections.Generic;

namespace Coderbyte_CSharp.Easy_Challenges
{
    class StringBrackets
    {
        // For this challenge you will determine how to create evenly matched brackets.

        // The function RemoveBrackets(str) take the str string parameter being passed, 
        // which will contain only the characters "(" and ")", and determine the minimum 
        // number of brackets that need to be removed to create a string of correctly 
        // matched brackets. 

        // For example: if str is "(()))" then your program should return the number 1. 
        // The answer could potentially be 0, and there will always be at least one set 
        // of matching brackets in the string.
        public int RemoveBrackets(string str)
        {
            int count = 0;

            Stack<char> unmatched = new Stack<char>();

            foreach (char c in str)
            {
                if (c == '(')
                {
                    unmatched.Push(c);
                }

                // char is ')'
                else
                {
                    // check for matching bracket in stack
                    if (unmatched.Count != 0 && unmatched.Peek() == '(')
                    {
                        unmatched.Pop();
                    }
                    else
                    {
                        unmatched.Push(c);
                    }
                }
            }

            // Stack contains unmatched brackets
            count = unmatched.Count;

            return count;
        }
    }
}

.................................................................................


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

        public string FindIntersection(string[] strArr)
        {
            string result = String.Empty;
            char delim = ',';

            int[] first  = TokenizeInt(strArr[0], delim);
            int[] second = TokenizeInt(strArr[1], delim);

            List<int> matches = new List<int>();
            
            // find matches between an arrays
            foreach(int value1 in first)
            {
                foreach(int value2 in second)
                {
                    if (value1 == value2)
                    {
                        matches.Add(value1);
                    }
                }
            }

            // Convert list to output string
            StringBuilder sb = new StringBuilder();

            int count = matches.Count;
            foreach( int value in matches)
            {
                sb.Append(value);
                if (value != matches[count-1])
                {
                    sb.Append(",");
                }
            }

            result = sb.ToString();

            return result;
        }

        protected int[] TokenizeInt(string str, char delim)
        {
            string[]    strValues   = str.Split(delim);
            int[]       nums        = new int[strValues.Length];

            for(int index = 0; index < strValues.Length; index++)
            {
                try
                {
                    nums[index] = Int32.Parse(strValues[index]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Unable to parse {0}", strValues[index]);
                    Console.Error.Write(e.Message);
                }
            }

            return nums;
        }
    }
}


.....................................................................

using System;
using System.Text;

namespace Coderbyte_CSharp.Easy_Challenges
{
    class StringPeriod
    {
        // For this challenge you will need to find the smallest repeating substring.

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
        public string StringPeriods(string str)
        {
            string  result     = String.Empty;
            string  sub        = String.Empty;
            int     maxLength  = -1;
            int     strLength  = str.Length;


            if (strLength > 1)
            {
                for (int i = 0; i < strLength / 2; i++)
                {
                    sub = str.Substring(0, i + 1);

                    int len = StringCheck(sub, str);

                    if (len > maxLength)
                    {
                        maxLength = len;
                        result = sub;
                    }
                }
            }

            result = (maxLength != -1) ? result : maxLength.ToString();


            return result;
        }

        protected int StringCheck(string sub, string str)
        {
            int           length = -1;
            int           times  = str.Length / sub.Length;
            StringBuilder sb     = new StringBuilder();

            for (int index = 0; index < times; index++)
            {
                sb.Append(sub);
            }

            string temp = sb.ToString();
            if (temp == str)
            {
                length = sub.Length;
            }


            return length;
        }

    }
}


...................................................................................

using System;

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

        public string CodelandUsernameValidation(string str)
        {
            string result = String.Empty;

            bool rule1 = ValidateLength(str);
            bool rule2 = ValidateStartWithLetter(str);
            bool rule3 = ValidateOnlyValidCharacters(str);
            bool rule4 = ValidateEndCharacter(str);

            result = (rule1 && rule2 && rule3 && rule4) ? "true" : "false";


            return result;
        }

        protected bool ValidateLength(string str)
        {
            bool isValid = false;

            int length = str.Length;

            isValid = (length >= 4 && length <= 25);

            return isValid;
        }

        protected bool ValidateStartWithLetter(string str)
        {
            bool isValid = false;

            isValid = Char.IsLetter(str[0]);

            return isValid;
        }

        protected bool ValidateOnlyValidCharacters(string str)
        {
            bool isValid = true;

            foreach (char c in str)
            {
                if (!Char.IsLetterOrDigit(c) && c != '_')
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        protected bool ValidateEndCharacter(string str)
        {
            bool isValid = false;
            int  length  = str.Length;

            isValid = (str[length - 1] != '_');

            return isValid;
        }


    }
}


....................................................................



using System;

class MainClass {

  public static string MinWindowSubstring(string[] strArr) {
      // Get the length of the main string and the substring to be found
      int strArr1Size = strArr[0].Length, strArr2Size = strArr[1].Length;
      
      // Start with the smallest possible window size, which is the length of strArr[1]
      for (int limit = strArr2Size; limit <= strArr1Size; ++limit) {
          // Slide the window across strArr[0]
          for (int start = 0; start + limit <= strArr1Size; ++start) {
              // Get the current window substring
              String subStr = strArr[0].Substring(start, limit);
              
              // Convert both strArr[1] and the current window substring into character arrays
              char[] strArr1ChArr = strArr[1].ToCharArray(), subStrChArr = subStr.ToCharArray();
              bool checkNext = true;

              // Check if all characters in strArr[1] are in the current window
              for (int i = 0; i < strArr[1].Length; i++) {
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

............................................................................................

using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {

  public static string TreeConstructor(string[] strArr) {
    // Dictionary to keep track of parent nodes and their children count
    var parents = new Dictionary<int, int>();
    // Dictionary to keep track of child nodes to ensure no child has multiple parents
    var childs = new Dictionary<int, int>();

    // Iterate over each item in the input array
    foreach(var item in strArr) {
      // Remove parentheses and split by comma to get parent and child
      var it = item.Replace("(","").Replace(")","").Split(",");      
      int parent = Int32.Parse(it[1]); // Parse parent node
      int child = Int32.Parse(it[0]);  // Parse child node

      // Check if the parent already has children
      if(parents.ContainsKey(parent)) {
        parents[parent] += 1; // Increment the children count for this parent
        // If a parent has more than two children, it's not a valid binary tree
        if(parents[parent] > 2)
          return "false";
      } else {
        parents.Add(parent, 1); // Add the parent with its first child
      }

      // Check if the child already has a parent
      if(childs.ContainsKey(child)) {
        return "false"; // If a child has more than one parent, it's not valid
      } else {
        childs.Add(child, 1); // Add the child to the dictionary
      }
    }
    return "true"; // If all checks pass, it's a valid binary tree
  }

  static void Main() {  
    // Keep this function call here
    // Read input from the console and pass it to TreeConstructor function
    Console.WriteLine(TreeConstructor(Console.ReadLine()));
  } 
}


....................................................................


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
        public string NumberEncoding(string str)
        {
            string                  result      = string.Empty;
            StringBuilder           sb          = new StringBuilder();
            Dictionary<char, int>   alphabet    = CreateAlphabetMap();

            foreach (char item in str)
            {
                // is a letter
                if (Char.IsLetter(item))
                {
                    sb.Append(alphabet[item]);
                }

                // not a letter
                else
                {
                    sb.Append(item);
                }
            }

            result = sb.ToString();
            return result;
        }

        protected Dictionary<char, int> CreateAlphabetMap()
        {
            Dictionary<char, int> alpha = new Dictionary<char, int>();

            int value = 1;

            for (char key = 'a'; key <= 'z'; key++, value++)
            {
                alpha.Add(key, value);
            }

            return alpha;
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
        public string RunLength(string str)
        {
            string          result  = String.Empty;
            int             length  = str.Length;
            StringBuilder   sb      = new StringBuilder(); 

            for (int index = 0; index < length; index++)
            {
                int count = 0;

                if (IsRepeatingChar(str, index, ref count))
                {
                    sb.Append(count);
                    sb.Append(str[index]);
                    index += count - 1;
                }

                else
                {
                    sb.Append(1);
                    sb.Append(str[index]);
                }
            }

            result = sb.ToString();
            return result;
        }

        protected bool IsRepeatingChar(string str, int index, ref int count)
        {
            bool repeating = false;

            int length = str.Length;
            count = 1;

            if (index != length - 1)
            {
                while ((index < length - 1) && (str[index] == str[index + 1]))
                {
                    count++;
                    index++;
                }
            }

            repeating = (count > 1);
            return repeating;
        }
    }
}


.....................................................................


using System;
using System.Text;

namespace Coderbyte_CSharp.Medium_Challenges
{
    class StringReducer
    {
        // For this challenge you will manipulate a string of characters using a simple 
        // reduction method.

        // The function StringReduction(str) take the str parameter being passed and 
        // return the smallest number you can get through the following reduction 
        // method. The method is: Only the letters a, b, and c will be given in str and 
        // you must take two different adjacent characters and replace it with the third. 

        // For example "ac" can be replaced with "b" but "aa" cannot be replaced with 
        // anything. This method is done repeatedly until the string cannot be further 
        // reduced, and the length of the resulting string is to be outputted. 

        // For example: if str is "cab", "ca" can be reduced to "b" and you get "bb" (you 
        // can also reduce it to "cc"). The reduction is done so the output should be 2. 
        // If str is "bcab", "bc" reduces to "a", so you have "aab", then "ab" reduces to 
        // "c", and the final string "ac" is reduced to "b" so the output should be 1. 
        public int StringReduction(string str)
        {
            int     result      = 0;
            string  localStr    = str;
            int     length      = str.Length;
            bool    done        = false;

            if (length == 1)
            {
                result = 1;
            }

            else if (length == 2)
            {
                string temp = ConvertChar(str[0], str[1]);
                result = temp.Length;
            }

            else
            {
                while (!done)
                {
                    string temp;

                    //cout << "Reduction: " << localStr;
                    for (int index = 0; index < localStr.Length - 1 && !done; index++)
                    {
                        temp = ConvertChar(localStr[index], localStr[index + 1]);

                        // remove chars
                        localStr = localStr.Remove(index, 2);

                        // replace chars
                        localStr = localStr.Insert(index, temp);
                        
                        // check if end criteria met
                        done = IsDone(localStr);
                    }

                    if (done)
                    {
                        result = localStr.Length;
                    }

                    else
                    {
                        //cout << "Need another iteration" << endl;
                    }
                }
            }

            return result;
        }

        protected string ConvertChar(char first, char second)
        {
            string result = String.Empty;

            if (first == second)
            {
                StringBuilder sb = new StringBuilder(); 

                sb.Append(first);
                sb.Append(second);

                result = sb.ToString();
            }

            else
            {
                if ((first == 'a' && second == 'b') ||
                    (first == 'b' && second == 'a'))
                {
                    result = "c";
                }

                else if ((first == 'a' && second == 'c') ||
                         (first == 'c' && second == 'a'))
                {
                    result = "b";
                }

                else if ((first == 'b' && second == 'c') ||
                    (first == 'c' && second == 'b'))
                {
                    result = "a";
                }
            }

            return result;
        }

        protected bool IsDone(string str)
        {
            bool done = false;

            int length = str.Length;

            if (length == 1)
            {
                done = true;
            }

            else
            {
                done = true;
                char checkchar = str[0];

                for (int index = 1; index < length && done; index++)
                {
                    done = (checkchar == str[index]);
                }
            }

            return done;
        }
    }
}


.....................................................................


using System;
using System.Collections.Generic;

namespace Coderbyte_CSharp.Medium_Challenges
{
    class StringUniqueSubstring
    {
        // For this challenge you will be searching a string for a particular substring.
        // have the function KUniqueCharacters(str) take the str parameter being passed 
        // and find the longest substring that contains k unique characters, where k will 
        // be the first character from the string. The substring will start from the second 
        // position in the string because the first character will be the integer k. 

        // For example: if str is "2aabbacbaa" there are several substrings that all contain 
        // 2 unique characters, namely: ["aabba", "ac", "cb", "ba"], but your program should 
        // return "aabba" because it is the longest substring. If there are multiple longest 
        // substrings, then return the first substring encountered with the longest length. 
        // k will range from 1 to 6.
        public string KUniqueCharacters(string str)
        {
            string          result          = String.Empty;
            bool            done            = false;
            int             uniqueLength    = (int)char.GetNumericValue(str[0]);
            string          localStr        = str.Substring(1);
            int             substrLength    = localStr.Length;

            while (!done)
            {
                int uniqueCount = 0;

                List<string> substrings = CreateSubstrings(localStr, substrLength);
                if (substrings.Count == 0)
                {
                    continue;
                }

                foreach(string s in substrings)
                {
                    uniqueCount = ComputeUniqueChars(s);
                    if (uniqueCount == uniqueLength && s.Length > result.Length)
                    {
                        result = s;
                        done = true;
                    }
                }

                substrings.Clear();
                substrLength--;
            }
            return result;
        }

        protected int ComputeUniqueChars(string str)
        {
            int count = 1;
            Dictionary<char, int> charCount = new Dictionary<char, int>(); ;

            foreach (char c in str)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }

                else
                {
                    charCount.Add(c, 1);
                }
            }

            count = charCount.Count;
            return count;
        }

        protected List<string> CreateSubstrings(string str, int length)
        {
            List<string>    substrings  = new List<string>();
            int             strLength   = str.Length;

            if (length == strLength)
            {
                substrings.Add(str);
            }

            else if (length < strLength)
            {
                string substr;

                for (int index = 0; index + length <= strLength; index++)
                {
                    substr = str.Substring(index, length);
                    substrings.Add(substr);
                }
            }

            return substrings;
        } 
    }
}

................................................................


using System;
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
        public int ChessboardTraveling(string str)
        {
            int result = 0;
            int x, y, a, b;
            //char* token = nullptr;
            //char* data = const_cast<char*>(str.c_str());
            //char* next = nullptr;

            //token = strtok_s(data, "( )", &next); x = *token - '0';
            //token = strtok_s(NULL, "( )", &next); y = *token - '0';
            //token = strtok_s(NULL, "( )", &next); a = *token - '0';
            //token = strtok_s(NULL, "( )", &next); b = *token - '0';


            ParseInput(str, out x, out y, out a, out b);

            int row = a - x;
            int col = b - y;

            result = Ckn(row, row + col);

            return result;
        }

        protected void ParseInput(string str, out int x, out int y, out int a, out int b)
        {
            x = y = a = b = 0;

            // remove index = 0, length-1 for outer parentheses
            str = str.Substring(1, str.Length - 2);

            // Get strings for 2 positions
            string[] input    = str.Split(")(".ToCharArray(),     StringSplitOptions.RemoveEmptyEntries);
            string[] starting = input[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] ending   = input[1].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            
            x = Convert.ToInt32(starting[0]);
            y = Convert.ToInt32(starting[1]);
            a = Convert.ToInt32(ending[0]);
            b = Convert.ToInt32(ending[1]);
        }

        protected  int Ckn(int k, int n)
        {
            int       result    = 0;
            int       c         = 1;

            for (int i = n, j = 0; j < k; i--, j++)
            {
                c *= i;
            }

            Factorial factorial = new Factorial();

            var nFact  = factorial.FirstFactorial(n);
            var nkFact = factorial.FirstFactorial(n-k);
            var kFact  = factorial.FirstFactorial(k);

            result = (int)(nFact / (kFact * nkFact));
            return result;
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

        public int KaprekarsConstant(int num)
        {
            int count       = 0;
            int remainder   = num;

            while (remainder != 6174)
            {
                remainder = DescendInt(remainder) - AscendInt(remainder);
                count++;
            }

            return count;
        }

        protected int AscendInt(int num)
        {
            int result = 0;

            result = AdjustInt(num, false);
            return result;
        }

        protected int DescendInt(int num)
        {
            int result = 0;

            result = AdjustInt(num, true);
            return result;
        }

	    private int AdjustInt(int num, bool descend)
        {
            int     result  = 0;
            int[]   arr     = ConvertToIntArray(num);

            List<int> valueList = arr.ToList();
            valueList.Sort();

            if (descend)
            {
                valueList.Reverse();
            }

            result = int.Parse(string.Join("", valueList));
            return result;
        }

        private int[] ConvertToIntArray(int value)
        {
            var numbers = new Stack<int>();

            for (; value > 0; value /= 10)
            {
                numbers.Push(value % 10);
            }

            return numbers.ToArray();
        }


    }
}

........................................................................



























