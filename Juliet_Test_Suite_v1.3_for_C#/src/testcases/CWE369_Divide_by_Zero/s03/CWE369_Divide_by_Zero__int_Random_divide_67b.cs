/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE369_Divide_by_Zero__int_Random_divide_67b.cs
Label Definition File: CWE369_Divide_by_Zero__int.label.xml
Template File: sources-sinks-67b.tmpl.cs
*/
/*
 * @description
 * CWE: 369 Divide by zero
 * BadSource: Random Set data to a random value
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: divide
 *    GoodSink: Check for zero before dividing
 *    BadSink : Dividing by a value that may be zero
 * Flow Variant: 67 Data flow: data passed in a class from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE369_Divide_by_Zero
{
class CWE369_Divide_by_Zero__int_Random_divide_67b
{
#if (!OMITBAD)
    public static void BadSink(CWE369_Divide_by_Zero__int_Random_divide_67a.Container dataContainer )
    {
        int data = dataContainer.containerOne;
        /* POTENTIAL FLAW: Zero denominator will cause an issue.  An integer division will
        result in an exception. */
        IO.WriteLine("bad: 100/" + data + " = " + (100 / data) + "\n");
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(CWE369_Divide_by_Zero__int_Random_divide_67a.Container dataContainer )
    {
        int data = dataContainer.containerOne;
        /* POTENTIAL FLAW: Zero denominator will cause an issue.  An integer division will
        result in an exception. */
        IO.WriteLine("bad: 100/" + data + " = " + (100 / data) + "\n");
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(CWE369_Divide_by_Zero__int_Random_divide_67a.Container dataContainer )
    {
        int data = dataContainer.containerOne;
        /* FIX: test for a zero denominator */
        if (data != 0)
        {
            IO.WriteLine("100/" + data + " = " + (100 / data) + "\n");
        }
        else
        {
            IO.WriteLine("This would result in a divide by zero");
        }
    }
#endif
}
}
