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
        void Execute();
    }

    class AddCommand : ICommand
    {
        public string Name => "add";

        public void Execute()
        {
            var person = new Person();
            person.Name = Console.ReadLine();
            person.Organization = Console.ReadLine();

            PersonList.Active.Add(person);
        }
    }

    class ListCommand : ICommand
    {
        public string Name => "list";

        public void Execute()
        {
            foreach (var item in PersonList.Active)
            {
                Console.WriteLine(item.Name + "; " + item.Organization);
            }
        }
    }

    class DeleteCommand : ICommand {
        public string Name => "del";
        public void Execute() {
            var index = int.Parse(Console.ReadLine());
            PersonList.Active.RemoveAt(index);
        }
    }

    class LinesWrapper : ICommand {
        public ICommand Inner { get;private set; }
        public LinesWrapper(ICommand cmd) {
            Inner = cmd;
        }

        public string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public void Execute() {
            Console.WriteLine("-----------------");
            Inner.Execute();
            Console.WriteLine("=================");
        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            var commands = new List<ICommand>();
            commands.Add(new LinesWrapper(new AddCommand()));
            commands.Add(new LinesWrapper(new ListCommand()));
            commands.Add(new DeleteCommand());

            while(true)
            {
                var command = Console.ReadLine();
                var target = commands.SingleOrDefault(c => c.Name == command);
                if (target != null)
                {
                    
                    target.Execute();
                    
                }
            }
        }
    }
}
