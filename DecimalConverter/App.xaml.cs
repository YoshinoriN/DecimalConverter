using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DecimalConverter
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// アプリケーションが開始される時のイベント。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            this.Resources.MergedDictionaries.Add(Application.LoadComponent(new Uri(@"/DecimalConverter;component/Style/Style.xaml", UriKind.Relative)) as ResourceDictionary);
        }
    }
}
