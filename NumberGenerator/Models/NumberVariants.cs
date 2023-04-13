using Newtonsoft.Json;
using NumberGenerator.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerator.Models
{
    class NumberVariants : ViewModelBase
    {
        private string _number = "";
        private string _separator = "";
        public (string Number, string Separator) PhoneNumberInfo
        {
            get => (_number, _separator);
            set
            {
                if (_number != value.Number)
                    SetProperty(ref _number, value.Number);
                if (_separator != value.Separator)
                    SetProperty(ref _separator, value.Separator);
            }
        }

        private ObservableCollection<string> _generatedNumberVariants = new ObservableCollection<string>();
        public ObservableCollection<string> GeneratedNumberVariants
        {
            get => _generatedNumberVariants;
            set
            {
                if (_generatedNumberVariants != value)
                    SetProperty(ref _generatedNumberVariants, value);
            }
        }
    }
}
