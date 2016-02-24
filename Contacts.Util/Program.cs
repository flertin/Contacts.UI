using Contacts.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Util {
    class Program {
        static void Main(string[] args) {
            var repository = new PersonRepository();
            foreach(var item in repository.GetAll()) {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }
}
