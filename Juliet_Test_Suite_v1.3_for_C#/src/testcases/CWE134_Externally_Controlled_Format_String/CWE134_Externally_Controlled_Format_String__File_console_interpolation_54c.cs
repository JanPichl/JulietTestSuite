/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE134_Externally_Controlled_Format_String__File_console_interpolation_54c.cs
Label Definition File: CWE134_Externally_Controlled_Format_String.label.xml
Template File: sources-sinks-54c.tmpl.cs
*/
/*
 * @description
 * CWE: 134 Externally Controlled Format String
 * BadSource: File Read data from file (named data.txt)
 * GoodSource: A hardcoded string
 * Sinks: console_interpolation
 *    GoodSink: console write with interpolation
 *    BadSink : console write formatted without validation
 * Flow Variant: 54 Data flow: data passed as an argument from one method through three others to a fifth; all five functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE134_Externally_Controlled_Format_String
{
class CWE134_Externally_Controlled_Format_String__File_console_interpolation_54c
{
#if (!OMITBAD)
    public static void BadSink(string data )
    {
        CWE134_Externally_Controlled_Format_String__File_console_interpolation_54d.BadSink(data );
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string data )
    {
        CWE134_Externally_Controlled_Format_String__File_console_interpolation_54d.GoodG2BSink(data );
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(string data )
    {
        CWE134_Externally_Controlled_Format_String__File_console_interpolation_54d.GoodB2GSink(data );
    }
#endif
}
}
