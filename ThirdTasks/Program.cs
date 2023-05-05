using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cafe cafe = new Cafe();
            cafe.Start();
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
        class Cafe
        {
            static Queue<Client> queue = new Queue<Client>();
            static List<Table> tables = new List<Table>();

            public void ShowTables()
            {
                foreach (var item in queue)
                {
                    Console.WriteLine("Name: " + item.Name + " Date: " + item.ReservationTime);
                }
            }
            public void ReserveTable()
            {
                Console.WriteLine("Enter Client Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Time:");
                DateTime reservationTime = Convert.ToDateTime(Console.ReadLine());

                Client client = new Client(name, reservationTime);
                Table reservedTable = tables.Find(t => t.Client == null && t.ReservationTime == reservationTime);

                if (reservedTable != null)
                {
                    reservedTable.Client = client;
                    Console.WriteLine($"Reserve To {client.Name}");
                }
                else
                {
                    Console.WriteLine("Not Free Tables");
                }
            }

            public void ReleaseTable()
            {
                if (tables.Count > 0)
                {
                    Table table = tables[0];
                    tables.RemoveAt(0);

                    if (queue.Count > 0)
                    {
                        Client client = queue.Dequeue();
                        Console.WriteLine($"Free Table from Client, {client.Name} Take a Table");
                        table.Client = client;
                    }
                    else
                    {
                        Console.WriteLine("Queue Free");
                        table.Client = null;
                    }
                }
                else
                {
                    Console.WriteLine("Not Free Tables");
                }
            }

            public void AddClientToQueue()
            {
                Console.WriteLine("Enter Client Name");
                string name = Console.ReadLine();
                Console.WriteLine("Time:");
                DateTime reservationTime = new DateTime();
                try
                {
                    reservationTime = Convert.ToDateTime(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Error Date");
                    return;
                }

                Client client = new Client(name, reservationTime);
                queue.Enqueue(client);
            }

            public void Start()
            {
                tables.Add(new Table());
                tables.Add(new Table());

                while (true)
                {
                    Console.WriteLine("1. Add Client To Queue");
                    Console.WriteLine("2. Free Client from Queue");
                    Console.WriteLine("3. Reserve Queue To Client");
                    Console.WriteLine("4. Show Reservation");
                    Console.WriteLine("5. Exit");
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
                            ShowTables();
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
