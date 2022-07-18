namespace FactoryPattern.Models
{
    public partial class Coordinate
	{
		// Długość geograficzna	
		public double Longitude { get; }

		// Szerokość geograficzna
		public double Latitude { get; }

		public Coordinate(double lng, double lat)
		{
			this.Longitude = lng;
			this.Latitude = lat;
		}


       
    }
}
