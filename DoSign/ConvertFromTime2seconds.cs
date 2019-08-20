using System.Globalization;
using System.Management.Automation;

namespace DoSign
{
    [Cmdlet(VerbsData.Convert, "TimeFromSeconds")]

    public class ConvertTimeFromSeconds : Cmdlet
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
            double tmp;
            if (double.TryParse(Input, out tmp))
            {
                Result = UnixTime.ConvertFromUnixTimestamp(tmp).ToString(CultureInfo.InvariantCulture);
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