using BurgerApp.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DATA_ACCESS.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            Order order = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                throw new Exception("Order with the specified ID was not found.");
            }

            StaticDb.Orders.Remove(order);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public int Insert(Order entity)
        {
            entity.Id = ++StaticDb.OrderId;
            StaticDb.Orders.Add(entity);
            return entity.Id;
        }

        public void Edit(Order entity)
        {
            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == entity.Id);
            if (order == null)
            {
                throw new Exception("There is no such order in the base.");
            }
            int index = StaticDb.Orders.FindIndex(x => x.Id == entity.Id);
            if (index == -1)
            {
                throw new Exception("There is no such order in our base.");
            }

            StaticDb.Orders[index] = entity;
        }

        Order IRepository<Order>.GetById(int id)
        {
            if (id == null || id <= 0)
            {
                throw new Exception("Wrong data!");
            }
            
            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            return order;
        }

        

    }
}
