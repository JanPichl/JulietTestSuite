/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE315_Cleartext_Storage_in_Cookie__Web_68a.cs
Label Definition File: CWE315_Cleartext_Storage_in_Cookie__Web.label.xml
Template File: sources-sinks-68a.tmpl.cs
*/
/*
 * @description
 * CWE: 315 Cleartext storage of data in a cookie
 * BadSource:  Set data to credentials (without hashing or encryption)
 * GoodSource: Set data to a hash of credentials
 * Sinks:
 *    GoodSink: Hash data before storing in cookie
 *    BadSink : Store data directly in cookie
 * Flow Variant: 68 Data flow: data passed as a member variable in the "a" class, which is used by a method in another class in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Security.Cryptography;
using System.Text;
using System.Web;

using System.Security;

namespace testcases.CWE315_Cleartext_Storage_in_Cookie
{
class CWE315_Cleartext_Storage_in_Cookie__Web_68a : AbstractTestCaseWeb
{

    public static string data;
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        using (SecureString securePwd = new SecureString())
        {
            using (SecureString secureUser = new SecureString())
            {
                for (int i = 0; i < "AP@ssw0rd".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("AP@ssw0rd"[i]);
                }
                for (int i = 0; i < "user".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("user"[i]);
                }
                /* POTENTIAL FLAW: Set data to credentials (without hashing or encryption) */
                data = secureUser.ToString() + ":" + securePwd.ToString();
            }
        }
        CWE315_Cleartext_Storage_in_Cookie__Web_68b.BadSink(req, resp);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
        GoodB2G(req, resp);
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        using (SecureString securePwd = new SecureString())
        {
            using( SecureString secureUser = new SecureString())
            {
                for (int i = 0; i < "AP@ssw0rd".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("AP@ssw0rd"[i]);
                }
                for (int i = 0; i < "user".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("user"[i]);
                }
                /* FIX: Set data to a hash of credentials */
                {
                    string salt = "ThisIsMySalt";
                    using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
                    {
                        string credentialsToHash = secureUser.ToString() + ":" + securePwd.ToString();
                        byte[] buffer = Encoding.UTF8.GetBytes(string.Concat(salt, credentialsToHash));
                        byte[] hashedCredsAsBytes = sha512.ComputeHash(buffer);
                        data = IO.ToHex(hashedCredsAsBytes);
                    }
                }
            }
        }
        CWE315_Cleartext_Storage_in_Cookie__Web_68b.GoodG2BSink(req, resp);
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        using (SecureString securePwd = new SecureString())
        {
            using (SecureString secureUser = new SecureString())
            {
                for (int i = 0; i < "AP@ssw0rd".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("AP@ssw0rd"[i]);
                }
                for (int i = 0; i < "user".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("user"[i]);
                }
                /* POTENTIAL FLAW: Set data to credentials (without hashing or encryption) */
                data = secureUser.ToString() + ":" + securePwd.ToString();
            }
        }
        CWE315_Cleartext_Storage_in_Cookie__Web_68b.GoodB2GSink(req, resp);
    }
#endif //omitgood
}
}
