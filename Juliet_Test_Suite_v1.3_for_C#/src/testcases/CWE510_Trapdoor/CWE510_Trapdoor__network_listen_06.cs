/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE510_Trapdoor__network_listen_06.cs
Label Definition File: CWE510_Trapdoor.badonly.label.xml
Template File: point-flaw-badonly-06.tmpl.cs
*/
/*
* @description
* CWE: 510 Trapdoor
* Sinks: network_listen
*    BadSink : Presence of a network listener
*    BadOnly (No GoodSink)
* Flow Variant: 06 Control flow: if(PRIVATE_CONST_FIVE==5)
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Net.Sockets;
using System.Net;

namespace testcases.CWE510_Trapdoor
{
class CWE510_Trapdoor__network_listen_06 : AbstractTestCaseBadOnly
{
    /* The variable below is declared "const", so a tool should be able
     * to identify that reads of this will always give its initialized
     * value.
     */
    private const int PRIVATE_CONST_FIVE = 5;
#if (!OMITBAD)
    public override void Bad()
    {
        if (PRIVATE_CONST_FIVE == 5)
        {
            TcpListener listener = null;
            TcpClient socket = null;
            int port = 30000;
            try
            {
                listener = new TcpListener(IPAddress.Parse("10.10.1.10"), port); /* INCIDENTAL: Use of Socket */
                /* wait for first connection */
                /* FLAW: Listening for network connection */
                listener.Start();
                socket = listener.AcceptTcpClient();
                /* connection successful, so do stuff */
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Could not listen on port " + port.ToString());
            }
            finally
            {
                try
                {
                    if (socket != null)
                    {
                        socket.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error closing objects");
                }

                try
                {
                    if (listener != null)
                    {
                        listener.Stop();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error closing objects");
                }
            }
        }
    }
#endif //omitbad
}
}
