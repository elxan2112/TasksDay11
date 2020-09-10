using System;

namespace Test5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать. Давайте начнем.");
            for (; ; )
            {
                Console.Write("Информацию о скольких людях вы хотите внести либо проверить?: ");
                int verb1 = Input.NumsInput();
                Console.WriteLine("Для продолжения нажмите на любую клавишу!");
                Console.ReadKey();
                for (; ; )
                {
                    Console.WriteLine("Меню.");
                    Console.WriteLine("1.Ввод данных.\n2.Вывод информации о всех студентах.\n3.Вывод информации о всех аспирантах.\n4.Изменить количество людей или выйти из программы.");
                    string select1 = Input.WordInput();
                    if (select1 == "1")
                    {
                        Console.WriteLine("Чьи данные вы хотите ввести? Студента (S) или аспирант(A)?");
                        string selection = Input.WordInput();
                        for (; ; )
                        {
                            for (; ; )
                            {

                                if (selection == "A")
                                {

                                    Aspirants alk = new Aspirants();
                                    for (int i = 0; i < verb1; i++)
                                    {
                                        Console.WriteLine($"Информация {i + 1}-го аспиранта:");
                                        alk[i] = new Aspirant("", 1, 1, "");
                                    }
                                    Console.WriteLine("Для выхода в меню, нажмите на любую клавишу!");
                                    Console.ReadKey();
                                    break;
                                }
                                if (selection == "S")
                                {
                                    Students ark = new Students();
                                    for (int i = 0; i < verb1; i++)
                                    {
                                        Console.WriteLine($"Информация {i + 1}-го студента:");
                                        ark[i] = new Student("", 1, 1);
                                    }
                                    Console.WriteLine("Для выхода в меню, нажмите на любую клавишу!");
                                    Console.ReadKey();
                                    break;
                                }
                            }
                            break;
                        }
                        continue;
                    }
                    if (select1 == "2")
                    {
                        for (int i = 0; i < verb1; i++)
                        {
                            Console.WriteLine($"Информация о {i + 1}-м студенте:");
                            Students.data[i].Print();
                        }
                        Console.WriteLine("Для выхода в меню, нажмите на любую клавишу!");
                        Console.ReadKey();
                        continue;
                    }
                    if (select1 == "3")
                    {
                        for (int i = 0; i < verb1; i++)
                        {
                            Console.WriteLine($"Информация о {i + 1}-м аспиранте:");
                            Aspirants.data[i].Print();
                        }
                        Console.WriteLine("Для выхода в меню, нажмите на любую клавишу!");
                        Console.ReadKey();
                        continue;
                    }
                    if (select1 == "4")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы нажали неизвестную букву или неверную цифру!");
                        continue;
                    }

                }
                Console.WriteLine("1.Изменить количество людей.\n2.Выйти из программы");
                string slct = Input.WordInput();
                if (slct == "1")
                    continue;
                else if (slct == "2")
                    break;
                else
                {
                    Console.WriteLine("Вы нажали неизвестную букву или неверную цифру!");
                    continue;
                }
            }
        }
    }
    class Students
    {
        static public Student[] data;
        public Students()
        {
            data = new Student[100];
        }
        public Student this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }
    class Student
    {
        public string Surname { get; set; }
        public int Course { get; set; }
        public int StudentsRecordBook { get; set; }
        public Student(string sur, int cour, int srb)
        {
            Console.Write("Введите фамилию студента: ");
            Surname = Input.WordInput();
            Console.Write("Введите курс на котором учится студент: ");
            Course = Input.CourseInput();
            Console.Write("Введите номер зачетной гинижки: ");
            StudentsRecordBook = Input.NumsInput();
        }

        public virtual void Print()
        {
            Console.WriteLine($"Студент: {Surname}.\nКурс: {Course}-й.\nЗачетная книжка №: {StudentsRecordBook}");
        }
    }
    class Aspirants
    {
        static public Aspirant[] data;
        public Aspirants()
        {
            data = new Aspirant[100];
        }
        public Aspirant this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }
    class Aspirant : Student
    {
        public string Topic { get; set; }
        public Aspirant(string sur, int cour, int srb, string topic) : base(sur, cour, srb)
        {
            Console.Write("Введите название кандитатской диссертации: ");
            Topic = Input.WordInput();
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Название кандитатской диссертации: {Topic}");
        }
    }
    class Input
    {
        public static string WordInput()
        {
            string word = Console.ReadLine();
            return word;
        }
        public static int CourseInput()
        {
            int nums = 0;
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out nums))
            {
                if (nums > 0 && nums < 5)
                    return nums;
                else
                {
                    Console.WriteLine("Введите число от 1 до 4");
                    return CourseInput();
                }
            }
            else
            {
                Console.WriteLine("Введите число!");
                return CourseInput();
            }
        }
        public static int NumsInput()
        {
            int nums = 0;

            string input = Console.ReadLine();
            if (Int32.TryParse(input, out nums))
            {
                if (nums > 0)
                    return nums;
                else
                {
                    Console.WriteLine("Введите положительное число!");
                    return NumsInput();
                }
            }
            else
            {
                Console.WriteLine("Введите число!");
                return NumsInput();
            }
        }
    }
}
