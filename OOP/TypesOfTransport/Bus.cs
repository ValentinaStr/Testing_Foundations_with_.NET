using OOP.Specification;

namespace OOP.TypesOfTransport
{
	internal class Bus : Transport
	{
		private int numberOfFloors;
		private int numberOfSeats;
		internal int NumberOfFloors
		{
			get { return numberOfFloors; }
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("The number of floors mast be more than zero");
				numberOfFloors = value;
			}
		}
		internal int NumberOfSeats
		{
			get { return numberOfSeats; }
			set
			{
				if (value < 0) throw new ArgumentOutOfRangeException("Number of seats mast be positive number");
				numberOfSeats = value;
			}
		}
		internal Bus(string model, int numberOfFloors, int numberOfSeats, Engine engine, Transmission transmission, Chassis chassis) : base(model, engine, transmission, chassis)
		{
			NumberOfFloors = numberOfFloors;
			NumberOfSeats = numberOfSeats;
		}

		internal override string GetStringWithAllInformation()
		{
			return base.Model +
				"\n Bus with the following characteristics:" +
				"\n Number Of Floors:" + NumberOfFloors +
				"\n Number Of Seats:" + NumberOfSeats +
				base.GetStringWithAllInformation();
		}
	}
}