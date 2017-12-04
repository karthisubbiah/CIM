namespace CI.Data.Models
{
    public partial class Car
    {

        partial void Initialize();
        public Car()
        {

            this.Initialize();
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool New { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}