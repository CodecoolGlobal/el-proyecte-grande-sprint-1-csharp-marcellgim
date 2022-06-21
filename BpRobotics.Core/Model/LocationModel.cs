namespace BpRobotics.Core.Model
{
    public class LocationModel
    {
        public int ZIP { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString() => $"{ZIP}, {Country}, {City}, {Address}";
    }
}
