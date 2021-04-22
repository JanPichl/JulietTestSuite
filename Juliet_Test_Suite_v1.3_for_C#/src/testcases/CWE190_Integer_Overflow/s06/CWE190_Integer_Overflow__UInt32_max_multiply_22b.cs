/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__UInt32_max_multiply_22b.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-22b.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: max Set data to the max value for uint
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: multiply
 *    GoodSink: Ensure there will not be an overflow before multiplying data by 2
 *    BadSink : If data is positive, multiply by 2, which can cause an overflow
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__UInt32_max_multiply_22b
{
#if (!OMITBAD)
    public static void BadSink(uint data )
    {
        if (CWE190_Integer_Overflow__UInt32_max_multiply_22a.badPublicStatic)
        {
            if(data > 0) /* ensure we won't have an underflow */
            {
                /* POTENTIAL FLAW: if (data*2) > uint.MaxValue, this will overflow */
                uint result = (uint)(data * 2);
                IO.WriteLine("result: " + result);
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0u;
        }
    }
#endif

#if (!OMITGOOD)
    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    public static void GoodB2G1Sink(uint data )
    {
        if (CWE190_Integer_Overflow__UInt32_max_multiply_22a.goodB2G1PublicStatic)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0u;
        }
        else
        {
            if(data > 0) /* ensure we won't have an underflow */
            {
                /* FIX: Add a check to prevent an overflow from occurring */
                if (data < (uint.MaxValue/2))
                {
                    uint result = (uint)(data * 2);
                    IO.WriteLine("result: " + result);
                }
                else
                {
                    IO.WriteLine("data value is too large to perform multiplication.");
                }
            }
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    public static void GoodB2G2Sink(uint data )
    {
        if (CWE190_Integer_Overflow__UInt32_max_multiply_22a.goodB2G2PublicStatic)
        {
            if(data > 0) /* ensure we won't have an underflow */
            {
                /* FIX: Add a check to prevent an overflow from occurring */
                if (data < (uint.MaxValue/2))
                {
                    uint result = (uint)(data * 2);
                    IO.WriteLine("result: " + result);
                }
                else
                {
                    IO.WriteLine("data value is too large to perform multiplication.");
                }
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0u;
        }
    }

    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(uint data )
    {
        if (CWE190_Integer_Overflow__UInt32_max_multiply_22a.goodG2BPublicStatic)
        {
            if(data > 0) /* ensure we won't have an underflow */
            {
                /* POTENTIAL FLAW: if (data*2) > uint.MaxValue, this will overflow */
                uint result = (uint)(data * 2);
                IO.WriteLine("result: " + result);
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0u;
        }
    }
#endif
}
}
