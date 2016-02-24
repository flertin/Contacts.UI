using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.DAL {
    public class PersonRepository:IPersonRepository {
        private List<Person> _items = new List<Person>();
        public PersonRepository() {
            Add(new Person {
                Name = "name 1",
                Organization = "Org1"
            });

            Add(new Person {
                Name = "name 2",
                Organization = "Org2"
            });
        }

        public void Add(Person item) {
            _items.Add(item);
        }

        public List<Person> GetAll() {
            return _items.ToList();
        }

        public void Remove(int index) {
            _items.RemoveAt(index);
        }
    }
}
