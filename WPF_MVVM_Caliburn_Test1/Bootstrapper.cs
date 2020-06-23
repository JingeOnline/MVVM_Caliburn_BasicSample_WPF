using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//导入ViewModel的命名空间
using WPF_MVVM_Caliburn_Test1.ViewModels;

namespace WPF_MVVM_Caliburn_Test1
{
    //程序的启动类
    public class Bootstrapper:BootstrapperBase
    {
        public Bootstrapper()
        {
            base.Initialize();
        }

        //重写OnStartUp方法，设置程序启动的ViewModel
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

    }
}
