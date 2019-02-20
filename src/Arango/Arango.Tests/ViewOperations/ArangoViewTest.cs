using Arango.Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arango.Tests.ViewOperations
{
    [TestFixture()]
    class ArangoViewTest
    {
        public ArangoViewTest()
        {
            Database.CreateTestDatabase(Database.TestDatabaseGeneral);
            Database.CreateTestCollection(Database.TestDocumentCollectionName, ACollectionType.Document);
        }

        [Test()]
        public void CreateAndDropView()
        {
            var db = new ADatabase(Database.Alias);

            var document = new Dictionary<string, object>()
                .String("foo", "foo string value")
                .Int("bar", 12345);

            var document1 = new Dictionary<string, object>()
                .String("foo bar", "foo bar string value")
                .Int("bar", 54321);

            var createResult = db.Document
                .Create(Database.TestDocumentCollectionName, document);

            var createResult2 = db.Document
                .Create(Database.TestDocumentCollectionName+"second", document);

            var vcrresult = db.View.Create("V" + Database.TestDocumentCollectionName);
            Assert.IsTrue(vcrresult.Success);

            var vdelre = db.View.Delete("V" + Database.TestDocumentCollectionName);
            Assert.IsTrue(vdelre.Success);

        }

        [Test()]
        public void CreateAddLinkQueryView()
        {
            var db = new ADatabase(Database.Alias);

            var document = new Dictionary<string, object>()
                .String("foo", "foo string value")
                .Int("bar", 12345);

            var document1 = new Dictionary<string, object>()
                .String("foo bar", "foo bar string value")
                .Int("bar", 54321);

            var createResult = db.Document
                .Create(Database.TestDocumentCollectionName, document);

            var createResult2 = db.Document
                .Create(Database.TestDocumentCollectionName + "second", document);

            var vcrresult = db.View.Create("V" + Database.TestDocumentCollectionName);
            Assert.IsTrue(vcrresult.Success);

            var vlink = db.View.ChangeProperties("V" + Database.TestDocumentCollectionName, Database.TestDocumentCollectionName);
            Assert.IsTrue(vlink.Success);

            var vlink1 = db.View.ChangeProperties("V" + Database.TestDocumentCollectionName, Database.TestDocumentCollectionName + "second");
            Assert.IsTrue(vlink1.Success);

            var vdelre = db.View.Delete("V" + Database.TestDocumentCollectionName);
            Assert.IsTrue(vdelre.Success);


        }

        public void Dispose()
        {
            Database.DeleteTestDatabase(Database.TestDatabaseGeneral);
        }

    }
}
