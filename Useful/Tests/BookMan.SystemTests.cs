using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using BookMan.Data;

namespace BookMan.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const int iterations = 100;
        private List<Guid> sent = new List<Guid>();
        private BookMan.Data.DataAccess da;

        public UnitTest1()
        {
            this.da = new Data.DataAccess();
            this.da.GetPersonDatasetCompleted += new EventHandler<GetPersonDatasetEventArgs>(da_GetPersonDatasetCompleted);
        }

        void da_GetPersonDatasetCompleted(object sender, GetPersonDatasetEventArgs e)
        {
            Guid guid = (Guid)e.UserState;
            lock (this.sent)
            {
                if (!this.sent.Contains(guid))
                {
                    Assert.Fail("Unknown GUID returned.");
                }
                this.sent.Remove(guid);
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            Thread t = new Thread(new ThreadStart(AddPersonFunction));
            t.Start();

            // Give the thread chance to do something
            Thread.Sleep(1000);

            int i = 0;
            while (i < 30
                && this.sent.Count > 0)
            {
                Thread.Sleep(1000);
                i++;
            }

            if (this.sent.Count > 0)
            {
                Assert.Fail("Not all calls returned.");
            }
        }

        public void AddPersonFunction()
        {
            for (int i = 0; i < iterations; i++)
            {
                Guid guid = Guid.NewGuid();
                this.sent.Add(guid);
                this.da.GetPersonAsync(1, guid);
            }
        }

    }
}
