using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace customerServiceSoftware
{
  public  class AppConfigReader
    {

        public static string WebServiceUrl
        {
            get { return ConfigurationManager.AppSettings["WebServiceUrl"].ToString(); }

           
             
        }

        public static string CompletionEvalutionUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["CompletionEvalutionUrl"].ToString();                
            }

        }

        public static string CompanyConfigurationStatus
        {
            get
            {
                return ConfigurationManager.AppSettings["COMPCONFIGURATION"].ToString();
            }

        }
        public static string CompanyId
        {
            get
            {
                return ConfigurationManager.AppSettings["COMPID"].ToString();
            }

        }
        public static string CompanyName
        {
            get
            {
                return ConfigurationManager.AppSettings["COMPNAME"].ToString();
            }

        }
        public static string CompanyLiscense
        {
            get
            {
                return ConfigurationManager.AppSettings["COMPLISCENCE"].ToString();
            }

        }
    }
}
