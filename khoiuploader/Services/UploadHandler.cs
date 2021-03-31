using khoiuploader.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace khoiuploader.Services
{
    public class UploadHandler
    {
        public bool Upload(MemberModel model, ref string error)
        {
            try
            {
                var _fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);

                string _fileExtension = Path.GetExtension(model.ImageFile.FileName);

                _fileName = DateTime.Now.ToString("ddMMyyyy") + _fileName.Trim() + _fileExtension;

                var _uploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
                var _combinePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _uploadPath);

                var _imagePath = _combinePath + _fileName;

                model.ImageFile.SaveAs(_imagePath);
            }
            catch (Exception exception_1)
            {
                error = exception_1.Message;
                return false;
            }
            return true;
        }
    }
}