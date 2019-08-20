using System;
using System.Globalization;
using System.Management.Automation;

namespace DoSign
{
    [Cmdlet(VerbsData.Convert, "TimetoSeconds")]

    public class ConvertTime2Seconds : Cmdlet
    {
        [Parameter(HelpMessage = "string", Mandatory = false)]
        [ValidateLength(6, 30)]
        [Alias("string")]
        public string Input { get; set; }


        private string Result { get; set; }

        protected override void BeginProcessing()
        {
            Result = string.Empty;
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            try
            {
                DateTime dt;
                if (DateTime.TryParse(Input, out dt))
                {
                    Result = UnixTime.ConvertToUnixTimestamp(dt).ToString(CultureInfo.InvariantCulture);
                }

            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(new Exception($"There was a problem while trying to parse the data with msj {ex.Message}"), "-1", ErrorCategory.InvalidData, null));
            }

            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            WriteObject(Result);
            base.EndProcessing();
        }

        protected override void StopProcessing()
        {
            Result = string.Empty;
            Input = string.Empty;
            base.StopProcessing();
        }
    }
}