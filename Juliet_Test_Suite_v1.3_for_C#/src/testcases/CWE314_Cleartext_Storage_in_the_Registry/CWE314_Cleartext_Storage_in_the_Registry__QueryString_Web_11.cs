/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE314_Cleartext_Storage_in_the_Registry__QueryString_Web_11.cs
Label Definition File: CWE314_Cleartext_Storage_in_the_Registry.label.xml
Template File: sources-sinks-11.tmpl.cs
*/
/*
* @description
* CWE: 314 Cleartext storage in the registry
* BadSource: QueryString_Web Parse id param out of the URL query string (without using getParameter())
* GoodSource: A hardcoded string
* Sinks:
*    GoodSink: Hash data before storing in registry
*    BadSink : Store data directly in registry
* Flow Variant: 11 Control flow: if(IO.StaticReturnsTrue()) and if(IO.StaticReturnsFalse())
*
* */

using TestCaseSupport;
using System;

using Microsoft.Win32;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace testcases.CWE314_Cleartext_Storage_in_the_Registry
{
class CWE314_Cleartext_Storage_in_the_Registry__QueryString_Web_11 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (IO.StaticReturnsTrue())
        {
            data = ""; /* initialize data in case id is not in query string */
            /* POTENTIAL FLAW: Parse id param out of the URL querystring (without using getParameter()) */
            {
                if (req.QueryString["id"] != null)
                {
                    data = req.QueryString["id"];
                }
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if(IO.StaticReturnsTrue())
        {
            using (SecureString secureData = new SecureString())
            {
                for (int i = 0; i < data.Length; i++)
                {
                    secureData.AppendChar(data[i]);
                }
                /* POTENTIAL FLAW: Store data directly in registry */
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                key.CreateSubKey("CWEparent");
                key = key.OpenSubKey("CWEparent", true);
                key.CreateSubKey("TestingCWE");
                key = key.OpenSubKey("TestingCWE", true);
                key.SetValue("CWE", secureData);
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing first IO.StaticReturnsTrue() to IO.StaticReturnsFalse() */
    private void GoodG2B1(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (IO.StaticReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        else
        {
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        if (IO.StaticReturnsTrue())
        {
            using (SecureString secureData = new SecureString())
            {
                for (int i = 0; i < data.Length; i++)
                {
                    secureData.AppendChar(data[i]);
                }
                /* POTENTIAL FLAW: Store data directly in registry */
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                key.CreateSubKey("CWEparent");
                key = key.OpenSubKey("CWEparent", true);
                key.CreateSubKey("TestingCWE");
                key = key.OpenSubKey("TestingCWE", true);
                key.SetValue("CWE", secureData);
            }
        }
    }

    /* GoodG2B2() - use goodsource and badsink by reversing statements in first if */
    private void GoodG2B2(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (IO.StaticReturnsTrue())
        {
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (IO.StaticReturnsTrue())
        {
            using (SecureString secureData = new SecureString())
            {
                for (int i = 0; i < data.Length; i++)
                {
                    secureData.AppendChar(data[i]);
                }
                /* POTENTIAL FLAW: Store data directly in registry */
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                key.CreateSubKey("CWEparent");
                key = key.OpenSubKey("CWEparent", true);
                key.CreateSubKey("TestingCWE");
                key = key.OpenSubKey("TestingCWE", true);
                key.SetValue("CWE", secureData);
            }
        }
    }

    /* goodB2G1() - use badsource and goodsink by changing second IO.StaticReturnsTrue() to IO.StaticReturnsFalse() */
    private void GoodB2G1(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (IO.StaticReturnsTrue())
        {
            data = ""; /* initialize data in case id is not in query string */
            /* POTENTIAL FLAW: Parse id param out of the URL querystring (without using getParameter()) */
            {
                if (req.QueryString["id"] != null)
                {
                    data = req.QueryString["id"];
                }
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (IO.StaticReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Hash data before storing in registry */
            {
                string salt = "ThisIsMySalt";
                using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(string.Concat(salt, data));
                    byte[] hashedCredsAsBytes = sha512.ComputeHash(buffer);
                    data = IO.ToHex(hashedCredsAsBytes);
                }
            }
            using (SecureString secureData = new SecureString())
            {
                for (int i = 0; i < data.Length; i++)
                {
                    secureData.AppendChar(data[i]);
                }
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                key.CreateSubKey("CWEparent");
                key = key.OpenSubKey("CWEparent", true);
                key.CreateSubKey("TestingCWE");
                key = key.OpenSubKey("TestingCWE", true);
                key.SetValue("CWE", secureData);
            }
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing statements in second if  */
    private void GoodB2G2(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (IO.StaticReturnsTrue())
        {
            data = ""; /* initialize data in case id is not in query string */
            /* POTENTIAL FLAW: Parse id param out of the URL querystring (without using getParameter()) */
            {
                if (req.QueryString["id"] != null)
                {
                    data = req.QueryString["id"];
                }
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (IO.StaticReturnsTrue())
        {
            /* FIX: Hash data before storing in registry */
            {
                string salt = "ThisIsMySalt";
                using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(string.Concat(salt, data));
                    byte[] hashedCredsAsBytes = sha512.ComputeHash(buffer);
                    data = IO.ToHex(hashedCredsAsBytes);
                }
            }
            using (SecureString secureData = new SecureString())
            {
                for (int i = 0; i < data.Length; i++)
                {
                    secureData.AppendChar(data[i]);
                }
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                key.CreateSubKey("CWEparent");
                key = key.OpenSubKey("CWEparent", true);
                key.CreateSubKey("TestingCWE");
                key = key.OpenSubKey("TestingCWE", true);
                key.SetValue("CWE", secureData);
            }
        }
    }

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B1(req, resp);
        GoodG2B2(req, resp);
        GoodB2G1(req, resp);
        GoodB2G2(req, resp);
    }
#endif //omitgood
}
}
