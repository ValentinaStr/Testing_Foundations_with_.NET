using OOP.Specification;

namespace OOP.TypesOfTransport
{
	internal class Bus : Transport
	{
		internal int NumberOfFloors { get; set; }
		internal string TypeAirConditioner { get; set; }

		public Bus(string model, int numberOfFloors, string typeAirConditioner, Engine engine, Transmission transmission, Chassis chassis) : base(model, engine, transmission, chassis)
		{
			NumberOfFloors = numberOfFloors;
			TypeAirConditioner = typeAirConditioner;
		}

		internal override string GetStringWithAllInformation()
		{
			return base.Model + 
				"\n Bus with the following characteristics:" + 
				"\n Number Of Floors:" + NumberOfFloors +
				"\n Type of Air Conditioner:" + TypeAirConditioner +
				base.GetStringWithAllInformation();
		}
	}
}
