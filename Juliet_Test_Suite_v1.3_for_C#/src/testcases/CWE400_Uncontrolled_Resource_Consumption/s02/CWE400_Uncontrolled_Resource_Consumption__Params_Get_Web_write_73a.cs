/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__Params_Get_Web_write_73a.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-73a.tmpl.cs
*/
/*
 * @description
 * CWE: 400 Uncontrolled Resource Consumption
 * BadSource: Params_Get_Web Read count from a querystring using Params.Get()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: write
 *    GoodSink: Write to a file count number of times, but first validate count
 *    BadSink : Write to a file count number of times
 * Flow Variant: 73 Data flow: data passed in a LinkedList from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System.Collections.Generic;
using System;

using System.Web;


namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__Params_Get_Web_write_73a : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        int count;
        count = int.MinValue; /* Initialize count */
        /* POTENTIAL FLAW: Read count from a querystring using Params.Get() */
        {
            string stringNumber = req.Params.Get("name");
            try
            {
                count = int.Parse(stringNumber.Trim());
            }
            catch (FormatException exceptNumberFormat)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception reading count from parameter 'name'");
            }
        }
        LinkedList<int> countLinkedList = new LinkedList<int>();
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        CWE400_Uncontrolled_Resource_Consumption__Params_Get_Web_write_73b.BadSink(countLinkedList , req, resp );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
        GoodB2G(req, resp);
    }

    /* goodG2B() - use GoodSource and BadSink */
    private static void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        int count;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        count = 2;
        LinkedList<int> countLinkedList = new LinkedList<int>();
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        CWE400_Uncontrolled_Resource_Consumption__Params_Get_Web_write_73b.GoodG2BSink(countLinkedList , req, resp );
    }

    /* goodB2G() - use BadSource and GoodSink */
    private static void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        int count;
        count = int.MinValue; /* Initialize count */
        /* POTENTIAL FLAW: Read count from a querystring using Params.Get() */
        {
            string stringNumber = req.Params.Get("name");
            try
            {
                count = int.Parse(stringNumber.Trim());
            }
            catch (FormatException exceptNumberFormat)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception reading count from parameter 'name'");
            }
        }
        LinkedList<int> countLinkedList = new LinkedList<int>();
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        CWE400_Uncontrolled_Resource_Consumption__Params_Get_Web_write_73b.GoodB2GSink(countLinkedList , req, resp );
    }
#endif //omitgood
}
}
