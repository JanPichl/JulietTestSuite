/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE313_Cleartext_Storage_in_a_File_or_on_Disk__NetClient_53c.cs
Label Definition File: CWE313_Cleartext_Storage_in_a_File_or_on_Disk.label.xml
Template File: sources-sinks-53c.tmpl.cs
*/
/*
 * @description
 * CWE: 313 Cleartext storage in a File or on Disk
 * BadSource: NetClient Read data from a web server with WebClient
 * GoodSource: A hardcoded string
 * Sinks:
 *    GoodSink: Hash data before storing in registry
 *    BadSink : Store data directly in a file
 * Flow Variant: 53 Data flow: data passed as an argument from one method through two others to a fourth; all four functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Web;

namespace testcases.CWE313_Cleartext_Storage_in_a_File_or_on_Disk
{
class CWE313_Cleartext_Storage_in_a_File_or_on_Disk__NetClient_53c
{
#if (!OMITBAD)
    public static void BadSink(string data )
    {
        CWE313_Cleartext_Storage_in_a_File_or_on_Disk__NetClient_53d.BadSink(data );
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string data )
    {
        CWE313_Cleartext_Storage_in_a_File_or_on_Disk__NetClient_53d.GoodG2BSink(data );
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(string data )
    {
        CWE313_Cleartext_Storage_in_a_File_or_on_Disk__NetClient_53d.GoodB2GSink(data );
    }
#endif
}
}
