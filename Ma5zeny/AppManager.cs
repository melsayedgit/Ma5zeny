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
        public static WarehouseEntities3 entities;
        public static Dashboard DashboardForm;
        public static Manger CurrentManager;

        static AppManager()
        {

            //initialize the  forms to be used them during the app
            //to show and close them anywhere in the app and easily access them
            entities = new WarehouseEntities3();
            LoginForm = new Login();
            DashboardForm = new Dashboard();


            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(LoginForm);
            materialSkinManager.AddFormToManage(DashboardForm);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red400, Primary.Red700,
                Primary.Red500, Accent.Red100,
                TextShade.WHITE
            );

        }
    }
}
