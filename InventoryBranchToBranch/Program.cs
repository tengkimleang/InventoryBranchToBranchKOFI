using System;
using System.Collections.Generic;
using SAPbouiCOM.Framework;
using InventoryBranchToBranch.Connection;
using System.Configuration;

namespace InventoryBranchToBranch
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Application oApp = null;
                ConnectionString.SqlConnectionSap = ConfigurationManager.AppSettings["connectionString"];
                ConnectionString.DbServerType = ConfigurationManager.AppSettings["DbServerType"];
                ConnectionString.Server = ConfigurationManager.AppSettings["Server"];
                ConnectionString.LicenseServer = ConfigurationManager.AppSettings["LicenseServer"];
                ConnectionString.SLDServer = ConfigurationManager.AppSettings["SLDServer"];
                ConnectionString.DbUserName = ConfigurationManager.AppSettings["DbUserName"];
                ConnectionString.DbPassword = ConfigurationManager.AppSettings["DbPassword"];
                ConnectionString.CompanyDB = ConfigurationManager.AppSettings["CompanyDB"];
                ConnectionString.UserName = ConfigurationManager.AppSettings["UserNameSAP"];
                ConnectionString.Password = ConfigurationManager.AppSettings["Password"];
                if (args.Length < 1)
                {
                    oApp = new Application();
                }
                else
                {
                    oApp = new Application(args[0]);
                }
                Menu MyMenu = new Menu();
                MyMenu.AddMenuItems();
                oApp.RegisterMenuEventHandler(MyMenu.SBO_Application_MenuEvent);
                Application.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(SBO_Application_AppEvent);
                oApp.Run();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static void SBO_Application_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    //Exit Add-On
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    break;
                default:
                    break;
            }
        }
    }
}
