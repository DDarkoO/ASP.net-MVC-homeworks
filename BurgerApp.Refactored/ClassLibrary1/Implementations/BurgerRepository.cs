using BurgerApp.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DATA_ACCESS.Implementations
{
    public class BurgerRepository : IRepository<Burger>
    {
        public void DeleteById(int id)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(b => b.Id == id);
            if (burger == null)
            {
                throw new Exception("There is no such burger in our menu");
            }

            StaticDb.Burgers.Remove(burger);
        }

        public List<Burger> GetAll()
        {
            return StaticDb.Burgers;
        }

        public Burger GetById(int id)
        {
            return StaticDb.Burgers.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Burger entity)
        {
            entity.Id = ++StaticDb.BurgerId;
            StaticDb.Burgers.Add(entity);
            return StaticDb.BurgerId;
        }

        public void Edit(Burger entity)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == entity.Id);
            if(burger == null)
            {
                throw new Exception("There is no such burger in our menu");
            }
            
            int index = StaticDb.Burgers.FindIndex(x => x.Id == entity.Id);
            if (index == -1)
            {
                throw new Exception("There is no such burger in our menu");
            }

            StaticDb.Burgers[index] = entity;

        }

        
                
    }
}
