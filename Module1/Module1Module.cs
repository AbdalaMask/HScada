using Module1.Views;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using HScada.PLCModule.Views;
using System.Collections.Generic;
using HScada.SystemElement.Model;
using HScada.SystemElement.Helper;

namespace Module1
{
    public class Module1Module : IModule
    {
        public Module1Module(IContainerExtension ce)
        {
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
                PageType = typeof(Views.ColorExampleView)
            });

            menus.Add(new MenuMes
            {
                IconName = "Material_GoogleController",
                MenuName = "PLC控件示例",
                PageType = typeof(Views.PlcControlExampleView)
            });
            menus.Add(new MenuMes
            {
                IconName = "Material_Database",
                MenuName = "数据库示例",
                PageType = typeof(Views.SqliteTestView)
            });

            menus.Add(new MenuMes
            {
                IconName = "Material_TableEdit",
                MenuName = "PLC变量配置",
                PageType = typeof(PlcConfigView)
            });


            HBBFrameWorkHelper.Instance.RegisterMenu(menus,typeof(Views.LoginView));

        }


    }
}