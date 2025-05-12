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


            List<int> list_args = ConvertToIntList(args);

            Menu(list_args);
        }
        static void Menu(List<int> SeriesList)//Show to user the option and instructions
        {

            bool check_exit = true;
            do
            {
                Colorprint("------------------------welcome---------------------------");
                Console.WriteLine(
                    "\n Select the action you want to perform" +
                    "\n Press 1-- for Print the series in the order it was entered. " +
                    "\n press 2--Print the series in the reversorder it was " +
                    "\n Press 3--Print the series sort." +
                    "\n Press 4--Print the max value in series " +
                    "\n Press 5--Print the min value in series " +
                    "\n Press 6--Print the average of the series  " +
                    "\n Press 7--Print the some of the series " +
                    "\n Press 8=Exit");


                string chose = Validate18();


                switch (chose)
                {
                    case "1":
                        Print(InOrder(SeriesList));
                        break;
                    case "2":
                        Print(ReversOrder(SeriesList));
                        break;
                    case "3":
                        Print(SortOrder(SeriesList));
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
            bool chek = false;
            string validate_string_1_8;
            do
            {
                validate_string_1_8 = Console.ReadLine();
                chek = false;
                if (!(validate_string_1_8 == "1" || validate_string_1_8 == "2" || validate_string_1_8 == "3" || validate_string_1_8 == "4" || validate_string_1_8 == "5" || validate_string_1_8 == "6" || validate_string_1_8 == "7" || validate_string_1_8 == "8"))
                {
                    Colorprint("Invalid input, try again.\n Only between 1 and 8");
                    chek = true;
                }
            } while (chek);


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
        static List<int> InOrder(List<int> series)     //1Print the series in the order it was entered
        {
            return series;
        }
        static List<int> ReversOrder(List<int> series) //2Print the series in the reversorder it was
        {
            List <int> newlist = new List<int>();
           
            int length = ShowSumOfElment(series);

            for (int i = length-1; i >=0; i--)
            {
                newlist.Add(series[i]);

            }
            return newlist;
        }
        static List<int> SortOrder(List<int> series)  //3Print the series sort 
        {
            series.Sort();
            return series;
        }

        static void FinfwMaximum(List<int> series)     //4Print the max value in series
        { }
        static void FindMin(List<int> series)        //5Print the min value in series
        { }
        static void Average(List<int> series)                    //6Print the average of the series 
        { }
        static void FindNumberOfElement(List<int> series)//
        {

        }
        static int ShowSumOfElment(List<int> series)//7Print the some of the series 
        {
            int count = 0;
            foreach (int i in series)
                count++;
            return count;

        }
        static List<int> input()
        {
            return null;

        }
        static void Print(List<int> series)
        {
            foreach (int i in series)
                Console.Write(i.ToString().PadLeft(5));
            Console.WriteLine( );

        }
    }
}
