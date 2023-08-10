namespace OOP.GarageExceptions
{
	internal class AddException : Exception
	{
		public AddException() { }

		public AddException(string? message) : base(message) { Console.ForegroundColor = ConsoleColor.Yellow; }

		public AddException(string? message, Exception? innerException) : base(message, innerException) { }
	}
}
