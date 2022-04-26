using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSolution.Services
{
    public static class UserInputValidator
    {
        public static string ValidateEmployeeCodeInput()
        {
            string userEmployeeCodeInput;
            while (true)
            {
                Start:
                Console.Write("Enter Employee Code: ");
                try
                {
                    userEmployeeCodeInput = Console.ReadLine();
                    if (userEmployeeCodeInput == null || "".Equals(userEmployeeCodeInput.Trim()))
                    {
                        Console.WriteLine($"Invalid input. Employee Code cannot be blank.\n");
                        continue;
                    }
                    if (!int.TryParse(userEmployeeCodeInput, out _))
                    {
                        Console.WriteLine($"Invalid Input. Employee Code should only contain numerical characters.\n");
                        continue;
                    }
                    foreach (char c in userEmployeeCodeInput)
                    {
                        if (char.IsLetter(c) && !char.IsDigit(c) == false)
                        {
                            Console.WriteLine("Invalid Input. Employee Code cannot contain special characters.\n");
                            goto Start;
                        }
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            Console.Write("\n");
            return userEmployeeCodeInput;
        }

        public static void PromptContinueApplication()
        {
            while (true)
            {
                Console.Write("\nEnter another search? (y/n): ");
                string userChoiceInput = Console.ReadLine();
                //Console.Write("\n");

                try
                {
                    char userChoiceInputChar = char.ToLower(Convert.ToChar(userChoiceInput));

                    switch (userChoiceInputChar)
                    {
                        case 'y':
                            Console.Clear();
                            break;
                        case 'n':
                            Console.Clear();
                            Console.Write("Press any key to exit application . . . ");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input.");
                            continue;
                    }
                    break;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Invalid input. Enter (y/n)");
                    continue;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input. Enter (y/n)");
                    continue;
                }
            }
        }
    }
}
