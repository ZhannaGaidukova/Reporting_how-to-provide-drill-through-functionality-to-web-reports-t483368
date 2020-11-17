using ASPNETCoreHowToCreateDrillDownReports;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingAppAsyncServices.Services {
    public class NavigateInfo { 
        public string NavigateTo { get; set; }
        public string MasterID { get; set; }
    }
    public class CustomDrillThroughProcessorAsync : IDrillThroughProcessorAsync {
        public Task<DrillThroughResult> CreateReportAsync(DrillThroughContext context) {
            var report = context.Report;

            NavigateInfo navigateInfo = JsonSerializer.Deserialize<NavigateInfo>(context.CustomData);
            if (navigateInfo.NavigateTo == "back")
                report = new MainReport();
            else
                if (navigateInfo.NavigateTo == "details") {
                report = new Details();
                int catID = 0;
                string catName = "";
                Int32.TryParse(navigateInfo.MasterID, out catID);
                report.Parameters["categoryID"].Value = catID;
            }
            return Task.FromResult(new DrillThroughResult(report));
        }
    }
}
