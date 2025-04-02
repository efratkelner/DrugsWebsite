
    using DriveUpload.Models;
    using System.Web;
    using System.Web.Mvc;

    namespace DriveUpload.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Index(HttpPostedFileBase file)
            {
                GoogleDriveAPIHelper.UplaodFileOnDrive(file);
                ViewBag.Success = "File Uploaded on Google Drive";
                return View();
            }
        }
    }