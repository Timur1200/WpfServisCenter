using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfServisCenter
{
    partial class СписокМатериаловСклада
    {
        public string Name { get
            {
                
                return $"{Склад.Имя}, {Количество}ШТ.";
            } }
    }
}
