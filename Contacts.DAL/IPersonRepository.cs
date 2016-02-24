using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.DAL {
    public interface IPersonRepository {
        List<Person> GetAll();
        void Add(Person item);
        void Remove(int index);
    }
}
