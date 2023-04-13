using Newtonsoft.Json;
using NumberGenerator.Common;
using NumberGenerator.Models;
using NumberGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows;

namespace NumberGenerator.ViewModels
{
    class PhoneNumbers :JsonSettings
    {
        private static PhoneNumbers _instance;
        private string _uniqueNumber = "";
        private ObservableCollection<NumberVariants> _numbers = new ObservableCollection<NumberVariants>();
        private NumbersGenerator _numberGenerator = new NumbersGenerator();
        private Random _rand = new Random();

        [JsonIgnore]
        public static PhoneNumbers Instance
        {
            get => _instance ??= new PhoneNumbers();
        }
        [JsonIgnore]
        public RelayCommand GetNumberCommand { get; }

        [JsonIgnore]
        public string UniqueNumber
        {
            get => _uniqueNumber;
            set => SetProperty(ref _uniqueNumber, value);
        }

        private PhoneNumbers()
        {
            GetNumberCommand = new RelayCommand(async obj => await GetNumber());
        }

        public ObservableCollection<NumberVariants> Numbers
        {
            get => _numbers;
            set
            {
                if (_numbers != value)
                {
                    SetProperty(ref _numbers, value);
                }
            }
        }

        private NumberVariants FindNumberVariants(string phoneNumber)
        {
            foreach (var numberVariants in Numbers)
            {
                if (numberVariants.Number == phoneNumber)
                {
                    return numberVariants;
                }
            }
            return null;
        }

        private bool IsSettingsValid()
        {
            return !string.IsNullOrEmpty(Settings.Instance.PhoneNumber) && !string.IsNullOrEmpty(Settings.Instance.Separator);
        }

        private async Task GetNumber()
        {
            if (!IsSettingsValid())
            {
                MessageBox.Show("Введите номер или разделитель");
                return;
            }

            NumberVariants currentNumberVariants = FindNumberVariants(Settings.Instance.PhoneNumber);

            if (currentNumberVariants == null)
            {
                currentNumberVariants = new NumberVariants();
                currentNumberVariants.Number = Settings.Instance.PhoneNumber;
                currentNumberVariants.GeneratedNumberVariants = await _numberGenerator.GenerateNumbers(Settings.Instance.PhoneNumber, Settings.Instance.Separator);
                Numbers.Add(currentNumberVariants);
            }

            int randNumber = new Random().Next(currentNumberVariants.GeneratedNumberVariants.Count - 1);
            UniqueNumber = currentNumberVariants.GeneratedNumberVariants[randNumber];
            currentNumberVariants.GeneratedNumberVariants.RemoveAt(randNumber);

            Instance.Save();
        }
    }
}