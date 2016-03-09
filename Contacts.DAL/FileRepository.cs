using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.DAL {
    public class FileRepository : IPersonRepository {
        private string _fileName;
        public FileRepository(string fileName) {
            _fileName = fileName;
        }

        public void Add(Person item) {
            string text = item.Name + Environment.NewLine + item.Organization + Environment.NewLine;
            File.AppendAllText(_fileName, text);            
        }

        public List<Person> GetAll() {
            // arrange
            var result = new List<Person>();

            using(var file = File.OpenRead(_fileName)) {
                using(var reader = new StreamReader(file)) {
                    while(!reader.EndOfStream) {
                        var name = reader.ReadLine();
                        var org = reader.ReadLine();
                        var item = new Person {
                            Name = name,
                            Organization = org
                        };
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public void Remove(int index) {
            var sb = new StringBuilder();
            var persons = GetAll();
            persons.RemoveAt(index);
            foreach (var item in persons)
            {
                sb.AppendLine(item.Name);
                sb.AppendLine(item.Organization);
            }
            File.WriteAllText(_fileName, sb.ToString());
        }
    }
}
