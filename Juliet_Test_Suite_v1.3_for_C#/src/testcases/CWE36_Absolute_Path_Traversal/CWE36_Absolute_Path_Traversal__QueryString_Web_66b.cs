/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE36_Absolute_Path_Traversal__QueryString_Web_66b.cs
Label Definition File: CWE36_Absolute_Path_Traversal.label.xml
Template File: sources-sink-66b.tmpl.cs
*/
/*
 * @description
 * CWE: 36 Absolute Path Traversal
 * BadSource: QueryString_Web Parse id param out of the URL query string (without using getParameter())
 * GoodSource: A hardcoded string
 * Sinks: readFile
 *    BadSink : read line from file from disk
 * Flow Variant: 66 Data flow: data passed in an array from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.IO;

using System.Web;

namespace testcases.CWE36_Absolute_Path_Traversal
{
class CWE36_Absolute_Path_Traversal__QueryString_Web_66b
{
#if (!OMITBAD)
    public static void BadSink(string[] dataArray , HttpRequest req, HttpResponse resp)
    {
        string data = dataArray[2];
        /* POTENTIAL FLAW: unvalidated or sandboxed value */
        if (data != null)
        {
            if (File.Exists(data))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(data))
                    {
                        IO.WriteLine(sr.ReadLine());
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
                }
            }
        }
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string[] dataArray , HttpRequest req, HttpResponse resp)
    {
        string data = dataArray[2];
        /* POTENTIAL FLAW: unvalidated or sandboxed value */
        if (data != null)
        {
            if (File.Exists(data))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(data))
                    {
                        IO.WriteLine(sr.ReadLine());
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
                }
            }
        }
    }
#endif
}
}
