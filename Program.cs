/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1, 1, 2 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = [0,0,0];
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 0, 1, 1,0,1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 10 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 1, 2, 1,10 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("axxxxyyyyb", "xy");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Initialize variables to keep track of the last processed number and the current index in the array.
                var lastNumber = int.MinValue;
                var currentIndex = 0;

                // Iterate through the array.
                for (var i = 0; i < nums.Length; i++)
                {
                    var val = nums[i];
                    // If the current number is the same as the last processed number, skip it.
                    if (lastNumber == val)
                    {
                        continue;
                    }

                    // Update the current index with the unique value and update the last processed number.
                    nums[currentIndex] = val;
                    lastNumber = val;
                    currentIndex++;
                }

                // Return the index of the last unique element.
                return currentIndex;
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it.
                throw;
            }
            // Self-reflection: 
            // This algorithm demonstrates an efficient way to remove duplicates from a sorted array while preserving the relative order of elements.
            // By iterating through the array once, it identifies and skips duplicates, updating the array in-place.
            // The use of two variables, lastNumber and currentIndex, simplifies tracking of processed elements.
           
        }



        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Iterate through the array.
                for (var i = 0; i < nums.Length; i++)
                {
                    var val = nums[i];
                    // If the current element is not zero, continue to the next element.
                    if (val != 0)
                    {
                        continue;
                    }

                    // If the current element is zero, find the next non-zero element.
                    for (var j = i + 1; j < nums.Length; j++)
                    {
                        var newVal = nums[j];
                        // If a non-zero element is found, swap it with the zero element and break the loop.
                        if (newVal != 0)
                        {
                            (nums[i], nums[j]) = (nums[j], nums[i]);
                            break;
                        }
                    }
                }

                // Return the modified array with zeroes moved to the end.
                return nums;
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it.
                throw;
            }
            // Self-reflection:
            // This function efficiently moves all zeroes to the end of the array while preserving the relative order of non-zero elements.
            // It iterates through the array and upon encountering a zero, it searches for the next non-zero element to swap positions.
           
        }


        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Initialize lists to store unique triplets and their sorted versions.
                var triplets = new List<List<int>>();
                var tripletsSorted = new List<List<int>>();

                // Iterate through the array to find unique triplets that sum up to zero.
                for (var i = 0; i < nums.Length; i++)
                {
                    for (var j = i + 1; j < nums.Length; j++)
                    {
                        for (var k = j + 1; k < nums.Length; k++)
                        {
                            // Ensure that the three indices are distinct.
                            if (i == j || i == k || j == k)
                            {
                                continue;
                            }

                            // Check if the sum of the triplet is zero.
                            if (nums[i] + nums[j] + nums[k] == 0)
                            {
                                // Create a new triplet and its sorted version.
                                var newTriplet = new List<int>() { nums[i], nums[j], nums[k] };
                                var sortedTriplet = new List<int>(newTriplet);
                                sortedTriplet.Sort();

                                // Add the triplet to the list if it's not a duplicate.
                                if (!tripletsSorted.Any(ints => ints.ToArray().SequenceEqual(sortedTriplet)))
                                {
                                    triplets.Add(newTriplet);
                                    tripletsSorted.Add(sortedTriplet);
                                }
                            }
                        }
                    }
                }

                // Return the array of unique triplets.
                return triplets.ToArray();
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it.
                throw;
            }
            // Self-reflection:
            // This function finds all unique triplets in the array that sum up to zero.
            // It utilizes three nested loops to generate all possible combinations of triplets, then checks for their uniqueness and sum.
            
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Initialize variables to keep track of maximum consecutive ones and current count of consecutive ones.
                var maxConsecutive = 0;
                var currentCount = 0;

                // Iterate through the array.
                foreach (var num in nums)
                {
                    // If the current number is 1, increment the count of consecutive ones.
                    if (num == 1)
                    {
                        currentCount++;
                    }
                    else
                    {
                        // If the current number is not 1, update the maximum consecutive ones encountered so far and reset the count.
                        maxConsecutive = Math.Max(maxConsecutive, currentCount);
                        currentCount = 0;
                    }
                }
                // Return the maximum consecutive ones encountered.
                return Math.Max(maxConsecutive, currentCount);
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it.
                throw;
            }
            // Self-reflection:
            // This function efficiently finds the maximum number of consecutive ones in the given binary array.
            // It iterates through the array once, maintaining a count of consecutive ones and updating the maximum count encountered.
           
        }


        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Convert the binary number to a string and reverse it to facilitate iteration from right to left.
                var binaryString = binary.ToString().Reverse();

                // Initialize variables to hold the total decimal value and the multiplier for each binary digit.
                var total = 0;
                var multiplier = 1;

                // Iterate through each binary digit in the reversed binary string.
                foreach (var num in binaryString.Select(numChar => int.Parse(numChar.ToString())))
                {
                    // Multiply the current binary digit with the multiplier and add it to the total.
                    total += num * multiplier;

                    // Update the multiplier by multiplying it by 2 to move to the next position in the binary representation.
                    multiplier *= 2;
                }
                // Return the total decimal value obtained from the binary representation.
                return total;
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it.
                throw;
            }
            // Self-reflection:
            // This function converts a binary number to its equivalent decimal representation.
            // It iterates through the binary digits of the number, starting from the least significant digit, and calculates the decimal value accordingly.
            
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Check if the array has less than 2 elements, in which case there are no gaps.
                if (nums.Length < 2)
                {
                    return 0;
                }

                // Sort the array in ascending order to facilitate finding the maximum difference between consecutive elements.
                Array.Sort(nums);

                // Initialize a variable to hold the maximum difference between consecutive elements.
                var maxDifference = 0;

                // Iterate through the array to find the maximum difference between consecutive elements.
                for (var i = 0; i < nums.Length; i++)
                {
                    // If we have reached the last element, exit the loop.
                    if (i == nums.Length - 1)
                    {
                        break;
                    }

                    // Calculate the difference between the current element and the next element.
                    var difference = Math.Abs(nums[i] - nums[i + 1]);

                    // Update the maximum difference if the current difference is greater.
                    maxDifference = Math.Max(maxDifference, difference);
                }

                // Return the maximum difference between consecutive elements in the sorted array.
                return maxDifference;
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it.
                throw;
            }
            // Self-reflection:
            // This function finds the maximum gap between consecutive elements in an array.
            // It sorts the array first to ensure consecutive elements are adjacent, then iterates through the array to find the maximum difference.
            
        }


        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Initialize a variable to hold the largest perimeter.
                var largestPerimeter = 0;

                // Iterate through the array up to the third-to-last element.
                for (var i = 0; i < nums.Length; i++)
                {
                    // If the current index reaches the third-to-last element, exit the loop.
                    if (i == nums.Length - 2)
                    {
                        break;
                    }

                    // Extract three consecutive elements from the array.
                    var (a, b, c) = (nums[i], nums[i + 1], nums[i + 2]);

                    // Check if the extracted elements form a valid triangle.
                    if (a + b > c && a + c > b && b + c > a)
                    {
                        // Update the largest perimeter if the current combination forms a larger perimeter.
                        largestPerimeter = Math.Max(largestPerimeter, a + b + c);
                    }
                }

                // Return the largest perimeter found.
                return largestPerimeter;
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it.
                throw;
            }
            // Self-reflection:
            // This function finds the largest perimeter formed by three consecutive elements in the array.
            // It iterates through the array and extracts three consecutive elements to check if they form a valid triangle.
            
        }


        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Remove occurrences of the substring "part" from the string "s" until none are left.
                while (s.Contains(part))
                {
                    s = s.Remove(s.IndexOf(part), part.Length);
                }
                // Return the modified string after removal of all occurrences of "part".
                return s;
            }
            catch (Exception)
            {
                // If an exception occurs, rethrow it.
                throw;
            }
            
        }


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }



        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each element in double quotes
            }

            // Join the elements in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
// Self-reflection:
// This function removes all occurrences of a given substring from a string.
// It utilizes a while loop to repeatedly search for and remove the substring until none are left.
