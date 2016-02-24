using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contacts.DAL;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Contacts.Tests {
    [TestClass]
    public class FileRepositoryTest {
        [TestMethod]
        public void TestFileRepositoryIsIRepository() {
            var repository = new FileRepository();
            var result = repository is IPersonRepository;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestAllDataLoaded() {
            var sb = new StringBuilder();
            sb.AppendLine("Name1");
            sb.AppendLine("Org1");
            sb.AppendLine("Name2");
            sb.AppendLine("Org2");
            var fileName = Path.Combine(Path.GetTempPath(), "test.data");
            File.WriteAllText(fileName, sb.ToString());
            //------------------------

            var expected = new List<Person> {
                new Person {
                    Name="Name1",
                    Organization="Org1"
                },
                new Person {
                    Name="Name2",
                    Organization="Org2"
                }
            };

            var repository = new FileRepository();
            var items = repository.GetAll();

            Assert.AreEqual(expected.Count, items.Count);
            for(int i = 0; i < expected.Count; i++) {
                var exp = expected[i];
                var actual = items[i];
                Assert.AreEqual(exp.Name, actual.Name);
                Assert.AreEqual(exp.Organization, actual.Organization);
            }


            //------------------------
            File.Delete(fileName);
        }
    }
}
