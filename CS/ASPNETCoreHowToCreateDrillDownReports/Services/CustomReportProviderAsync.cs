using System;
using System.IO;
using System.Threading.Tasks;
using DevExpress.XtraReports.Services;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Extensions;
using ReportingAppAsyncServices.PredefinedReports;

namespace ReportingAppAsyncServices.Services
{
    public class CustomReportProviderAsync : IReportProviderAsync
    {
        readonly ReportStorageWebExtension reportStorageWebExtension;

        public CustomReportProviderAsync(ReportStorageWebExtension reportStorageWebExtension)
        {
            this.reportStorageWebExtension = reportStorageWebExtension;
        }
        public async Task<XtraReport> GetReportAsync(string id, ReportProviderContext context)
        {
            byte[] reportLayout = await GetDataAsync(id);
            if (reportLayout == null)
                return null;
            using (var ms = new MemoryStream(reportLayout))
            {
                var report = XtraReport.FromXmlStream(ms);
                return report;
            }
        }

        private Task<byte[]> GetDataAsync(string id) {
            if (ReportsFactory.Reports.ContainsKey(id)) {
                    using (MemoryStream ms = new MemoryStream()) {
                        ReportsFactory.Reports[id]().SaveLayoutToXml(ms);
                        return Task.FromResult(ms.ToArray());
                    }
            }
            return null;
        }
    }
}
