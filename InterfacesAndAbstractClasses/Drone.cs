namespace InterfacesAndAbstractClasses
{
	internal class Drone : IFlyable
	{
		public Coordinate CurrentPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public double Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public double FlightAaltitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void FlyTo(Coordinate newPosition)
		{
			throw new NotImplementedException();
		}

		public double GetFlyTime(Coordinate newPosition)
		{
			throw new NotImplementedException();
		}
	}
}