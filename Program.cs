using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Series_analyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }

            List <int> list_args = ConvertToIntList(args);
            Menu(args);
        }
        static void Menu(string[] SeriesList)//Show to user the option and instructions
        {

            bool check_exit = true;
            do
            {
                Colorprint("----------------------welcome-----------------------");
                Console.WriteLine(
                    "\n Select the action you want to perform" +
                    "\n Press 1-- for Print the series in the order it was entered. " +
                    "\n press 2--Print the series in the reversorder it was " +
                    "\n Press 3--Print the series sort." +
                    "\n Press 4--Print the max value in series " +
                    "\n Press 5--Print the min value in series " +
                    "\n Press 6--Print the average of the series  " +
                    "\n Press 7--Print the some of the series \n Press 8=Exit");


                string chose = Validate18();
                Console.WriteLine( chose );

                switch (chose)
                {
                    case "1":
                        PrintInOrder(SeriesList);
                        break;
                    case "2":
                        PrintReversOrder(SeriesList);
                        break;
                    case "3":
                        PrintSortOrder(SeriesList);
                        break;
                    case "4":
                        FinfwMaximum(SeriesList);
                        break;
                    case "5":
                        FindMin(SeriesList);
                        break;
                    case "6":
                        Average(SeriesList);
                        break;
                    case "7":
                        ShowSumOfElment(SeriesList);
                        break;
                    case "8":
                        check_exit = false;
                        break;

                } 

            } while (check_exit);
        }
        static string Validate18()
        {
            string validate_string_1_8 = Console.ReadLine();


            return validate_string_1_8;
        }
        static List<int> ConvertToIntList(string[] StringArry)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < StringArry.Length; i++)
            {
                list.Add(int.Parse(StringArry[i]));
            }

            return list;

        }

        
      
        static void Colorprint(string sentence)        //Change color for emphasize the  sentence
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(sentence);
            Console.ResetColor();

        }
        static void PrintInOrder(string[] sentence)     //1Print the series in the order it was entered
        {
            Console.WriteLine();
        }
        static void PrintReversOrder(string[] sentence) //2Print the series in the reversorder it was
        {
            Console.WriteLine();
        }
        static void PrintSortOrder(string[] sentence)  //3Print the series sort 
        { }

        static void FinfwMaximum(string[] sentence)     //4Print the max value in series
        { }
        static void FindMin(string[] sentence)        //5Print the min value in series
        { }
        static void Average(string[] sentence)                    //6Print the average of the series 
        { }
        static void FindNumberOfElement(string[] sentence)//
        {

        }
        static void ShowSumOfElment(string[] sentence)//7Print the some of the series 
        {

        }
    }
}
