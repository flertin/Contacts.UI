using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.DAL {
    public static class RepositoryContext {
        public static IPersonRepository Active { get; set; }
    }
}
