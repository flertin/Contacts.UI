using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.DAL {
    public class FileRepository : IPersonRepository {
        private string _fileName;
        public FileRepository(string fileName) {
            _fileName = fileName;
        }

        public void Add(Person item) {
            throw new NotImplementedException();
        }

        public List<Person> GetAll() {
            using(var ) {

            }
        }

        public void Remove(int index) {
            throw new NotImplementedException();
        }
    }
}
