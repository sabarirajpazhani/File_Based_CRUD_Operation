using System;

namespace File_Based_CRUD_Operation
{
    public class Program
    {
        public static int EmpID = 104;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("---------------------- File Based Curd Operation (Employee Management) ----------------------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("                                1. Add the Employee                                          ");
            Console.WriteLine("                                2. View all the Employee                                     ");
            Console.WriteLine("                                3. View Particular Employee By ID                            ");
            Console.WriteLine("                                4. Update the Employee                                       ");
            Console.WriteLine("                                5. Delete the Employee                                       ");
            Console.WriteLine("                                6. Exit                                                      ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.ResetColor();

            int Choice = 0;

            string FilePath = @"D:\FileHandling\Employee.txt";

            Choice:
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Enter the Choice : ");
                Console.ResetColor();
                int choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Choice! Choice must not be Zero.");
                    Console.ResetColor();
                    goto Choice;
                }
                if (choice > 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Choice! Please enter a number between 1 and 6.");
                    Console.ResetColor();
                    goto Choice;
                }

                Choice = choice;
            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter the choice using digits only—no letters, symbols, or whitespace.");
                Console.ResetColor();
                goto Choice;
            }
            catch (OverflowException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please enter a valid option.");
                Console.ResetColor();
                goto Choice;
            }

            switch (Choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter the Employee Name : ");
                    Console.ResetColor();
                    string EmployeeName = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter the Department : ");
                    Console.ResetColor();
                    string Department = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter the Salary : ");
                    Console.ResetColor();
                    int Salary = int.Parse(Console.ReadLine());

                    EmpID++;

                    string details = $"{EmpID},{EmployeeName},{Department},{Salary}";

                    if (File.Exists(FilePath))
                    {
                        using (StreamWriter sw = File.AppendText(FilePath))
                        {
                            sw.WriteLine(details);

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("                 * --------------- Registered Student --------------- *                      ");
                            Console.ResetColor();

                            Console.WriteLine($"                              Employee ID     : {EmpID}");
                            Console.WriteLine($"                              Employee Name   : {EmployeeName}");
                            Console.WriteLine($"                              Employe Deparment : {Department}");
                            Console.WriteLine($"                              Emloyee Salary    : {Salary}");

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("                 ------------------------------------------------------                      ");
                            Console.ResetColor();

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Employee ID -{EmpID} is Successfully Added");
                            Console.WriteLine();
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("File Not Found");
                        Console.ResetColor();
                    }

                    break;



            }
        }
    }
}