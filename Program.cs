using System;

namespace ToDo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            while(isWorking) 
            {
                List<string> morningTasks = new List<string> {"Wake up early and stretch",  "Drink a glass of water", "Eat a healthy breakfast"};
                List<string> afternoonTasks = new List<string> {"Complete top 3 tasks of the day",  "Take short breaks between work/study", "Check and reply to important messages"};
                List<string> eveningTasks = new List<string> {"Exercise or go for a walk",  "Have a light, healthy dinner", "Relax (read, listen to music, or watch something)"};
                
                Console.WriteLine("Choose one of the options");
                Console.WriteLine("1. See my ToDo List for this part of the day.");
                Console.WriteLine("2. See my ToDo List for the all day.");
                
                if(int.TryParse(Console.ReadLine(), out int inputNumber))
                {
                     DateTime currentDate = DateTime.Now;
                     Console.WriteLine($"Current date and time: {currentDate}\n");
                    if (inputNumber == 1)
                    {
                        // TimeOnly currentTime = new TimeOnly.Now;
                        TimeSpan currentTime = currentDate.TimeOfDay;
                        TimeSpan morningStart = new TimeSpan(6, 0, 0);
                        TimeSpan morningEnd = new TimeSpan(12, 0, 0);
                        TimeSpan afternoonEnd = new TimeSpan(16, 0, 0);
                        TimeSpan eveningEnd = new TimeSpan(22, 0, 0);

                        if (currentTime >= morningStart && currentTime <= morningEnd)
                        {
                            Console.WriteLine("Your ToDo list for morning is: \n");
                            foreach (string task in morningTasks)
                            {
                                int taskIndex = morningTasks.IndexOf(task) + 1;
                                Console.WriteLine(taskIndex + ". " + task);
                                isWorking = false;
                            }
                        }

                        else if (currentTime > morningEnd && currentTime <= afternoonEnd)
                        {
                            Console.WriteLine("Your ToDo list for afternoon is: \n");
                            foreach (string task in afternoonTasks)
                            {
                                int taskIndex = afternoonTasks.IndexOf(task) + 1;
                                Console.WriteLine(taskIndex + ". " + task);
                                isWorking = false;
                            }
                        }

                        else if (currentTime > afternoonEnd && currentTime <= eveningEnd)
                        {
                            Console.WriteLine("Your ToDo list for evening is: \n");
                            foreach (string task in eveningTasks)
                            {
                                int taskIndex = eveningTasks.IndexOf(task) + 1;
                                Console.WriteLine(taskIndex + ". " + task);
                                isWorking = false;
                            }
                        }

                        else
                        {
                            Console.WriteLine("It's night! Go sleep!!!");
                            isWorking = false;
                        }
                    }
                    else if (inputNumber == 2)
                    {
                        Console.WriteLine($"Your ToDo list for all the day is: \n");
                        List<string> combinedList = morningTasks.Concat(afternoonTasks).Concat(eveningTasks).ToList();
                        foreach (string task in combinedList)
                            {
                                int taskIndex = combinedList.IndexOf(task) + 1;
                                Console.WriteLine(taskIndex + ". " + task);
                                isWorking = false;
                            }
                    }
                    
                    else
                    {
                        Console.WriteLine("You have to input 1 or 2!!!\n Try Again!");
                    }
                }
                else
                    {
                        Console.WriteLine("You have to input 1 or 2!!!\n Try Again!");
                    }
            }
        }
    }
}