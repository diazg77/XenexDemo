using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using XenexDemoPrint;

namespace XenexDemoTest
{
    [TestFixture]
    public class XenexPrintTest
    {
        private Dictionary<int, string> messageCases = new Dictionary<int, string>();
        private int TestLoopCount;

        [OneTimeSetUp]
        public void TestSetup()
        {
            messageCases.Add(3, "fizz");
            messageCases.Add(5, "buzz");

            TestLoopCount = 15;
        }
        [Test]
        public void XenexPrint15MessageTest()
        {            
            var testMessage = "";            

            foreach (string message in XenexPrint.GenerateMessages(TestLoopCount, messageCases))
                testMessage = message;

            Assert.AreEqual(testMessage, "15 fizz buzz");
        }

        [Test]
        public void XenexPrintLoopCountTest()
        {
            int loopCount = 0;

            foreach (string message in XenexPrint.GenerateMessages(TestLoopCount, messageCases))
                loopCount++;

            Assert.AreEqual(TestLoopCount, loopCount);
        }

        [Test]
        public void XenexPrintExpectedMessageTest()
        {
            var messages = new List<string>();
            for (int i = 1; i <= TestLoopCount; i++)
            {
                StringBuilder messageBuilder = new StringBuilder();
                messageBuilder.Append(i.ToString());

                foreach (KeyValuePair<int, string> messageCase in messageCases)
                {
                    if (i % messageCase.Key == 0)
                        messageBuilder.Append(" " + messageCase.Value);
                }

                messages.Add(messageBuilder.ToString());
            }

            int index = 0;
            foreach (string message in XenexPrint.GenerateMessages(TestLoopCount, messageCases))
            {                
                Assert.AreEqual(message, messages[index]);
                index++;
            }
        }
    }
}
