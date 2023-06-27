namespace InterfacesAndAbstractClasses
{
	public struct Coordinate
	{
		private int _x;
		private int _y;
		private int _z;
		public int X
		{
			get => _x; 
			set { if (value >= 0) _x = value; }
		}
		public int Y
		{
			get => _y; 
			set { if (value >= 0) _y = value; }
		}
		public int Z
		{
			get => _z; 
			set { if (value >= 0) _z = value; }
		}

		public Coordinate(int x, int y, int z) : this()
		{
			X = x;
			Y = y;
			Z = z;
		}
	}
}
