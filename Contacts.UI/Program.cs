using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.UI
{
    static class PersonList
    {
        public static List<Person> Active = new List<Person>();
    }


    class Person
    {
        public string Name { get; set; }
        public string Organization { get; set; }
    }

    interface ICommand
    {
        string Name { get; }
        void Excute();
    }

    class AddCommand : ICommand
    {
        public string Name => "add";

        public void Excute()
        {
            var person = new Person();
            person.Name = Console.ReadLine();
            person.Organization = Console.ReadLine();

            PersonList.Active.Add(person);
        }
    }

    class ListCommand : ICommand
    {
        string ICommand.Name => "list";

        void ICommand.Excute()
        {
            foreach (var item in PersonList.Active)
            {
                Console.WriteLine(item.Name + "; " + item.Organization);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var commands = new List<ICommand>();
            commands.Add(new AddCommand());
            commands.Add(new ListCommand());

            while (true)
            {
                var command = Console.ReadLine();
                var target = commands.SingleOrDefault(c => c.Name == command);
                if (target != null)
                {
                    target.Excute();
                }
            }
        }
    }
}
