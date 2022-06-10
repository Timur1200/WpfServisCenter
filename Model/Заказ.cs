using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfServisCenter
{
    public partial class Заказ
    {
        public string ТекстСтатус
        {
            get
            {

                if (Статус == null) return string.Empty;
                return ((СтатусЗаказов)Статус).ToString();
            }
        }

        public string Дата1
        {
            get
            {
                if (ДатаПоступления == null) return string.Empty;
                return ДатаПоступления.Value.ToString("D");
            }
        }
        public string Дата2
        {
            get
            {
                if (ДатаВыдачи == null) return String.Empty;
                return ДатаВыдачи.Value.ToString("D");
            }
        }

        public bool IsValid()
        {
            if (Клиент == null || string.IsNullOrEmpty(Техника) || string.IsNullOrEmpty(Описание))
            {
                return false;
            }
            return true;
        }
    }
}
