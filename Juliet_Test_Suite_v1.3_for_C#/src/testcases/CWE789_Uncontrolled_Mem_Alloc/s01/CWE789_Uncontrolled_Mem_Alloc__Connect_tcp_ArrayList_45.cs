/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE789_Uncontrolled_Mem_Alloc__Connect_tcp_ArrayList_45.cs
Label Definition File: CWE789_Uncontrolled_Mem_Alloc.int.label.xml
Template File: sources-sink-45.tmpl.cs
*/
/*
 * @description
 * CWE: 789 Uncontrolled Memory Allocation
 * BadSource: Connect_tcp Read data using an outbound tcp connection
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: ArrayList
 *    BadSink : Create an ArrayList using data as the initial size
 * Flow Variant: 45 Data flow: data passed as a private class member variable from one function to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Collections;

using System.Web;

using System.IO;
using System.Net.Sockets;

namespace testcases.CWE789_Uncontrolled_Mem_Alloc
{

class CWE789_Uncontrolled_Mem_Alloc__Connect_tcp_ArrayList_45 : AbstractTestCase
{

    private int dataBad;
    private int dataGoodG2B;
#if (!OMITBAD)
    private void BadSink()
    {
        int data = dataBad;
        /* POTENTIAL FLAW: Create an ArrayList using data as the initial size.  data may be very large, creating memory issues */
        ArrayList intArrayList = new ArrayList(data);
    }

    /* uses badsource and badsink */
    public override void Bad()
    {
        int data;
        data = int.MinValue; /* Initialize data */
        /* Read data using an outbound tcp connection */
        {
            try
            {
                String stringNumber = "";
                /* Read data using an outbound tcp connection */
                using (TcpClient tcpConn = new TcpClient("host.example.org", 39544))
                {
                    /* read input from socket */
                    using (StreamReader sr = new StreamReader(tcpConn.GetStream()))
                    {
                        /* POTENTIAL FLAW: Read data using an outbound tcp connection */
                        stringNumber = sr.ReadLine();
                    }
                }
                if (stringNumber != null) /* avoid NPD incidental warnings */
                {
                    try
                    {
                        data = int.Parse(stringNumber.Trim());
                    }
                    catch(FormatException exceptNumberFormat)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing data from string");
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
            }
        }
        dataBad = data;
        BadSink();
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
    }

    private void GoodG2BSink()
    {
        int data = dataGoodG2B;
        /* POTENTIAL FLAW: Create an ArrayList using data as the initial size.  data may be very large, creating memory issues */
        ArrayList intArrayList = new ArrayList(data);
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        int data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        dataGoodG2B = data;
        GoodG2BSink();
    }
#endif //omitgood
}
}
