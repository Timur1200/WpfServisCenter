using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfServisCenter
{
    partial class Услуги
    {
        public bool IsValid()
        {
            if (Цена == null || string.IsNullOrEmpty(Имя))
            {
                return false;
            }
            return true; 
        }
    }
}
