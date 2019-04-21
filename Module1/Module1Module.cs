using Module1.Views;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using HScada.PLCModule.Helper;
using HScada.PLCModule.Views;
using System.Collections.Generic;
using HScada.SystemElement.Model;

namespace Module1
{
    public class Module1Module : IModule
    {
        HBBFrameWorkHelper frameWorkHelper;
        public Module1Module(IContainerExtension ce)
        {
            frameWorkHelper = ce.Resolve<HBBFrameWorkHelper>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            List<MenuMes> menus = new List<MenuMes>();
            menus.Add(new MenuMes
            {
                IconName = "Entypo_RoundBrush",
                MenuName = "主题色",
                PageName = "ColorExampleView",
                PageType = typeof(Views.ColorExampleView)
            });

            menus.Add(new MenuMes
            {
                IconName = "Material_GoogleController",
                MenuName = "PLC控件\n示例",
                PageName = "PlcControlExampleView",
                PageType = typeof(Views.PlcControlExampleView)
            });
            menus.Add(new MenuMes
            {
                IconName = "Material_Database",
                MenuName = "数据库\n示例",
                PageName = "SqliteTestView",
                PageType = typeof(Views.SqliteTestView)
            });

            menus.Add(new MenuMes
            {
                IconName = "Material_TableEdit",
                MenuName = "PLC\n变量配置",
                PageName = "PlcConfigView",
                PageType = typeof(PlcConfigView)
            });

            frameWorkHelper.RegisterMenu(menus,typeof(Views.LoginView));

        }


    }
}