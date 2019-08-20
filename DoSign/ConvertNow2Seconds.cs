using System.Globalization;
using System.Management.Automation;

namespace DoSign
{
    [Cmdlet(VerbsData.Convert, "NowtoSeconds")]

    public class ConvertNow2Seconds : Cmdlet
    {

        private string Result { get; set; }

        protected override void BeginProcessing()
        {
            Result = string.Empty;
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            Result = UnixTime.ConvertNowToUnixTimestamp().ToString(CultureInfo.InvariantCulture);
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
            base.StopProcessing();
        }
    }
}