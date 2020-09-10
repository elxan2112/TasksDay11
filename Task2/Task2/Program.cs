using System;

namespace Test4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Добро пожаловать в <<Khan Bank>>!");
            for (; ; )
            {
                Console.WriteLine("Выберите тип счета.");
                Console.WriteLine("1. Счет физического лица. \n2. Счет юридического лица.");
                string report = "тип счета";
                int selection = SelectionInput(report);
                for (; ; )
                {
                    if (selection == 1)
                    {
                        report = "количество денег, которое вы хотите положить на ваш счет в нашем банке.";
                        int money = NumsInput(report);
                        report = "номер счета";
                        int numbers = NumsInput(report);
                        Console.WriteLine("Введите дату создания счета.");
                        int day = DayInput();
                        int month = MonthInput();
                        int year = YearsInput();
                        string date = ($"{day}.{month}.{year}");
                        BankAccount afk = new BankAccount(money, numbers, date);
                        Console.WriteLine($"Итак, на вашем счете имеется {money}azn денег. Какую из нижепересичленных операций вы хотите выполнить?");
                        Console.WriteLine("1. Начислить проценты.\n2. Снять деньги. \n3. Выход в меню.");

                        report = "любую операцию";
                        int selection1 = SelectionInput(report);
                        if (selection1 == 1)
                        {
                            Console.WriteLine("На сколько месяцев вы хотите положить деньги?");
                            report = "количество месяцев";
                            int mnth = NumsInput(report);
                            Console.WriteLine("Под какой процент вы хотите положить деньги?");
                            report = "процент";
                            int prcnt = NumsInput(report); IndividualBankAccount apk = new IndividualBankAccount(money, numbers, date, prcnt, mnth);
                            apk.AccrualOfInterest();
                        }
                        else if (selection1 == 2)
                        {

                            break;
                        }
                        else
                            break;
                    }
                    else if (selection == 2)
                    {
                        report = "количество денег, которое вы хотите положить на ваш счет в нашем банке.";
                        int money = NumsInput(report);
                    }
                    else
                        break;
                }
                break;
            }

        }
        static int NumsInput(string report)
        {
            int nums = 0;
            Console.Write($"Введите {report}: ");
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out nums))
            {
                if (nums > 0)
                    return nums;
                else
                {
                    Console.WriteLine("Введите положительно число.");
                    return NumsInput(report);
                }
            }
            else
            {
                Console.WriteLine("Введите число!");
                return NumsInput(report);
            }
        }
        static int DayInput()
        {
            int day = 0;
            Console.Write("Введите день: ");
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out day))
            {
                if (day > 0 && day < 32)
                    return day;
                else
                {
                    Console.WriteLine("Введите положительное число в диапазоне от 1 до 31.");
                    return DayInput();
                }
            }
            else
            {
                Console.WriteLine("Введите положительное число в диапазоне от 1 до 31.");
                return DayInput();
            }
        }
        static int MonthInput()
        {
            int month = 0;
            Console.Write("Введите месяц: ");
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out month))
            {
                if (month > 0 && month < 13)
                    return month;
                else
                {
                    Console.WriteLine("Всего есть 12 месяцев!");
                    return MonthInput();
                }
            }
            else
            {
                Console.WriteLine("Введите положительное число от 1 до 12");
                return MonthInput();
            }
        }
        static int YearsInput()
        {
            int years = 0;
            Console.Write("Введите год: ");
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out years))
            {
                if (years > 0)
                    return years;
                else
                {
                    Console.WriteLine("Год должен быть положительным числом");
                    return YearsInput();
                }
            }
            else
            {
                Console.WriteLine("Введите положительное число.");
                return YearsInput();
            }
        }
        static int SelectionInput(string report)
        {
            int nums = 0;
            Console.WriteLine($"Выберите {report} (1 или 2). Для возвращения в меню выберите 3.");
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out nums))
            {
                if (nums > 0 && nums < 4)
                    return nums;
                else
                {
                    Console.WriteLine("Выберите один из вышепредставленных пунктов.");
                    return SelectionInput(report);
                }
            }
            else
            {
                Console.WriteLine("Не вводите буквы.\nВыберите один из вышепредставленных пунктов.");
                return SelectionInput(report);
            }
        }
        static int SelectInput()
        {
            int nums = 0;
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out nums))
            {
                if (nums > 0 && nums < 3)
                    return nums;
                else
                {
                    Console.WriteLine("Выберите один из вышепредставленных пунктов.");
                    return SelectInput();
                }
            }
            else
            {
                Console.WriteLine("Не вводите буквы.\nВыберите один из вышепредставленных пунктов.");
                return SelectInput();
            }
        }
    }

    class BankAccount
    {
        public int MoneySumm { get; set; }
        public int AccountNum { get; set; }
        public string OpeningDate { get; set; }
        public BankAccount() { }
        public void MoneyOut()
        {
            Console.WriteLine($"На вашем счету имеется {MoneySumm}azn денег.");
        }
        public void DateOut()
        {
            Console.WriteLine($"Дата открытия вашего счета: {OpeningDate}");
        }
        public BankAccount(int mnysumm, int acntnum, string opendt)
        {
            MoneySumm = mnysumm;
            AccountNum = acntnum;
            OpeningDate = opendt;
        }

        public void OpeninDateOut()
        {
            Console.WriteLine($"Дата открытия вашего счета: {OpeningDate}");
        }

    }
    class IndividualBankAccount : BankAccount
    {
        public int Percent { get; set; }
        public int Month { get; set; }
        public readonly string accounttype = "Вид счета: Счет физического лица.";
        public IndividualBankAccount(int mnysumm, int acntnum, string opendt, int percent, int month) : base(mnysumm, acntnum, opendt)
        {
            Percent = percent;
            Month = month;
        }
        public void AccrualOfInterest()
        {

            for (int i = 0; i <= Month; i++)
            {
                Console.WriteLine(System.Math.Round((double)((MoneySumm * Percent) / 100)));
            }

        }
        public void CashOut()
        {
            Console.WriteLine($"На вашем счету {MoneySumm}azn денег");
            Console.WriteLine("Сколько денег вы хотите снять?");
            int difference = MoneyInput();
            Console.WriteLine($"Вы снляи {difference}azn. У вас осталось {MoneySumm - difference}azn");
        }
        public int MoneyInput()
        {
            int nums = 0;
            Console.Write($"Введите сумму: ");
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out nums))
            {
                if (nums > 0)
                {
                    if (nums <= MoneySumm)
                    {
                        return nums;
                    }
                    else
                    {
                        Console.WriteLine("Вы не можете снять больше денег чем вы имеете.");
                        return MoneyInput();
                    }
                }
                else
                {
                    Console.WriteLine("Введите положительно число.");
                    return MoneyInput();
                }
            }
            else
            {
                Console.WriteLine("Введите число!");
                return MoneyInput();
            }
        }
    }
    class LegalEntityBankAccount : BankAccount
    {
        public void AccrualOfInterest()
        {

        }
    }
}
