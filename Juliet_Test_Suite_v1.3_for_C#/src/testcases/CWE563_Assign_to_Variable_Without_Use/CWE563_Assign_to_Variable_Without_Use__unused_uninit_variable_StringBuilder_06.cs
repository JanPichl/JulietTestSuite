/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE563_Assign_to_Variable_Without_Use__unused_uninit_variable_StringBuilder_06.cs
Label Definition File: CWE563_Assign_to_Variable_Without_Use__unused_uninit_variable.label.xml
Template File: source-sinks-06.tmpl.cs
*/
/*
* @description
* CWE: 563 Assignment to Variable without Use
* BadSource:  don't initialize data
* Sinks:
*    GoodSink: init and use data
*    BadSink : do nothing
* Flow Variant: 06 Control flow: if(PRIVATE_CONST_FIVE==5) and if(PRIVATE_CONST_FIVE!=5)
*
* */

using TestCaseSupport;
using System;

using System.Text;

namespace testcases.CWE563_Assign_to_Variable_Without_Use
{
class CWE563_Assign_to_Variable_Without_Use__unused_uninit_variable_StringBuilder_06 : AbstractTestCase
{
    /* The variable below is declared "const", so a tool should be able
     * to identify that reads of this will always give its initialized
     * value.
     */
    private const int PRIVATE_CONST_FIVE = 5;
#if (!OMITBAD)
    public override void Bad()
    {
        StringBuilder data;
        /* POTENTIAL FLAW: Don't initialize or use data */
        ; /* empty statement needed for some flow variants */
        if (PRIVATE_CONST_FIVE == 5)
        {
            /* FLAW: Don't initialize or use data */
            /* do nothing */
            ; /* empty statement needed for some flow variants */
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodB2G1() - use badsource and goodsink by changing PRIVATE_CONST_FIVE==5 to PRIVATE_CONST_FIVE!=5 */
    private void GoodB2G1()
    {
        StringBuilder data;
        /* POTENTIAL FLAW: Don't initialize or use data */
        ; /* empty statement needed for some flow variants */
        if (PRIVATE_CONST_FIVE != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Initialize then use data */
            data = new StringBuilder("Good");
            IO.WriteLine(data.ToString());
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing statements in if  */
    private void GoodB2G2()
    {
        StringBuilder data;
        /* POTENTIAL FLAW: Don't initialize or use data */
        ; /* empty statement needed for some flow variants */
        if (PRIVATE_CONST_FIVE == 5)
        {
            /* FIX: Initialize then use data */
            data = new StringBuilder("Good");
            IO.WriteLine(data.ToString());
        }
    }

    public override void Good()
    {
        GoodB2G1();
        GoodB2G2();
    }
#endif //omitgood
}
}
