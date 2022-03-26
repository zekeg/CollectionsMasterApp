using System;
using System.Collections.Generic;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create

            #region Arrays
            // Create an integer Array of size 50

            int[] Arr = new int[50];

            //Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(Arr);

            //Print the first number of the array
            Console.WriteLine("First Number:");
            Console.WriteLine(Arr[0]);
            //Print the last number of the array
            Console.WriteLine("Last Number:");
            Console.WriteLine(Arr[Arr.Length - 1]);

            Console.WriteLine("All Numbers Original");

            //Use this method to print out your numbers from arrays or lists
            NumberPrinter(Arr);
            Console.WriteLine("-------------------");

            //Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*     Hint: Array._____(); Create a custom method     */
            Array.Reverse(Arr);

            Console.WriteLine("All Numbers Reversed:");
            NumberPrinter(Arr);

            Console.WriteLine("---------REVERSE CUSTOM------------");
            //RESETTING ARR TO DEMONSTRATE NEW METHOD
            Array.Reverse(Arr);


            //Printing new method using for loop
            ReverseArray(Arr);
            NumberPrinter(Arr);

            Console.WriteLine("-------------------");

            //Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            //I'm following explicit intstructions here and listing the numbers INSIDE the method, i know i could also use NumberPrinter
            ThreeKiller(Arr);

            Console.WriteLine("-------------------");

            //Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(Arr);
            NumberPrinter(Arr);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //Create an integer List
            var IntList = new List<int>();

            //Print the capacity of the list to the console
            Console.WriteLine("Old Capacity");
            Console.WriteLine(IntList.Count);

            //Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(IntList);

            //Print the new capacity
            Console.WriteLine("New Capacity");
            Console.WriteLine(IntList.Count);


            Console.WriteLine("---------------------");

            //Create a method that prints if a user number is present in the list


            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");

            int userNumInt;
            string userNum = Console.ReadLine();
            bool success = int.TryParse(userNum, out userNumInt);
            if (success) {
                NumberChecker(IntList, userNumInt);
            }



            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //Print all numbers in the list
            NumberPrinter(IntList);
            Console.WriteLine("-------------------");

            //Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(IntList);
            NumberPrinter(IntList);

            Console.WriteLine("------------------");

            //Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            IntList.Sort();
            NumberPrinter(IntList);
            Console.WriteLine("------------------");

            //Convert the list to an array and store that into a variable
            int[] intListArray = IntList.ToArray();

            //Clear the list
            IntList.Clear();
            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }

            foreach (int i in numbers) { 
                Console.WriteLine(i);
            }
        }


        private static void OddKiller(List<int> numberList)
        {
            var targetValues = new List<int>();
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 == 0) {
                    targetValues.Add(numberList[i]);
                }
            }

            //collected odd values in a new list, replacing submitted value with new list
            numberList.Clear();
            foreach (int i in targetValues) { 
                numberList.Add(i);
            }

        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            bool numberFound = false;
            Console.WriteLine("checking your number....");
            foreach (int number in numberList) {
                if (number == searchNumber)
                {
                    Console.WriteLine($"Your number {searchNumber} was found in the list!");
                    numberFound = true;
                    break;
                }               
            }
            if (numberFound==false) { Console.WriteLine("Your number was not found."); }
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();

            for (int i = 0; i < 50; i++) {
                numberList.Add(rng.Next(51));
            }
        }

        private static void Populater(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++) {
                Random rng = new Random();
                numbers[i] = rng.Next(51);
            }
        }        

        private static void ReverseArray(int[] array)
        {
            //non destructively create a dummy array
            int[] newArray = new int[50]; 
            //assign reversed values from array submitted as argument to new array
            for (int i = 0; i < array.Length; i++) {
                newArray[i] = array[array.Length-1-i];
            }
            //replace argument values with new array values
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = newArray[i];
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
