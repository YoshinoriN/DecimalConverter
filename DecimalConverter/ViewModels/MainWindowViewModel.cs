﻿using System;

namespace DecimalConverter.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
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
                    this.HexadecimalNumber = Convert.ToString(value, 16);
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

                if (value.Length > 64 | System.Text.RegularExpressions.Regex.IsMatch(value, "[^0-1]+"))
                {
                    return;
                }

                if (value != _binaryNumber)
                {
                    this._binaryNumber = value;
                    this.DecimalNumber = Convert.ToInt64(value, 2);
                    this.HexadecimalNumber = Convert.ToString(this.DecimalNumber, 16);
                    this.CurrentBit = value.Length;
                }
                this.OnPropertyChanged();
            }
        }

        private string _hexadecimalNumber = "0";
        /// <summary>
        /// 16進数(テキストボックスとバインディング)
        /// </summary>
        public string HexadecimalNumber
        {
            get { return this._hexadecimalNumber; }
            set
            {
                if(value.Length == 0)
                {
                    value = "0";
                }

                if (value.Length > 16 | System.Text.RegularExpressions.Regex.IsMatch(value, "[^a-fA-F0-9]+"))
                {
                    return;
                }

                if (value != _hexadecimalNumber)
                {
                    this._hexadecimalNumber = value.ToUpper();
                    this.DecimalNumber = Convert.ToInt64(value, 16);
                    this.BinaryNumber = Convert.ToString(this.DecimalNumber, 2);
                }
                this.OnPropertyChanged();
            }
        }

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

        //ファイル名とバージョン表示
        public string Title { get; private set; } = System.IO.Path.GetFileNameWithoutExtension(@System.Reflection.Assembly.GetExecutingAssembly().Location) + " " +
            System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductVersion.ToString();


        public MainWindowViewModel()
        {

        }
    }
}