using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Ma5zeny
{
  
    internal class AppManager
    {
        public static Login LoginForm;
        public static WarehouseEntities2 entities;
        public static Dashboard DashboardForm;
        public static Manger CurrentManager;

        static AppManager()
        {

            //initialize the  forms to be used them during the app
            //to show and close them anywhere in the app and easily access them
            entities = new WarehouseEntities2();
            LoginForm = new Login();
            DashboardForm = new Dashboard();


            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(LoginForm);
            materialSkinManager.AddFormToManage(DashboardForm);

            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Purple300, Primary.Purple400,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );

        }
    }
}
