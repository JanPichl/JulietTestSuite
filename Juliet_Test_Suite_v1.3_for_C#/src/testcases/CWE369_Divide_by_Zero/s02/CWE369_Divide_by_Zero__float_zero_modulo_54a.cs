/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE369_Divide_by_Zero__float_zero_modulo_54a.cs
Label Definition File: CWE369_Divide_by_Zero__float.label.xml
Template File: sources-sinks-54a.tmpl.cs
*/
/*
 * @description
 * CWE: 369 Divide by zero
 * BadSource: zero Set data to a hardcoded value of zero
 * GoodSource: A hardcoded non-zero number (two)
 * Sinks: modulo
 *    GoodSink: Check for zero before modulo
 *    BadSink : Modulo by a value that may be zero
 * Flow Variant: 54 Data flow: data passed as an argument from one method through three others to a fifth; all five functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE369_Divide_by_Zero
{
class CWE369_Divide_by_Zero__float_zero_modulo_54a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        float data;
        data = 0.0f; /* POTENTIAL FLAW: data is set to zero */
        CWE369_Divide_by_Zero__float_zero_modulo_54b.BadSink(data );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        float data;
        /* FIX: Use a hardcoded number that won't a divide by zero */
        data = 2.0f;
        CWE369_Divide_by_Zero__float_zero_modulo_54b.GoodG2BSink(data );
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        float data;
        data = 0.0f; /* POTENTIAL FLAW: data is set to zero */
        CWE369_Divide_by_Zero__float_zero_modulo_54b.GoodB2GSink(data );
    }
#endif //omitgood
}
}
