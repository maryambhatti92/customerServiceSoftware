using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using css.Data.Models;

namespace customerServiceSoftware
{
    [RunInstaller(true)]
    public partial class InstallerSetup : System.Configuration.Install.Installer
    {
        public InstallerSetup()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            try
            {
                RegisterCompany();
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message);
                base.Rollback(savedState);
            }
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }

        private void showParameters()
        {
          //  Debugger.Launch();
            StringBuilder sb = new StringBuilder();
            StringDictionary myStringDictionary = this.Context.Parameters;
            if (this.Context.Parameters.Count > 0)
            {
                foreach (string myString in this.Context.Parameters.Keys)
                {
                    sb.AppendFormat("String={0} Value= {1}\n", myString,
                    this.Context.Parameters[myString]);
                }
            }
            MessageBox.Show(sb.ToString());
        }

        private void RegisterCompany()
        {
            try
            {
               // Debugger.Launch();
                tbl_Company company = new tbl_Company();

                string COMPNAME = Context.Parameters["COMPNAME"];              
                string COMPID = Context.Parameters["COMPID"];
                // string COMPLISCENCE = Context.Parameters["COMPLSC"];
                // string TEST = Context.Parameters["TEST"];

                COMPNAME = COMPNAME.Substring(1, COMPNAME.Length - 2);
                COMPID = COMPID.Substring(1, COMPID.Length - 2);

                if (COMPNAME != "" && COMPID != "")
                {

                    // Get the path to the executable file that is being installed on the target computer  
                    string assemblypath = Context.Parameters["assemblypath"];
                    string appConfigPath = assemblypath + ".config";

                    // Write the path to the app.config file  
                    XmlDocument doc = new XmlDocument();
                    doc.Load(appConfigPath);

                    XmlNode configuration = null;
                    foreach (XmlNode node in doc.ChildNodes)
                        if (node.Name == "configuration")
                            configuration = node;

                    if (configuration != null)
                    {
                        //MessageBox.Show("configuration != null");  
                        // Get the ‘appSettings’ node  
                        XmlNode settingNode = null;
                        foreach (XmlNode node in configuration.ChildNodes)
                        {
                            if (node.Name == "appSettings")
                                settingNode = node;
                        }

                        if (settingNode != null)
                        {
                            //MessageBox.Show("settingNode != null");  
                            //Reassign values in the config file  
                            foreach (XmlNode node in settingNode.ChildNodes)
                            {
                                //MessageBox.Show("node.Value = " + node.Value);  
                                if (node.Attributes == null)
                                    continue;
                                XmlAttribute attribute = node.Attributes["value"];
                                //MessageBox.Show("attribute != null ");  
                                //MessageBox.Show("node.Attributes['value'] = " + node.Attributes["value"].Value);  
                                if (node.Attributes["key"] != null)
                                {
                                    //MessageBox.Show("node.Attributes['key'] != null ");  
                                    //MessageBox.Show("node.Attributes['key'] = " + node.Attributes["key"].Value);  
                                    switch (node.Attributes["key"].Value)
                                    {
                                        case "COMPID":
                                            attribute.Value = COMPID ;
                                            break;
                                        //case "COMPNAME":
                                        //    attribute.Value = COMPNAME;
                                        //    break;
                                        case "COMPLISCENCE":
                                            attribute.Value = COMPNAME;
                                            break;
                                    }
                                }
                            }
                        }
                        doc.Save(appConfigPath);
                    }
                }
                else

                {
                    throw new System.ArgumentException("All required fields not entered", "Installation Error");

                }


            }
            catch
            {

                throw;
            }
        }
    }
}



//company.Comapany_Name = COMPNAME;
//company.Address = COMPADDRESS;
//company.Email = COMPEMAIL;
//if (COMPID != "")
//{
//    company.Company_id = Convert.ToInt32(COMPID);
//}
//else
//{
//    company.Company_id = 0;
//}

//string result = TabClasses.CompanyOperations.AddCompanyData(company);
//MessageBox.Show(result);