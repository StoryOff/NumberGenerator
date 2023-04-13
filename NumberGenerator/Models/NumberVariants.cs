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
        public string Number
        {
            get => _number;
            set
            {
                if (_number != value)
                    SetProperty(ref _number, value);
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
