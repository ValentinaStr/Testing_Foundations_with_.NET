namespace InterfacesAndAbstractClasses
{
	internal interface IFlyable
	{
		internal Coordinate CurrentPosition { get; set; }
		internal double Speed { get; set; }

		internal void FlyTo(Coordinate newPosition);
		internal TimeSpan GetFlyTime(Coordinate newPosition);

		internal double GetDistance(Coordinate newPosition);

		internal string GetDescription();
	}
}