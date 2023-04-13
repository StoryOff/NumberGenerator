using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerator.Utils
{
    class NumbersGenerator
    {
        public async Task<ObservableCollection<string>> GenerateNumbers(string phoneNumber, string separator)
        {
            ObservableCollection<string> generatedNumbers = new ObservableCollection<string>();

            await Task.Run(() =>
            {
                int n = phoneNumber.Length;

                // Генерируем все возможные варианты номера
                for (int i = 0; i < (1 << n - 1); i++)
                {
                    StringBuilder sb = new StringBuilder();

                    // Создаем строку с разделителями
                    for (int j = 0; j < n - 1; j++)
                    {
                        sb.Append(phoneNumber[j]);

                        if ((i & (1 << j)) != 0)
                        {
                            sb.Append(separator);
                        }
                    }
                    sb.Append(phoneNumber[n - 1]);

                    generatedNumbers.Add(sb.ToString());
                }
            });

            return generatedNumbers;
        }
    }
}