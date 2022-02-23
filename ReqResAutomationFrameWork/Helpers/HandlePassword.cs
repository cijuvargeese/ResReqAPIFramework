using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqResAutomationFrameWork.Helpers
{
	class HandlePassword
	{
		public static string DecryptString(string encrString)
        {
            byte[] bytearray;
            string decrypted;
            try
            {
                bytearray = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(bytearray);
            }
            catch (FormatException e)
            {
                decrypted = null;
                Console.WriteLine(e.Message);
            }
            return decrypted;
        }

        public static string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}
