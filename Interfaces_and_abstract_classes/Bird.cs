
namespace InterfacesAndAbstractClasses
{
	internal class Bird : IFlyable
	{
		private double _speed;

		public Coordinate Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public double Speed { get => _speed; set { if(value > 0 && value < 20) _speed = value;}}
		public double FlightAltitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
