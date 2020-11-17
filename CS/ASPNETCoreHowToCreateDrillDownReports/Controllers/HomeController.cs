using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASPNETCoreHowToCreateDrillDownReports.Controllers {
    public class HomeController : Controller {        
        public async Task<IActionResult> Index([FromQuery] string reportName = "MainReport") {
            var modelGenerator = new WebDocumentViewerClientSideModelGenerator(HttpContext.RequestServices);
            var model = await modelGenerator.GetModelAsync(reportName, WebDocumentViewerController.DefaultUri);
            return View(model);
        }
    }
}