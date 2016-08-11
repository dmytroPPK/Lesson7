using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson7.Employees;


namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            DB.InitDB();
            program.Run();
                                   
        }

        private void Run()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            this.ShowMenu();
            // Delay
            Console.ReadKey();
            
        }

        private void ShowMenu()
        {
            int flagPointer = 0;
            bool flagOut = false;
            while (!flagOut)
            {
                Console.WriteLine(Helper.MenuText);
                Helper.IntegerValid(ref flagPointer, "\nНомер пункта: ");
                switch (flagPointer)
                {
                    case 1:
                        flagOut = true;
                        Console.Clear();
                        this.ShowAllList();
                        break;
                    case 2:
                        flagOut = true;
                        Console.Clear();
                        this.ShowEmployees();
                        break;
                    case 3:
                        flagOut = true;
                        Console.Clear();
                        this.ShowTrainees();
                        break;
                    case 4:
                        flagOut= true;
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Clear();
                        continue;
                }
            }
        }


        private void ValidCheckedPerson()
        {
            int IdPerson=0;
            Helper.IntegerValid(ref IdPerson, "\nВведите Id работника: ");
            var query = (from emp in DB.Employees
                         where emp.UId == IdPerson
                         select emp).ToList();
            if (query.Count == 0)
            {
                Console.WriteLine("неверно указан Id работника. В базе не найден");
                Console.Write("Нажмите любую клавишу для перехода в главное меню");
                Console.ReadKey();
                Console.Clear();
                this.ShowMenu();
            }
            else
            {
                this.CheckPersonType(query[0]);
                this.Promt();
            }
        }
        
        private void Promt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int flagPointer = 0;
            bool flagOut = false;
            while (!flagOut)
            {
                Console.WriteLine("\n"+Helper.PromptText);
                
                Helper.IntegerValid(ref flagPointer, "\nВаш выбор: ");
                switch (flagPointer)
                {
                    case 1:
                        flagOut = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        this.ShowMenu();
                        break;
                    case 2:
                        flagOut = true;
                        this.ValidCheckedPerson();
                        break;
                    case 3:
                        flagOut = true;
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        continue;
                }
            }

            
        }
        private void ShowEmployees()
        {
            var query = from emp in DB.Employees
                        where emp.IsTrainee == false
                        orderby emp.UId
                        select emp;
            string formatString = Helper.StrFormat1;
            foreach (var emp in query)
            {
                Console.WriteLine(formatString, emp.UId, emp.Name, emp.Age, emp.PaidOfMonth());
            }
            this.Promt();
        }

        private void ShowTrainees()
        {
            var query = from emp in DB.Employees
                        where emp.IsTrainee == true
                        orderby emp.UId
                        select emp;
            string formatString = Helper.StrFormat1;
            foreach (var emp in query)
            {
                Console.WriteLine(formatString, emp.UId, emp.Name, emp.Age, emp.PaidOfMonth());
            }
            this.Promt();
        }

        private void CheckPersonType(Employee emp)  
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            if (emp is Worker)
            {
                Console.WriteLine("\t<<- "+emp.GetType().Name+" ->>\n");
                Console.WriteLine((emp as Worker).ToString());
            }
            else if (emp is Doctor)
            {
                Console.WriteLine("\t<<- " + emp.GetType().Name + " ->>\n");
                Console.WriteLine((emp as Doctor).ToString());
            }
            else if (emp is Watchman )
            {
                Console.WriteLine("\t<<- " + emp.GetType().Name + " ->>\n");
                Console.WriteLine((emp as Watchman).ToString());
            }
            else if (emp is Psychologist )
            {
                Console.WriteLine("\t<<- " + emp.GetType().Name + " ->>\n");
                Console.WriteLine((emp as Psychologist).ToString());
            }
            else
            {
                throw new Exception("Wow, is it bullshit? ) Yep. game over");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void ShowAllList()
        {
            string formatString = Helper.StrFormat1;
            foreach (var emp in  DB.Employees)
            {
                Console.WriteLine(formatString, emp.UId,emp.Name,emp.Age,emp.PaidOfMonth());
            }
            this.Promt();
        }
    }
    static class DB
    {
        public static List<Employee> Employees { get; private set; }
        public static void InitDB()
        {
            Employees = new List<Employee> {
                new Watchman()
                {
                    UId =1,
                    Name ="Alex",
                    Age = 54,
                    HoursOfDay = 20,
                    HoursOfNight = 15,
                    EperienceYears = 34,
                    PremiumHoursDay = 5,
                    PremiumHoursNight =4,
                    PaidOfHour = 15
                },
                new Watchman(trainee:true)
                {
                    UId = 2,
                    Name ="Boris",
                    Age = 19,
                    HoursOfDay = 14,
                    HoursOfNight = 26,
                    EperienceYears = 1,
                    PremiumHoursDay = 2,
                    PremiumHoursNight =8,
                    PaidOfHour = 9
                    
                },
                new Worker()
                {
                    UId = 5,
                    Name ="Jonny",
                    Age = 57,
                    PaidOfHour = 36,
                    EperienceYears =35,
                    HoursOfMonth = 45,
                    OverOfHours = 10,
                    PremiumHours = 5
                },
                new Worker(trainee:true)
                {
                    UId = 6,
                    Name ="Tommy",
                    Age = 21,
                    PaidOfHour = 23,
                    EperienceYears =3,
                    HoursOfMonth = 30,
                    OverOfHours = 2,
                    PremiumHours = 2
                },
                new Doctor()
                {
                    UId = 8,
                    Name ="Kvin",
                    Age = 57,
                    PaidOfHour = 59,
                    EperienceYears =30,
                    HoursOfMonth = 50,
                    PremiumHours = 4,
                    BonusPaid = 120,
                    CountOfTreated =14
                },
                new Doctor(trainee:true)
                {
                    UId = 10,
                    Name ="Barbara",
                    Age = 26,
                    PaidOfHour = 37,
                    EperienceYears =3,
                    HoursOfMonth = 38,
                    PremiumHours = 4,
                    BonusPaid = 50,
                    CountOfTreated =5
                },
                new Psychologist()
                {
                    UId = 12,
                    Name ="Juliya",
                    Age = 42,
                    PaidOfHour = 70,
                    EperienceYears =16,
                    HoursOfMonth = 36,
                    PremiumHours = 4,
                    CountOverPatient=16
                },
                new Psychologist(trainee:true)
                {
                    UId = 15,
                    Name ="Veronika",
                    Age = 24,
                    PaidOfHour = 35,
                    EperienceYears =1,
                    HoursOfMonth = 25,
                    PremiumHours = 2,
                    CountOverPatient=6
                },
                new Watchman()
                {
                    UId = 4,
                    Name ="Mike",
                    Age = 49,
                    HoursOfDay = 34,
                    HoursOfNight = 43,
                    EperienceYears = 20,
                    PremiumHoursDay = 7,
                    PremiumHoursNight =10,
                    PaidOfHour = 15
                },
                new Worker(trainee:true)
                {
                    UId = 7,
                    Name ="Nelly",
                    Age = 18,
                    PaidOfHour = 17,
                    EperienceYears =1,
                    HoursOfMonth = 25,
                    OverOfHours = 1,
                    PremiumHours = 3
                },
                new Watchman(trainee:true)
                {
                    UId = 3,
                    Name ="Petrosyan",
                    Age = 21,
                    HoursOfDay = 17,
                    HoursOfNight = 24,
                    EperienceYears = 2,
                    PremiumHoursDay = 4,
                    PremiumHoursNight =6,
                    PaidOfHour = 11
                },
            };
        }
    }
    static class Helper
    {
        private static string _menuText = @"1. Список всех работников
2. Список работников
3. Список стажоров
4. Выход";
        
        private static string _promptText = @"   1. В главное меню
   2. Выбрать работника для рассчета зарплаты
   3. Выход из программы";
        public static string infoWorker = @"  Имя {0}, Возраст {1} Стаж {2}
  Бонусы: {3} долл
  Премия: {4} долл
  Итого за месяц с основной зарплатой: {5} долл

  Доп. инфо:
    - Премиальных часов: {6}
    - Переработка часов: {7}
    - Основных часов:    {8}
    - Оплата за час:     {9} долл
  Стажер: {10}.";
        public static string infoDoctor = @"  Имя {0}, Возраст {1} Стаж {2}
  Бонусы: {3} долл
  Премия: {4} долл
  Итого за месяц с основной зарплатой: {5} долл

  Доп. инфо:
    - Премиальных часов: {6}
    - Количество выличенных: {7}
    - Сумма за выличенного: {11}
    - Основных часов:    {8}
    - Оплата за час:     {9} долл
  Стажер: {10}.";
        public static string infoWatchMan = @"  Имя {0}, Возраст {1} Стаж {2}
  Бонусы: {3} долл
  Премия: {4} долл
  Итого за месяц с основной зарплатой: {5} долл

  Доп. инфо:
    - Дневных часов: {6}
    - Ночных часов: {7}
    - Премиальных дневных часов: {8}
    - Премиальных ночных часов:    {9}
    - Оплата за час:     {10} долл
  Стажер: {11}.";
        public static string infoPsychologist = @"  Имя {0}, Возраст {1} Стаж {2}
  Бонусы: {3} долл
  Премия: {4} долл
  Итого за месяц с основной зарплатой: {5} долл

  Доп. инфо:
    - Пациентов сверх нормы: {6}
    - Коэфициент для ненормированных пациентов: {7}
    - Премиальных часов: {8}
    - Часов за месяц:    {9}
    - Оплата за час:     {10} долл
  Стажер: {11}.";
        public static string MenuText{ get { return _menuText; } }
        public static string StrFormat1 { get { return _strFormat1; } }
        private static string _strFormat1 = "UniqueID : {0,2}, Name : {1,-10}, Age : {2,2}, Paid Of Month : {3,5}";
        public static string PromptText { get { return _promptText; } }

        public static void IntegerValid(ref int outNumber, string msg = "default message")
        {
            while (true)
            {
                Console.Write(msg);
                if (Int32.TryParse(Console.ReadLine(), out outNumber))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect type of data !");
                    continue;
                }
            }
        }
    }

}
