namespace InterfacesAndAbstractClasses
{
	internal struct Coordinate
	{
		private double x;
		private double y;
		private double z;
		internal double X
		{
			get => x;
			set
			{
				if (value < 0)
				{
					Console.WriteLine("Coordinate X value must be positive number. It will be 0.");
					value = 0;
				}

				x = value;
			}
		}

		internal double Y
		{
			get => y;
			set
			{
				if (value < 0)
				{
					Console.WriteLine("Coordinate Y value must be positive number. It will be 0.");
					value = 0;
				}

				y = value;
			}
		}

		internal double Z
		{
			get => z;
			set
			{
				if (value < 0)
				{
					Console.WriteLine("Coordinate Z value must be positive number.It will be 0.");
					value = 0;
				}

				z = value;
			}
		}

		internal Coordinate(double x = 0, double y = 0, double z = 0)
		{
			X = x;
			Y = y;
			Z = z;
		}

		internal string GetCoordinateToString()
		{
			return $"({x}:{y}:{z})";
		}
	}
}