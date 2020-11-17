using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using ASPNETCoreHowToCreateDrillDownReports;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingAppAsyncServices.PredefinedReports
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["MainReport"] = () => new MainReport(),
            ["DetailReport1"] = () => new Details()
        };
    }
}
