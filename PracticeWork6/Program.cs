

using PracticeWork6;
using System.Globalization;
using System.Text;

internal static class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("uk-UA");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("uk-UA");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Оберіть завдання:");
            Console.WriteLine("1 - Завдання 1");
            Console.WriteLine("2 - Завдання 2");
            Console.WriteLine("3 - Завдання 3");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    RunTask1();
                    break;

                case "2":
                    RunTask2();
                    break;

                case "3":
                    RunTask3();
                    break;

                case "0":
                    Console.WriteLine("Програму завершено.");
                    return;

                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }

    static void RunTask1()
    {
        List<Parcel> parcels = new List<Parcel>
            {
                new Parcel(105, "Київ", 4.5, "Петренко"),
                new Parcel(102, "Івано-Франківськ", 2.3, "Іваненко"),
                new Parcel(101, "Київ", 1.8, "Шевченко"),
                new Parcel(104, "Європейський", 6.2, "Мельник"),
                new Parcel(103, "Ґалаґани", 3.1, "Коваленко")
            };

        Console.WriteLine("Природний порядок (за вагою):");

        parcels.Sort();

        foreach (Parcel p in parcels)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("\nПорядок за порівнювачем:");

        parcels.Sort(new ParcelComparer());

        foreach (Parcel p in parcels)
        {
            Console.WriteLine(p);
        }
    }

    static void RunTask2()
    {
        DeliveryPlan plan = new DeliveryPlan();

        plan.Add(new Parcel(3, "Центр", 8.5, "Іваненко"));
        plan.Add(new Parcel(1, "Північ", 3.2, "Петренко"));
        plan.Add(new Parcel(4, "Південь", 6.7, "Коваленко"));
        plan.Add(new Parcel(2, "Захід", 4.5, "Шевченко"));

        Console.WriteLine("Всі посилки:");

        foreach (Parcel parcel in plan)
        {
            Console.WriteLine(parcel);
        }

        Console.WriteLine("\nНе більше двох посилок важчих за 5 кг:");

        foreach (Parcel parcel in plan.HeavierThan(5, 2))
        {
            Console.WriteLine(parcel);
        }
    }

    static void RunTask3()
    {
        DeliveryPlan original = new DeliveryPlan();

        original.Add(new Parcel(1, "Центр", 5.5, "Іваненко"));
        original.Add(new Parcel(2, "Північ", 3.2, "Петренко"));
        original.Add(new Parcel(3, "Південь", 7.8, "Іваненко"));
        original.Add(new Parcel(4, "Захід", 4.5, "Шевченко"));

        DeliveryPlan copy = (DeliveryPlan)original.Clone();

        copy.ChangeCourier("Іваненко", "Коваленко");

        Console.WriteLine("Оригінальний план:");

        foreach (Parcel parcel in original)
        {
            Console.WriteLine(parcel);
        }

        Console.WriteLine("\nЗмінений план:");

        foreach (Parcel parcel in copy)
        {
            Console.WriteLine(parcel);
        }
    }
}

