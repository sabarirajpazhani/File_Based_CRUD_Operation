using System;

namespace File_Based_CRUD_Operation
{
    
    public class Program
    {
        public static int EmpID = 104;
        static void Main(string[] args)
        {  

            while (true)
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
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                              Enter '1' to create a new employee                             ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

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


                    case 2:

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                              Enter '2' to View all the Employee                             ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                                Here are the Employee details                                ");

                        if (File.Exists(FilePath))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            Console.ResetColor();

                            Console.WriteLine(
                                $"{"Employee ID",-20}" +
                                $"{"Employee Name",-25}" +
                                $"{"Department",-20}" +
                                $"{"Salary",-15}"
                            );

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            Console.ResetColor();



                            foreach (string list in File.ReadLines(FilePath))
                            {
                                string[] EmpDetails = list.Split(',');

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine(
                                       $"{EmpDetails[0],-20}" +
                                       $"{EmpDetails[1],-25}" +
                                       $"{EmpDetails[2],-20}" +
                                       $"{EmpDetails[3],-15}"
                                );
                                Console.ResetColor();
                            }


                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("---------------------------------------------------------------------------------------------");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("File Not Found");
                            Console.ResetColor();
                        }

                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                           Enter '3' to View Particular Employee                             ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Employee ID : ");
                        Console.ResetColor();
                        string Empid = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"                  Here are the Employee details for Employee - {Empid}                      ");



                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        Console.WriteLine(
                            $"{"Employee ID",-20}" +
                            $"{"Employee Name",-25}" +
                            $"{"Department",-20}" +
                            $"{"Salary",-15}"
                        );

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        foreach (string list in File.ReadLines(FilePath))
                        {
                            string[] EmpDetails = list.Split(',');

                            if (EmpDetails[0] == Empid)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine(
                                       $"{EmpDetails[0],-20}" +
                                       $"{EmpDetails[1],-25}" +
                                       $"{EmpDetails[2],-20}" +
                                       $"{EmpDetails[3],-15}"
                                );
                                Console.ResetColor();
                            }
                            else
                            {
                                continue;
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        Console.WriteLine();

                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                        Enter '4' to Update the Particular Employee                          ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        if(File.Exists(FilePath))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Employee ID for Update : ");
                            Console.ResetColor();
                            string empid = Console.ReadLine();

                            while (true)
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("                         -------- Enter the choice for Updating --------                     ");
                                Console.ResetColor();
                                Console.WriteLine("                                      1. Update the Name                                     ");
                                Console.WriteLine("                                      2. Update the Department                               ");
                                Console.WriteLine("                                      3. Update the Salary                                   ");
                                Console.WriteLine("                                      4. Exit                                                ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("                         -----------------------------------------------                     ");
                                Console.ResetColor();
                                Console.WriteLine();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Enter the Choice for Updating : ");
                                Console.ResetColor();
                                int choice = int.Parse(Console.ReadLine());

                                List<String> lines = new List<string>(File.ReadAllLines(FilePath));

                                if(choice == 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Thank You :)");
                                    Console.ResetColor();
                                }

                                for(int i = 0; i<lines.Count; i++)
                                {
                                    string[] list = lines[i].Split(',');
                                    if (list[0] == empid)
                                    {
                                        if (choice == 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Enter the Updated Name            : ");
                                            Console.ResetColor();
                                            string empName = Console.ReadLine();
                                            list[1] = empName;

                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine("Name has been updated successfully");
                                            Console.ResetColor();
                                            Console.WriteLine();


                                        }
                                        else if (choice == 2)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Enter the Updated Department      : ");
                                            Console.ResetColor();
                                            string empDepartment = Console.ReadLine();
                                            list[2] = empDepartment;

                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine("Department has been updated successfully");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                        }
                                        else if (choice == 3)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Enter the Updated Salary          : ");
                                            Console.ResetColor();
                                            string empSalary = Console.ReadLine();
                                            list[3] = empSalary;

                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine("Salary has been updated successfully");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                        }
                                        

                                        lines[i] = string.Join(',', list);
                                        File.WriteAllLines(FilePath, lines);
                                    }

                                }
                                if (choice == 4)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("File Not Found");
                            Console.ResetColor();
                        }
                        Console.WriteLine();
                        break;


                }
            }
        }
    }
}