using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenexDemoPrint
{
    public static class XenexPrint
    {
        public static IEnumerable<string> GenerateMessages(int loops, Dictionary<int, string> messageCases)
        {
            for (int i = 1; i <= loops; i++)
            {
                StringBuilder messageBuilder = new StringBuilder();
                messageBuilder.Append(i.ToString());

                foreach(KeyValuePair<int, string> messageCase in messageCases)
                {
                    if (i % messageCase.Key == 0)
                        messageBuilder.Append(" " + messageCase.Value);
                }

                yield return messageBuilder.ToString();
            }
        }
    }
}
