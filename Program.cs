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
        /*get:arry of strings
         * set:-
         * explain:"The function checks whether the array has at least three positive numbers.
         * If not, it sends to the inpute function. 
         * Then, it asks the user to choose an action."
         */
        static void Menu(string[] arg)
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
                SeriesList = ConvertDoubleList(arg1);
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
        /*get:-
         *set:List<double>
         *explain:A function asks for input
         *, then checks if it is valid by sending it to a validation function.
         *If the input is invalid, it asks again. 
         *If the input is valid, it converts the input to a list and 
         *returns the list.
         */
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
            Print(input_cleen);
            input_cleen = ConvertDoubleList(inpute_check);

            return input_cleen;

        }
        /* get:     string sentence
         * set:     list<double>
         * explain: Convert from string to list
         * 
         */
        static List<double> ConvertDoubleList(string String_check)
        {
            List<double> list = new List<double>();
            string[] StringArry = String_check.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < StringArry.Length; i++)
            {
                list.Add(double.Parse(StringArry[i]));
            }
            return list;

        }
        /*get:string sentence
         *set:-
         *explian:get a sentence and prints it in red
         * 
         */
        static void Colorprint(string sentence)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(sentence);
            Console.ResetColor();

        }
        /*get:   List<double>
         *set:   List<double>
         *explain:return the series in the order it was enter
         */
        static List<double> InOrder(List<double> series)
        {
            return series;
        }
        /*Get:     List<double>
         *Set:     reverse list
         *explain: Reverses the order of the list and sends it.
            */
        static List<double> ReversOrder(List<double> series)
        {
            List<double> newlist = new List<double>();

            int length = FindNumberOfElement(series);

            for (int i = length - 1; i >= 0; i--)
            {
                newlist.Add(series[i]);

            }
            return newlist;
        }
        /*get:     List<double>
         *set:     List arranged in ascending order
         *explain: Sort the list and send it.
         */
        static List<double> SortOrder(List<double> series)
        {
         


            int length = FindNumberOfElement(series);
            bool check_order;           
            for (int i = 0;i<length;i++)
            {
                check_order = false;
                for (int j = 0;j<length-i-1;i++)
                {
                    if (series[i] > series[j + 1])
                    {

                        
                        check_order = true;
                        
                        double temp=series[j];
                        series[j]=series[1+j];
                        series[j+1]=temp;
                    }
                }
                if (!check_order)
                {
                    break;
                }
            }
            
            return series;

        }
        /*get:      List<double>
         *set:      The max number
         *explain:  Find the min value in series and send it 
         */
        static double FindMax(List<double> series)
        {
            double max = series[0];
            for (int i = 0; i < FindNumberOfElement(series); i++)
            {
                if (max < series[i])
                    max = series[i];
            }
            return max;

        }
        /*get:     List<double>
         *set:     The min number
         *explain: Find the min value in series and send it
         */
        static double FindMin(List<double> series)
        {
            double min = series[0];
            for (int i = 0; i < FindNumberOfElement(series); i++)
            {
                if (min > series[i])
                    min = series[i];
            }
            return min;

        }
        /*get:     List<double>
         *set:     The average
         *explain: Calculates the average of the list and send it
         */
        static double Average(List<double> series)
        {
            double averge = 0;
            foreach (double i in series)
            {
                averge += i;
            }
            return averge / FindNumberOfElement(series);
        }
        /*get:     List<double>
         *set:     Length of list
         *explain: Calculates the length of the list and send the result
         */
        static int FindNumberOfElement(List<double> series)//
        {
            int count = 0;
            foreach (int i in series)
                count++;
            return count;

        }
        /*get:     List<double>
         *set:     the sum of all the numbers
         *explain: Adds all the numbers and sends the result.
         */
        static double ShowSumOfElment(List<double> series)//
        {
            double count = 0;
            foreach (double item in series)
            {
                count += item;

            }
            return count;
        }
        /* get:     List<double>
         * set:     null
         * explain: The function  a list and prints them.
         */
        static void Print(List<double> series)
        {
            foreach (double i in series)
                Console.Write(i.ToString() + "  ");
            Console.WriteLine();

        }
        //****************************************Validate Function*******************************

        /*
         *get:     string
         *set :    bool
         *explain: Checks if all numbers are positive
         */
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
        /*get:-
         * set:string
         * explain:Makes sure all numbers are 0 to 8
         */
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

