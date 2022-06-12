namespace ScooterRents
{
    public class Users
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }

    public class Scooters
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Tenant { get; set; } = string.Empty;
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
        public int Price { get; set; }
    }
}
