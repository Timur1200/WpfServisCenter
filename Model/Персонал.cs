using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfServisCenter
{
    partial class Персонал
    {
        public string ИмяРоли
        {
            get
            {
                return ((Роли)Роль.Value).ToString();
            }
        }

        public bool IsValid()
        {
            if (Роль == null || string.IsNullOrEmpty(Фио) || !(MySystem.CheckPhone(Телефон)) || string.IsNullOrEmpty(Пароль))
            {
                return false;
            }
            return true;
        }
    }
}
