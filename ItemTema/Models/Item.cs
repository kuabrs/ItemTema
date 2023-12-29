using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemTema.Models
{
    public class Item
    {
        public long ItemId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}