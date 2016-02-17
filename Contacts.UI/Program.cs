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

    static class ConsoleContext {
        public static IConsole Active { get; set; }
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

    interface IConsole {
        string ReadLine();
        void WriteLine(string str);
    }

    class ConsoleEx : IConsole {
        public string ReadLine() {
            return Console.ReadLine();
        }

        public void WriteLine(string str) {
            Console.WriteLine(str);
        }
    }

    class AddCommand : ICommand
    {
        public string Name => "add";

        public void Execute()
        {
            var person = new Person();
            person.Name = ConsoleContext.Active.ReadLine();
            person.Organization = ConsoleContext.Active.ReadLine();

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
                ConsoleContext.Active.WriteLine(item.Name + "; " + item.Organization);
            }
        }
    }

    class DeleteCommand : ICommand {
        public string Name => "del";
        public void Execute() {
            var index = int.Parse(ConsoleContext.Active.ReadLine());
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
            ConsoleContext.Active.WriteLine("-----------------");
            Inner.Execute();
            ConsoleContext.Active.WriteLine("=================");
        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            ConsoleContext.Active = new ConsoleEx();

            var commands = new List<ICommand>();
            commands.Add(new LinesWrapper(new AddCommand()));
            commands.Add(new LinesWrapper(new ListCommand()));
            commands.Add(new DeleteCommand());

            while(true)
            {
                var command = ConsoleContext.Active.ReadLine();
                var target = commands.SingleOrDefault(c => c.Name == command);
                if (target != null)
                {
                    target.Execute();
                }
            }
        }
    }
}
