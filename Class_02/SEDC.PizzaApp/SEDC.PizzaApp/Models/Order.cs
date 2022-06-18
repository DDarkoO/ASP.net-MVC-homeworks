namespace SEDC.PizzaApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public List<Pizza> OrderedPizzas { get; set; }


    }
}
