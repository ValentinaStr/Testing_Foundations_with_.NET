namespace OOP.GarageExceptions
{
	internal class RemoveAutoException : Exception
	{
		public RemoveAutoException() { }

		public RemoveAutoException(string? message) : base(message) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }

		public RemoveAutoException(string? message, Exception? innerException) : base(message, innerException) { }
	}
}
