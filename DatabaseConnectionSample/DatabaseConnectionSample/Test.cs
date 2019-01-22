using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionSample
{
    class Test
    {
        [Test]
        public void TestConnection()
        {
            DatabaseUtils db = new DatabaseUtils();

            db.Connect_To_Database();

            string output = DatabaseUtils.ReadData(7, "CustomerNo");

        }
    }
}
