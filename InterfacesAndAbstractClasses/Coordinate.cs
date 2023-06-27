namespace InterfacesAndAbstractClasses
{
	internal struct Coordinate
	{
		private int x;
		private int y;
		private int z;
		public int X
		{
			get => x; 
			set 
			{
				if (value >= 0)	{x = value;}
			}
		}

		public int Y
		{
			get => y; 
			set
			{
				if (value >= 0) {y = value; }
			}
		}

		public int Z
		{
			get => z;
			set 
			{ 
				if (value >= 0) {z = value;}
			}
		}

		public Coordinate(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}
	}
}