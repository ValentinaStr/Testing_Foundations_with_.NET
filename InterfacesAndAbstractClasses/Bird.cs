namespace InterfacesAndAbstractClasses
{
	internal class Bird : IFlyable
	{
		private double speed;
		public Coordinate CurrentPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public double Speed 
		{
			get => speed;
			set 
			{
				if (value >= 0 && value <= 20)
				{
					speed = value;
				}
			}
		}
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