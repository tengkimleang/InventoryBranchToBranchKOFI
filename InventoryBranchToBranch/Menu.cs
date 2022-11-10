using System;
using System.Collections.Generic;
using System.Text;
using SAPbouiCOM.Framework;
using System.Threading;
using System.Configuration;
using InventoryBranchToBranch.Connection;

namespace InventoryBranchToBranch
{
    public class Menu
    {
        public static SAPbouiCOM.Application application;
        public Menu()
        {
            
        }
        public void AddMenuItems()
        {
            SAPbouiCOM.Menus oMenus = null;
            SAPbouiCOM.MenuItem oMenuItem = null;
            oMenus = Application.SBO_Application.Menus;
            application = Application.SBO_Application;
            SAPbouiCOM.MenuCreationParams oCreationPackage = null;
            oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
            oMenuItem = Application.SBO_Application.Menus.Item("43520"); // moudles'

            oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
            oCreationPackage.UniqueID = "InventoryBranchToBranch";
            oCreationPackage.String = "InventoryBranchToBranch";
            oCreationPackage.Enabled = true;
            oCreationPackage.Position = -1;

            oMenus = oMenuItem.SubMenus;

            try
            {
                //  If the manu already exists this code will fail
                oMenus.AddEx(oCreationPackage);
            }
            catch (Exception e)
            {

            }

            try
            {
                // Get the menu collection of the newly added pop-up item
                oMenuItem = Application.SBO_Application.Menus.Item("InventoryBranchToBranch");
                oMenus = oMenuItem.SubMenus;

                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "InventoryBranchToBranch.InventoryTransferBranchToBranch";
                oCreationPackage.String = "InventoryTransferBranchToBranch";
                oMenus.AddEx(oCreationPackage);
            }
            catch (Exception er)
            { //  Menu already exists
                Application.SBO_Application.SetStatusBarMessage("Menu Already Exists", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }
        }

        public void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction && pVal.MenuUID == "InventoryBranchToBranch.InventoryTransferBranchToBranch")
                {
                    //Form1 activeForm = new Form1();
                    //activeForm.Show();
                    Thread t1 = new Thread((obj) =>
                    {
                    InventoryBranchToBranch Main = new InventoryBranchToBranch();
                    Main.Show();
                    Main.Activate();
                    Main.Focus();
                    System.Windows.Forms.Application.Run();
                    });
                    t1.Start();
                    
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }

    }
}
