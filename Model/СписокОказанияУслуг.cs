using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfServisCenter
{
    partial class СписокОказанияУслуг
    {
        public string Дата1
        {
            get
            {
                if (Дата == null) return "";
                return Дата.Value.ToString("D");
            }
        }

        public string Статус
        {
            get
            {
                if (Стоимость == null) return "Открыт";
                return "Завершен";
            }
        }
    }
}
