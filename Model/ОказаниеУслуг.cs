using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfServisCenter
{
    partial class ОказаниеУслуг
    {
        public override string ToString()
        {
            return $"{Услуги.Имя} {Услуги.Цена} Руб.";
        }
    }
}
