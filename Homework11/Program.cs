using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person Pers = new Person();
            Pers.AddPersonToDataBase(new Person("QWERTY", "55552"));
            Pers.AddPersonToDataBase(new Person("EEE", "132"));
            Pers.AddPersonToDataBase(new Person("EqEE", "5211"));
            Pers.PrintData();
            Pers.RemovePersonData("QQQ");
            Pers.ChangeLoginAndPassword();
            Pers.PrintData();
            Pers.TakeInfoByLogin();
        }

        class Personal { };

        class Person
        {
            public Dictionary<string, string> PersonalData = new Dictionary<string, string>();
            public string login { get; set; }
            public string password { get; set; }

            public void AddPersonToDataBase(Person person)
            {
                if (person.password == null || person.login == null)
                    AddPersonInfo(person);
                if (person.password != null && person.login != null)
                    if (!PersonalData.ContainsValue(person.password) && !PersonalData.ContainsKey(person.login))
                        PersonalData.Add(person.login, person.password);
                    else
                        Console.WriteLine("Dictionary already have the same user info!");
            }
            public void RemovePersonData(string login)
            {
                if (PersonalData.ContainsKey(login))
                    PersonalData.Remove(login);
                else Console.WriteLine("Nothing to remove!");
            }

            public void ChangeLoginAndPassword()
            {
                Console.WriteLine("Enter the login you want to change:");
                string loginToChange = Console.ReadLine();

                Console.WriteLine("Enter login to change:");
                string login = Console.ReadLine();

                Console.WriteLine("Enter password to change:");
                string password = Console.ReadLine();

                KeyValuePair<string, string> pair = new KeyValuePair<string, string>( login, password );
                PersonalData[loginToChange.Replace(loginToChange, login)] = pair.Value;
                PersonalData.Remove(loginToChange);
            }

            public void TakeInfoByLogin()
            {
                Console.WriteLine("Enter login for what you want to get password:");
                string login = Console.ReadLine();

                if (login != null)
                    if (PersonalData.ContainsKey(login))
                        Console.WriteLine("Password is:\t" + PersonalData[key: login].ToString());
                    else
                        Console.WriteLine("Nothing was inputed!!!");
            }

            public void PrintData()
            {
                foreach (var item in PersonalData)

                    Console.WriteLine($"Login:\t{item.Key}\nPassword:\t{item.Value}");
            }
            public Person()
            {
                this.login = null;
                this.password = null;
            }

            public Person(string login, string password) { this.login = login; this.password = password; }

            static public void AddPersonInfo(Person person)
            {
                Console.WriteLine("Enter login:");
                person.login = Console.ReadLine();

                Console.WriteLine("Enter password:");
                person.password = Console.ReadLine();
            }
        }
    }
}
