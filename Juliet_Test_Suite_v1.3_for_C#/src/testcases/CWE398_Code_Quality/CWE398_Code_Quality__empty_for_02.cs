/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__empty_for_02.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-02.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: empty_for
*    GoodSink: For statement contains code
*    BadSink : An empty for statement has no effect
* Flow Variant: 02 Control flow: if(true) and if(false)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__empty_for_02 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (true)
        {
            /* FLAW: An empty for statement has no effect */
            for (int i = 0; i < 10; i++)
            {
            }
            IO.WriteLine("Hello from Bad()");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes true to false */
    private void Good1()
    {
        if (false)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Do not include an empty for statement */
            for (int i = 0; i < 10; i++)
            {
                IO.WriteLine("Inside the for statement");
            }
            IO.WriteLine("Hello from Good()");
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (true)
        {
            /* FIX: Do not include an empty for statement */
            for (int i = 0; i < 10; i++)
            {
                IO.WriteLine("Inside the for statement");
            }
            IO.WriteLine("Hello from Good()");
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
