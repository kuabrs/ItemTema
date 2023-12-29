using ItemTema.Contexts;
using ItemTema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ItemTema.Persistencia.DAL
{
    public class ItemDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Item> ObterItemsClassificadosPorNome()
        {
            return context.Items.OrderBy(b => b.Nome);
        }
        public Item ObterItemPorId(long id)
        {
            return context.Items.Where(f => f.ItemId == id).First();
        }
        public void GravarItem(Item Item)
        {
            if (Item.ItemId == 0)
            {
                context.Items.Add(Item);
            }
            else
            {
                context.Entry(Item).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Item EliminarItemPorId(long id)
        {
            Item Item = ObterItemPorId(id);
            context.Items.Remove(Item);
            context.SaveChanges();
            return Item;
        }
    }
}