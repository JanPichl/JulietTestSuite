/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE117_Improper_Output_Neutralization_for_Logs__Params_Get_Web_52b.cs
Label Definition File: CWE117_Improper_Output_Neutralization_for_Logs.label.xml
Template File: sources-sinks-52b.tmpl.cs
*/
/*
 * @description
 * CWE: 117 Improper Output Neutralization for Logs
 * BadSource: Params_Get_Web Read data from a querystring using Params.Get()
 * GoodSource: A hardcoded string
 * Sinks: readFile
 *    GoodSink: Logging output is neutralized
 *    BadSink : Logging output is not neutralized
 * Flow Variant: 52 Data flow: data passed as an argument from one method to another to another in three different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE117_Improper_Output_Neutralization_for_Logs
{
class CWE117_Improper_Output_Neutralization_for_Logs__Params_Get_Web_52b
{
#if (!OMITBAD)
    public static void BadSink(string data , HttpRequest req, HttpResponse resp)
    {
        CWE117_Improper_Output_Neutralization_for_Logs__Params_Get_Web_52c.BadSink(data , req, resp);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string data , HttpRequest req, HttpResponse resp)
    {
        CWE117_Improper_Output_Neutralization_for_Logs__Params_Get_Web_52c.GoodG2BSink(data , req, resp);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(string data , HttpRequest req, HttpResponse resp)
    {
        CWE117_Improper_Output_Neutralization_for_Logs__Params_Get_Web_52c.GoodB2GSink(data , req, resp);
    }
#endif
}
}
