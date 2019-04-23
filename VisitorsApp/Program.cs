using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppContext())
            {
                while (true)
                {
                    Console.WriteLine("Что вы хотите сделать?");
                    Console.WriteLine("1)Просмотреть посетителей");
                    Console.WriteLine("2)Добавить посетителя");
                    Console.WriteLine("3)Выйти");
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        if (choice == 1)
                        {
                            var visitors = (from visitor in context.Visitors
                                           select visitor).ToList();
                            if (visitors.Count > 0)
                            {
                                foreach (var visitor in visitors)
                                {
                                    Console.WriteLine($"Имя: {visitor.Name}");
                                    Console.WriteLine($"Номер удостоверения: {visitor.CertificateNumber}");
                                    Console.WriteLine($"Вошел: {visitor.EnterTime.Hour}:{visitor.EnterTime.Minute}");
                                    Console.WriteLine($"Вышел: {visitor.ExitTime.Hour}:{visitor.ExitTime.Minute}");
                                    Console.WriteLine($"Цель посещения - {visitor.VisitPurpose}");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Посетителей нет");
                            }
                        }
                        else if (choice == 2)
                        {
                            Visitor visitor = new Visitor();
                            Console.WriteLine("Введите имя посетителя");
                            while (true)
                            {
                                visitor.Name = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(visitor.Name))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                            }
                            Console.WriteLine("Введите номер удостоверения посетителя");
                            while (true)
                            {
                                if (int.TryParse(Console.ReadLine(), out int certificateNumber) && certificateNumber > 0)
                                {
                                    visitor.CertificateNumber = certificateNumber;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                            }
                            Console.WriteLine("Введите время, когда посетитель вошел");
                            while (true)
                            {
                                Console.Write("Часы: ");
                                if (int.TryParse(Console.ReadLine(), out int hours) && hours >= 0 && hours <= 23)
                                {
                                    Console.Write("Минуты: ");
                                    if (int.TryParse(Console.ReadLine(), out int minutes) && minutes >= 0 && minutes <= 59)
                                    {
                                        visitor.EnterTime = new DateTime(1, 1, 1, hours, minutes, 0);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный ввод");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                            }
                            Console.WriteLine("Введите время, когда посетитель вышел");
                            while (true)
                            {
                                Console.Write("Часы: ");
                                if (int.TryParse(Console.ReadLine(), out int hours) && hours >= 0 && hours <= 23)
                                {
                                    Console.Write("Минуты: ");
                                    if (int.TryParse(Console.ReadLine(), out int minutes) && minutes >= 0 && minutes <= 59)
                                    {
                                        visitor.ExitTime = new DateTime(1, 1, 1, hours, minutes, 0);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный ввод");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                            }
                            Console.WriteLine("Введите цель посещения");
                            while (true)
                            {
                                visitor.VisitPurpose = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(visitor.VisitPurpose))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                            }
                            context.Visitors.Add(visitor);
                            context.SaveChanges();
                        }
                        else if (choice == 3)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }
            }
        }
    }
}
