/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE80_XSS__Web_Get_Cookies_Web_54d.cs
Label Definition File: CWE80_XSS__Web.label.xml
Template File: sources-sink-54d.tmpl.cs
*/
/*
 * @description
 * CWE: 80 Cross Site Scripting (XSS)
 * BadSource: Get_Cookies_Web Read data from the first cookie using Cookies
 * GoodSource: A hardcoded string
 * Sinks: Web
 *    BadSink : Display of data in web page without any encoding or validation
 * Flow Variant: 54 Data flow: data passed as an argument from one method through three others to a fifth; all five functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE80_XSS
{
class CWE80_XSS__Web_Get_Cookies_Web_54d
{
#if (!OMITBAD)
    public static void BadSink(string data , HttpRequest req, HttpResponse resp)
    {
        CWE80_XSS__Web_Get_Cookies_Web_54e.BadSink(data , req, resp);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string data , HttpRequest req, HttpResponse resp)
    {
        CWE80_XSS__Web_Get_Cookies_Web_54e.GoodG2BSink(data , req, resp);
    }
#endif
}
}
