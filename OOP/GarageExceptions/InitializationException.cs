namespace OOP.GarageExceptions
{
	internal class InitializationException : Exception
	{
		public InitializationException() { }

		public InitializationException(string? message) : base(message) { Console.ForegroundColor = ConsoleColor.DarkBlue; }

		public InitializationException(string? message, Exception? innerException) : base(message, innerException) { }
	}
}
