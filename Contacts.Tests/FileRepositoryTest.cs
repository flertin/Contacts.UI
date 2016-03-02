using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contacts.DAL;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Contacts.Tests {
    [TestClass]
    public class FileRepositoryTest {
        private string fileName;

        [TestInitialize]
        public void SetUp() {
            var sb = new StringBuilder();
            sb.AppendLine("Name1");
            sb.AppendLine("Org1");
            sb.AppendLine("Name2");
            sb.AppendLine("Org2");
            sb.AppendLine("Name3");
            sb.AppendLine("Org3");
            fileName = Path.GetRandomFileName();
            File.WriteAllText(fileName, sb.ToString());
        }

        [TestCleanup]
        public void CleanUp() {
            File.Delete(fileName);
        }


        [TestMethod]
        public void TestFileRepositoryIsIRepository() {
            var repository = new FileRepository(null);
            var result = repository is IPersonRepository;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestAllDataLoaded() {
            // arrange
            var expected = new List<Person> {
                new Person {
                    Name="Name1",
                    Organization="Org1"
                },
                new Person {
                    Name="Name2",
                    Organization="Org2"
                },
                new Person {
                    Name="Name3",
                    Organization="Org3"
                }
            };

            var repository = new FileRepository(fileName);
            // ---------------------------

            // act
            var items = repository.GetAll();

            // assert
            Assert.AreEqual(expected.Count, items.Count);
            for(int i = 0; i < expected.Count; i++) {
                var exp = expected[i];
                var actual = items[i];
                Assert.AreEqual(exp.Name, actual.Name);
                Assert.AreEqual(exp.Organization, actual.Organization);
            }
        }
    }
}
