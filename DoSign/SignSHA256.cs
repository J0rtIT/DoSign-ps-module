using System;
using System.Globalization;
using System.Management.Automation;
using System.Security.Cryptography;
using System.Text;

namespace DoSign
{

    [Cmdlet(VerbsCommon.Get, "Signed")]
    public class SignSha256 : Cmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0)]
        public string Secret { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 1)]
        public string String2Sign { get; set; }

        private bool WillUseRandom { get; set; }
        private string Result { get; set; }

        private TheResult Resultant { get; set; }



        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 2)]
        [ValidateSet("SHA1", "SHA256", "SHA384", "SHA512")]
        public string Algorithm { get; set; }
        #region Functions
        private static string GetStringFromHash(byte[] hash)
        {
            //another way https://stackoverflow.com/questions/8766038/how-to-convert-c-sharp-hashed-byte-array-to-string-for-passing-to-api
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2", CultureInfo.InvariantCulture));
            }
            return result.ToString().ToLower();
        }
        #endregion

        protected override void BeginProcessing()
        {
            WillUseRandom = string.IsNullOrEmpty(Secret);
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            switch (Algorithm)
            {
                case "SHA1":
                    if (WillUseRandom)
                    {
                        Result = GetStringFromHash(new HMACSHA1().ComputeHash(Encoding.UTF8.GetBytes(String2Sign)));
                    }
                    else
                    {
                        Result = GetStringFromHash(new HMACSHA1(Encoding.UTF8.GetBytes(Secret)).ComputeHash(Encoding.UTF8.GetBytes(String2Sign)));
                    }
                    break;

                case "SHA256":
                    if (WillUseRandom)
                    {
                        Result = GetStringFromHash(new HMACSHA256().ComputeHash(Encoding.UTF8.GetBytes(String2Sign)));
                    }
                    else
                    {
                        Result = GetStringFromHash(new HMACSHA256(Encoding.UTF8.GetBytes(Secret)).ComputeHash(Encoding.UTF8.GetBytes(String2Sign)));
                    }
                    break;

                case "SHA384":
                    if (WillUseRandom)
                    {
                        Result = GetStringFromHash(new HMACSHA384().ComputeHash(Encoding.UTF8.GetBytes(String2Sign)));
                    }
                    else
                    {
                        Result = GetStringFromHash(new HMACSHA384(Encoding.UTF8.GetBytes(Secret)).ComputeHash(Encoding.UTF8.GetBytes(String2Sign)));
                    }
                    break;

                case "SHA512":
                    if (WillUseRandom)
                    {
                        Result = GetStringFromHash(new HMACSHA512().ComputeHash(Encoding.UTF8.GetBytes(String2Sign)));
                    }
                    else
                    {
                        Result = GetStringFromHash(new HMACSHA512(Encoding.UTF8.GetBytes(Secret)).ComputeHash(Encoding.UTF8.GetBytes(String2Sign)));
                    }
                    break;

                default:
                    Result = "Invalid Entry";
                    break;
            }

            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            Resultant = new TheResult
            {
                Algorithm = Algorithm,
                Result = Result,
                Key = string.IsNullOrWhiteSpace(Secret) ? "Random" : Secret
            };

            WriteObject(Resultant);
            base.EndProcessing();
        }

        protected override void StopProcessing()
        {
            WriteError(new ErrorRecord(new Exception("The Command was interrupted"), null, ErrorCategory.FromStdErr, null));
            base.StopProcessing();
        }

        //Examnple1 in https://www.instagram.com/developer/secure-api-requests/
        //result
        /*
         Key                              Algorithm Result
        ---                              --------- ------
        6dc1787668c64c939929c17683d7cb74 SHA256    cbf5a1f41db44412506cb6563a3218b50f45a710c7a8a65a3e9b18315bb338bf 
         */

    }
}
