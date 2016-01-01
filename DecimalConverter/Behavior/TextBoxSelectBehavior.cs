using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace DecimalConverter.Behavior
{
    /// <summary>
    /// テキストボックスフォーカス時のビヘイビア
    /// </summary>
    public class TextBoxSelectBehavior : Behavior<TextBox>
    {
        private Random random = new Random();

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.GotFocus += AssociatedObject_GotForcus;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.GotFocus -= AssociatedObject_GotForcus;
        }

        private void AssociatedObject_GotForcus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            //入力されている全ての文字を選択する。
            textBox.SelectAll();
        }
    }
}
