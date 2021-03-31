using khoiuploader.Models;
using khoiuploader.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace khoiuploader.Controllers
{
    public class KntController : Controller
    {
        // GET: Knt
        public ActionResult Index()
        {
            return View();
        }

        [Route("upload")]
        [HttpPost]
        public ActionResult Upload(MemberModel model)
        {
            UploadHandler _uploadHandler = new UploadHandler();

            string error = "";
            _ = _uploadHandler.Upload(model, ref error) == true ? ViewBag.Res = "Success" : ViewBag.Res = error;

            return View();
        }
    }
}