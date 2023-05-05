using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTask
{
    class Program
    {
        static Queue<Client> queue = new Queue<Client>();
        static List<Table> tables = new List<Table>();

        static void Main(string[] args)
        {
            tables.Add(new Table());
            tables.Add(new Table());
            tables.Add(new Table());

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Приход клиента");
                Console.WriteLine("2. Освобождение столика");
                Console.WriteLine("3. Резервирование столика");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите опцию: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddClientToQueue();
                        break;
                    case 2:
                        ReleaseTable();
                        break;
                    case 3:
                        ReserveTable();
                        break;
                    case 4:
                        Console.WriteLine("До свидания!");
                        return;
                    default:
                        Console.WriteLine("Некорректная опция! Попробуйте снова.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddClientToQueue()
        {
            Console.WriteLine("Введите имя клиента:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите время, на которое клиент хочет зарезервировать столик:");
            DateTime reservationTime = Convert.ToDateTime(Console.ReadLine());

            Client client = new Client(name, reservationTime);
            queue.Enqueue(client);
            Console.WriteLine($"Клиент {client.Name} добавлен в очередь.");
        }

        static void ReleaseTable()
        {
            if (tables.Count > 0)
            {
                Table table = tables[0];
                tables.RemoveAt(0);

                if (queue.Count > 0)
                {
                    Client client = queue.Dequeue();
                    Console.WriteLine($"Столик освободился. Клиент {client.Name} занимает столик.");
                    table.Client = client;
                }
                else
                {
                    Console.WriteLine("Столик освободился. Очередь пуста.");
                    table.Client = null;
                }
            }
            else
            {
                Console.WriteLine("Нет свободных столиков.");
            }
        }
        static void ReserveTable()
        {
            Console.WriteLine("Введите имя клиента:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите время, на которое клиент хочет зарезервировать столик:");
            DateTime reservationTime = Convert.ToDateTime(Console.ReadLine());

            Client client = new Client(name, reservationTime);
            Table reservedTable = tables.Find(t => t.Client == null && t.ReservationTime == reservationTime);

            if (reservedTable != null)
            {
                reservedTable.Client = client;
                Console.WriteLine($"Столик зарезервирован для клиента {client.Name} на время {client.ReservationTime}.");
            }
            else
            {
                Console.WriteLine("Нет свободных столиков на указанное время.");
            }
        }
    }

    class Client
    {
        public string Name { get; set; }
        public DateTime ReservationTime { get; set; }

        public Client(string name, DateTime reservationTime)
        {
            Name = name;
            ReservationTime = reservationTime;
        }
    }

    class Table
    {
        public Client Client { get; set; }
        public DateTime ReservationTime { get; set; }

        public Table()
        {
            Client = null;
            ReservationTime = DateTime.MinValue;
        }
    }
}
