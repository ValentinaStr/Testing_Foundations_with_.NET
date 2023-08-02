namespace InterfacesAndAbstractClasses
{
	internal static class RandomValueGenerator
	{
		private static Random random = new();

		internal static double GetRandomDouble(double minimum, double maximum)
		{
			//Generate random double 

			return random.NextDouble() * (maximum - minimum) + minimum;
		}
	}
}