/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE563_Assign_to_Variable_Without_Use__unused_value_int_15.cs
Label Definition File: CWE563_Assign_to_Variable_Without_Use__unused_value.label.xml
Template File: sources-sinks-15.tmpl.cs
*/
/*
* @description
* CWE: 563 Assignment to Variable without Use
* BadSource:  Initialize data
* GoodSource: Initialize and use data
* Sinks:
*    GoodSink: Use data
*    BadSink : re-initialize and use data
* Flow Variant: 15 Control flow: switch(6) and switch(7)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE563_Assign_to_Variable_Without_Use
{
class CWE563_Assign_to_Variable_Without_Use__unused_value_int_15 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int data;
        switch (6)
        {
        case 6:
            /* POTENTIAL FLAW: Initialize, but do not use data */
            data = 5;
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0;
            break;
        }
        switch (7)
        {
        case 7:
            /* POTENTIAL FLAW: Possibly over-write the initial value of data before using it */
            data = 10;
            IO.WriteLine("" + data);
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing the first switch to switch(5) */
    private void GoodG2B1()
    {
        int data;
        switch (5)
        {
        case 6:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0;
            break;
        default:
            /* FIX: Initialize and use data before it is overwritten */
            data = 5;
            IO.WriteLine("" + data);
            break;
        }
        switch (7)
        {
        case 7:
            /* POTENTIAL FLAW: Possibly over-write the initial value of data before using it */
            data = 10;
            IO.WriteLine("" + data);
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }

    /* GoodG2B2() - use goodsource and badsink by reversing the blocks in the first switch  */
    private void GoodG2B2()
    {
        int data;
        switch (6)
        {
        case 6:
            /* FIX: Initialize and use data before it is overwritten */
            data = 5;
            IO.WriteLine("" + data);
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0;
            break;
        }
        switch (7)
        {
        case 7:
            /* POTENTIAL FLAW: Possibly over-write the initial value of data before using it */
            data = 10;
            IO.WriteLine("" + data);
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }

    /* goodB2G1() - use badsource and goodsink by changing the second switch to switch(8) */
    private void GoodB2G1()
    {
        int data;
        switch (6)
        {
        case 6:
            /* POTENTIAL FLAW: Initialize, but do not use data */
            data = 5;
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0;
            break;
        }
        switch (8)
        {
        case 7:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        default:
            /* FIX: Use data without over-writing its value */
            IO.WriteLine("" + data);
            break;
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the second switch  */
    private void GoodB2G2()
    {
        int data;
        switch (6)
        {
        case 6:
            /* POTENTIAL FLAW: Initialize, but do not use data */
            data = 5;
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0;
            break;
        }
        switch (7)
        {
        case 7:
            /* FIX: Use data without over-writing its value */
            IO.WriteLine("" + data);
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }

    public override void Good()
    {
        GoodG2B1();
        GoodG2B2();
        GoodB2G1();
        GoodB2G2();
    }
#endif //omitgood
}
}
