using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfServisCenter
{
    partial class Склад
    {
        public string Name
        {
            get
            {
                return $"{Имя}, {Количество}ШТ.";
            }
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Категория) || string.IsNullOrEmpty(Имя) || 
                Количество == null || Цена == null)
            {
                return false;
            }
            return true;
        }
    }
}
