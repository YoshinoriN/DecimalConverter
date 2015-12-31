using System;

namespace DecimalConverter.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region"進数のテキストボックス"

        private Int64 _decimalNumber = 0;
        /// <summary>
        /// 10進数(テキストボックスとバインディング)
        /// </summary>
        public Int64 DecimalNumber
        {
            get { return this._decimalNumber; }
            set
            {
                if (value != _decimalNumber)
                {
                    this._decimalNumber = value;
                    this.BinaryNumber = Convert.ToString(value, 2);
                    this.HexaDecimalNumber = Convert.ToString(value, 16);
                    this.OctDecimalNumber = Convert.ToString(value, 8);
                }
                this.OnPropertyChanged();
            }
        }

        private string _binaryNumber = "0";
        /// <summary>
        /// 2進数(テキストボックスとバインディング)
        /// </summary>
        public string BinaryNumber
        {
            get { return this._binaryNumber; }
            set
            {
                if (value.Length == 0)
                {
                    value = "0";
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(value, "[^0-1]+"))
                {
                    return;
                }

                if (value != _binaryNumber)
                {
                    this._binaryNumber = value;
                    this.DecimalNumber = Convert.ToInt64(value, 2);
                    this.HexaDecimalNumber = Convert.ToString(this.DecimalNumber, 16);
                    this.OctDecimalNumber = Convert.ToString(this.DecimalNumber, 8);
                    this.CurrentBit = value.Length;
                }
                this.OnPropertyChanged();
            }
        }

        private string _hexaDecimalNumber = "0";
        /// <summary>
        /// 16進数(テキストボックスとバインディング)
        /// </summary>
        public string HexaDecimalNumber
        {
            get { return this._hexaDecimalNumber; }
            set
            {
                if(value.Length == 0)
                {
                    value = "0";
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(value, "[^a-fA-F0-9]+"))
                {
                    return;
                }

                if (value != _hexaDecimalNumber)
                {
                    this._hexaDecimalNumber = value.ToUpper();
                    this.DecimalNumber = Convert.ToInt64(value, 16);
                    this.BinaryNumber = Convert.ToString(this.DecimalNumber, 2);
                    this.OctDecimalNumber = Convert.ToString(this.DecimalNumber, 8);
                }
                this.OnPropertyChanged();
            }
        }

        private string _octDecimalNumber = "0";
        /// <summary>
        /// 8進数(テキストボックスとバインディング)
        /// </summary>
        public string OctDecimalNumber
        {
            get { return this._octDecimalNumber; }
            set
            {
                if (value.Length == 0)
                {
                    value = "0";
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(value, "[^0-7]+"))
                {
                    return;
                }

                if (value != _octDecimalNumber)
                {
                    this._octDecimalNumber = value;
                    this.DecimalNumber = Convert.ToInt64(value, 8);
                    this.BinaryNumber = Convert.ToString(this.DecimalNumber, 2);
                    this.HexaDecimalNumber = Convert.ToString(this.DecimalNumber, 16);
                }
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region "ビットとバイト表示"

        private int _currentBit = 1;
        /// <summary>
        /// 現在のビット
        /// </summary>
        public int CurrentBit
        {
            get { return this._currentBit; }
            set
            {
                this._currentBit = value;
                this.CurrentByte = value / 4;
                this.OnPropertyChanged();
            }
        }

        private double _currentByte = 0;
        /// <summary>
        /// 現在のバイト
        /// </summary>
        public double CurrentByte
        {
            get { return this._currentByte; }
            set
            {
                this._currentByte = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        /// <summary>
        /// アプリ名とバージョン
        /// </summary>
        public string Title { get; private set; } = 
            System.IO.Path.GetFileNameWithoutExtension(@System.Reflection.Assembly.GetExecutingAssembly().Location) + " " +
            System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductVersion.ToString();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {

        }
    }
}
