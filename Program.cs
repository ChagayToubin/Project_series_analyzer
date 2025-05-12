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


            List<double> list_args = ConvertToIntList(args);

            Menu(list_args);
        }
        static void Menu(List<double> SeriesList)//Show to user the option and instructions
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
                        Console.WriteLine($"The max number is- { FindMax(SeriesList)}");
                        break;
                    case "5":
                        Console.WriteLine($"The max number is- {FindMin(SeriesList)}");
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
        static List<double> ConvertToIntList(string[] StringArry)
        {
            List<double> list = new List<double>();
            for (int i = 0; i < StringArry.Length; i++)
            {
                list.Add(double.Parse(StringArry[i]));
            }

            return list;

        }



        static void Colorprint(string sentence)        //Change color for emphasize the  sentence
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(sentence);
            Console.ResetColor();

        }
        static List<double> InOrder(List<double> series)     //1Print the series in the order it was entered
        {
            return series;
        }
        static List<double> ReversOrder(List<double> series) //2Print the series in the reversorder it was
        {
            List <double> newlist = new List<double>();

            int length = FindNumberOfElement(series);

            for (int i = length-1; i >=0; i--)
            {
                newlist.Add(series[i]);

            }
            return newlist;
        }
        static List<double> SortOrder(List<double> series)  //3 Return the series sort 
        {
            series.Sort();
            return series;
        }

        static double FindMax(List<double> series)     //4Find the max value in series
        {


            double max = series[0]; 
            for (int i = 0; i < FindNumberOfElement(series); i++)
            {
                if (max < series[i])
                    max= series[i];
            }
            return max;

        }
        static double FindMin(List<double> series)        //5Find the min value in series
        {
            double min = series[0];
            for (int i = 0; i < FindNumberOfElement(series); i++)
            {
                if (min > series[i])
                    min = series[i];
            }
            return min;

        }
        static double Average(List<double> series)                    //6Print the average of the series 
        {
            double averge = 0;
            foreach(int i in series)
            {
                averge += i;
            }
            return averge/FindNumberOfElement(series);
        }
        static int FindNumberOfElement(List<double> series)//
        {
            int count = 0;
            foreach (int i in series)
                count++;
            return count;

        }
        static double ShowSumOfElment(List<double> series)//7Print the some of the series 
        {
            double count = 0;
            foreach (double item in series)
            {
                count += item;

            }
            return count;
          

        }
        static List<double> input()
        {
            return null;

        }
        static void Print(List<double> series)
        {
            foreach (int i in series)
                Console.Write(i.ToString().PadLeft(5));
            Console.WriteLine( );

        }
    }
}
