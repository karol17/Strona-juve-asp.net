using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace juve.Infrastructure
{
    public static class ImageHelpers
    {
        public static string ImagePath(this UrlHelper helper, string imageName)
        {
            var imageFolder = AppConfig.ObrazkiFolderWzgledny;
            var path = Path.Combine(imageFolder, imageName);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}