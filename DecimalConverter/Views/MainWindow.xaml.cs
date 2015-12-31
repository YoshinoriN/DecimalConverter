using System.Windows;

namespace DecimalConverter.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //ウインドウ全体でドラッグ可能にする。
            this.MouseLeftButtonDown += (sender, e) => this.DragMove();
        }

        /// <summary>
        /// 最小化
        /// </summary>
        private void min_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 最大化
        /// </summary>
        private void close_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
