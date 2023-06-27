namespace InterfacesAndAbstractClasses
{
	public interface IFlyable
	{
		public Coordinate Position { get; set; }
		public double Speed { get; set; }

		public double FlightAltitude { get; set; }

		public void FlyTo(Coordinate newPosition);
		public double GetFlyTime(Coordinate newPosition);
	}
}
