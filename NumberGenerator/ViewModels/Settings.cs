using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerator.ViewModels
{
    class Settings : JsonSettings
    {
        private static Settings _instance;
        public static Settings Instance
        {
            get => _instance ??= new Settings();
        }

        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber != value)
                    SetProperty(ref _phoneNumber, value);
            }
        }

        private string _separator = "";

        public string Separator
        {
            get => _separator;
            set
            {
                if (_separator != value)
                    SetProperty(ref _separator, value);
            }
        }
    }
}
