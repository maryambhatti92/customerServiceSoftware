using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SequwareWebapp.WebHelper
{
    public static class WebConfigReader
    {
        public static string WebServiceUrl
        {
            get { return ConfigurationManager.AppSettings["WebServiceUrl"].ToString(); }
        }
        public static string ConnectionStringAdoNet
        {
            get { return ConfigurationManager.ConnectionStrings["HrmsDbConnection"].ConnectionString; }
        }

        public static string CompletionEvalutionUrl
        {
            get { return ConfigurationManager.AppSettings["CompletionEvalutionUrl"].ToString(); }
        }

        public static string LiveSiteUrl
        {
            get { return ConfigurationManager.AppSettings["WebAppUrl"].ToString(); }
        }
        public static string LiveSiteUrlssl
        {
            get { return ConfigurationManager.AppSettings["WebAppUrlssl"].ToString(); }
        }


        //internal static string ImageDirPath
        //{
        //    get { return ConfigurationManager.AppSettings["ImageDirPath"].ToString(); }
        //}
        //internal static string VendorImageDirPath
        //{
        //    get { return ConfigurationManager.AppSettings["VendorImageDirPath"].ToString(); }
        //}
        //internal static string UserImageDirPath
        //{
        //    get { return ConfigurationManager.AppSettings["UserImageDirPath"].ToString(); }
        //}
        //internal static string DocsPath
        //{
        //    get { return ConfigurationManager.AppSettings["DocsPath"].ToString(); }
        //}
        //internal static string ClientDocsPath
        //{
        //    get { return ConfigurationManager.AppSettings["ClientDocsPath"].ToString(); }
        //}
        //internal static string BannerImagesPath
        //{
        //    get { return ConfigurationManager.AppSettings["BannerImagesPath"].ToString(); }
        //}
        //internal static string CheckListImagesPath
        //{
        //    get { return ConfigurationManager.AppSettings["CheckListImagesPath"].ToString(); }
        //}
        //internal static string FileDocumentsPath
        //{
        //    get { return ConfigurationManager.AppSettings["FileDocumentsPath"].ToString(); }
        //}
        //internal static string ImageDirPathRealtor
        //{
        //    get { return ConfigurationManager.AppSettings["ImageDirPathRealtor"].ToString(); }
        //}
        //internal static string Logo
        //{
        //    get { return ConfigurationManager.AppSettings["Logo"].ToString(); }
        //}
        //internal static string Banner
        //{
        //    get { return ConfigurationManager.AppSettings["Banner"].ToString(); }
        //}
        //internal static string ConfigFilePath
        //{
        //    get { return ConfigurationManager.AppSettings["ConfigFilePath"].ToString(); }
        //}
    }
}