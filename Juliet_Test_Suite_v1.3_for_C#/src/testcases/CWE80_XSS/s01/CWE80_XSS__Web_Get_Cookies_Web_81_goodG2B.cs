/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE80_XSS__Web_Get_Cookies_Web_81_goodG2B.cs
Label Definition File: CWE80_XSS__Web.label.xml
Template File: sources-sink-81_goodG2B.tmpl.cs
*/
/*
 * @description
 * CWE: 80 Cross Site Scripting (XSS)
 * BadSource: Get_Cookies_Web Read data from the first cookie using Cookies
 * GoodSource: A hardcoded string
 * Sinks: Web
 *    BadSink : Display of data in web page without any encoding or validation
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */
#if (!OMITGOOD)

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE80_XSS
{
class CWE80_XSS__Web_Get_Cookies_Web_81_goodG2B : CWE80_XSS__Web_Get_Cookies_Web_81_base
{

    public override void Action(string data , HttpRequest req, HttpResponse resp)
    {
        if (data != null)
        {
            /* POTENTIAL FLAW: Display of data in web page without any encoding or validation */
            resp.Write("<br>Bad(): data = " + data);
        }
    }
}
}
#endif
