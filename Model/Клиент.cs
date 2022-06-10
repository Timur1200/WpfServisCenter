using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfServisCenter
{
    partial class Клиент
    {/// <summary>
    /// Проверка модели на валидацию данных
    /// </summary>
    /// <returns></returns>
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Фио) || string.IsNullOrEmpty(Телефон) || string.IsNullOrEmpty(Адрес) || !(MySystem.CheckPhone(Телефон)))
            {
                return false;
            }
            return true;
        }

        public string Name
        {
            get
            {
                return $"{Фио} {Телефон}";
            }
        }
    }
}
