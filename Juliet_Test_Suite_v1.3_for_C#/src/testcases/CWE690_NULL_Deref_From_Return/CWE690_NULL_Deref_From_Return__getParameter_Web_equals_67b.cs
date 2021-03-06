/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE690_NULL_Deref_From_Return__getParameter_Web_equals_67b.cs
Label Definition File: CWE690_NULL_Deref_From_Return.label.xml
Template File: sources-sinks-67b.tmpl.cs
*/
/*
 * @description
 * CWE: 690 Unchecked return value is null, leading to a null pointer dereference.
 * BadSource: getParameter_Web Set data to return of getParameter_Web
 * GoodSource: Set data to fixed, non-null String
 * Sinks: equals
 *    GoodSink: Call equals() on string literal (that is not null)
 *    BadSink : Call equals() on possibly null object
 * Flow Variant: 67 Data flow: data passed in a class from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE690_NULL_Deref_From_Return
{
class CWE690_NULL_Deref_From_Return__getParameter_Web_equals_67b
{
#if (!OMITBAD)
    public static void BadSink(CWE690_NULL_Deref_From_Return__getParameter_Web_equals_67a.Container dataContainer , HttpRequest req, HttpResponse resp)
    {
        string data = dataContainer.containerOne;
        /* POTENTIAL FLAW: data could be null */
        if(data.Equals("CWE690"))
        {
            IO.WriteLine("data is CWE690");
        }
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(CWE690_NULL_Deref_From_Return__getParameter_Web_equals_67a.Container dataContainer , HttpRequest req, HttpResponse resp)
    {
        string data = dataContainer.containerOne;
        /* POTENTIAL FLAW: data could be null */
        if(data.Equals("CWE690"))
        {
            IO.WriteLine("data is CWE690");
        }
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(CWE690_NULL_Deref_From_Return__getParameter_Web_equals_67a.Container dataContainer , HttpRequest req, HttpResponse resp)
    {
        string data = dataContainer.containerOne;
        /* FIX: call equals() on string literal (that is not null) */
        if("CWE690".Equals(data))
        {
            IO.WriteLine("data is CWE690");
        }
    }
#endif
}
}
