namespace SEDC.PizzaApp.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsOnPromotion { get; set; }

        public Pizza(int id, string name, int price, bool isOnPromotion)
        {
            Id = id;
            Name = name;
            Price = price;
            IsOnPromotion = isOnPromotion;
        }

        public Pizza()
        {

        }
    }


}
