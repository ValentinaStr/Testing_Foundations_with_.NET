namespace InterfacesAndAbstractClasses
{
	interface IFlyable
	{
		Coordinate CurrentPosition { get; set; }
		double Speed { get; set; }
		double FlightAaltitude { get; set; }

		void FlyTo(Coordinate newPosition);
		double GetFlyTime(Coordinate newPosition);
	}
}