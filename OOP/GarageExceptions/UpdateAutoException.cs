namespace OOP.GarageExceptions
{
	internal class UpdateAutoException : Exception
	{
		public UpdateAutoException() { }

		public UpdateAutoException(string? message) : base(message) { Console.ForegroundColor = ConsoleColor.Cyan; }

		public UpdateAutoException(string? message, Exception? innerException) : base(message, innerException) { }
	}
}
