using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Series_analyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {          
            Menu(args);
        }
        static void Menu(string[] arg)//Show to user the option and instructions
        {
            List<double> SeriesList;

            
            string arg1 = string.Join(" ", arg);

            if (!(Checked_if_all_positive_number_and3(arg1)))
            {
                Colorprint("Nothing was entered in args or it is an incorrect value)");

                SeriesList = input();
            }
            else
            {
                SeriesList = ConvertToIntList(arg1);
            }

                 


            bool check_exit = true;

            
                do
                {
                    Colorprint("------------------------welcome---------------------------");
                    Console.WriteLine(
                        "\n Select the action you want to perform" +
                        "\n press 0--To insert a new series (or replace the existing series)" +
                        "\n Press 1--For Print the series in the order it was entered. " +
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
                        case "0":
                            SeriesList = input();
                            break;
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
                            Console.WriteLine($"The max number is- {FindMax(SeriesList)}");
                            break;
                        case "5":
                            Console.WriteLine($"The min number is- {FindMin(SeriesList)}");
                            break;
                        case "6":
                            Console.WriteLine(Average(SeriesList));
                            break;
                        case "7":
                            Console.WriteLine(ShowSumOfElment(SeriesList));
                            break;
                        case "8":
                            check_exit = false;
                            break;

                    }

                } while (check_exit);
            }
       
        static List<double> input()
        {
            Console.WriteLine("Please enter at least 3 Pםדן numbers (Thank you) '~'");
            string inpute_check = Console.ReadLine();

            bool number_ok;

            number_ok = Checked_if_all_positive_number_and3(inpute_check);

            while (!(number_ok))
            {
                Colorprint("Invalid input !!!\nEnter 3 numbers in the field Positive numbers");

                inpute_check = Console.ReadLine();
                number_ok = ((Checked_if_all_positive_number_and3(inpute_check)));

            }
            List<double> input_cleen = new List<double>();
            Print(input_cleen);//
            input_cleen = ConvertToIntList(inpute_check);

            return input_cleen;



        }
       
        static List<double> ConvertToIntList(string String_check)
        {
            List<double> list = new List<double>();

            //if (String_check is string[] String_check1)//In case check args
            //{
            //    Console.WriteLine(  "dsjjk88888888888888888");
            //    for (int i = 0; i < String_check1.Length; i++)
            //    {
            //        list.Add(double.Parse(String_check1[i]));
            //    }
            //}
            //else if (String_check is string String_check2)
            //{
                string[] StringArry = String_check.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < StringArry.Length; i++)
                {
                    list.Add(double.Parse(StringArry[i]));
                }


            //}

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
            List<double> newlist = new List<double>();

            int length = FindNumberOfElement(series);

            for (int i = length - 1; i >= 0; i--)
            {
                newlist.Add(series[i]);

            }
            return newlist;
        }
        static List<double> SortOrder(List<double> series)  //3 Return the series sort 
        {
            List<double> copy = new List<double>(series);
            copy.Sort();
            return copy;
        }

        static double FindMax(List<double> series)     //4Find the max value in series
        {


            double max = series[0];
            for (int i = 0; i < FindNumberOfElement(series); i++)
            {
                if (max < series[i])
                    max = series[i];
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
            foreach (int i in series)
            {
                averge += i;
            }
            return averge / FindNumberOfElement(series);
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
        /*get:List<double>
         * set:null
         * explain-:The function get a list and prints them.
         */
        static void Print(List<double> series)
        {
            foreach (int i in series)
                Console.Write(i.ToString().PadLeft(5));
            Console.WriteLine();

        }
        //****************************************Validate Function*******************************
        static bool Checked_if_all_positive_number_and3(string check_number)
        {

            string[] check = check_number.Split(' ', StringSplitOptions.RemoveEmptyEntries);//ללמודיותר שישי לי זמו מה זה בדיוק עושה
            if (check.Length < 3)

            {
                return false;
            }
            foreach (string i in check)
            {
                if ((!double.TryParse(i, out double number)) || number < 0)
                    return false;
            }

            return true;

        }
        static string Validate18()
        {
            bool chek = false;
            string validate_string_1_8;
            do
            {
                validate_string_1_8 = Console.ReadLine();
                chek = false;
                if (!(validate_string_1_8 == "1" || validate_string_1_8 == "2" || validate_string_1_8 == "3" || validate_string_1_8 == "4" || validate_string_1_8 == "5" || validate_string_1_8 == "6" || validate_string_1_8 == "7" || validate_string_1_8 == "8" || validate_string_1_8 == "0"))
                {
                    Colorprint("Invalid input, try again.\n Only between 1 and 8");
                    chek = true;
                }
            } while (chek);


            return validate_string_1_8;
        }



    }
}

