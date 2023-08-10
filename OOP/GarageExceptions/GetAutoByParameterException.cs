namespace OOP.GarageExceptions
{
	internal class GetAutoByParameterException : Exception
	{
		public GetAutoByParameterException() { }

		public GetAutoByParameterException(string? message) : base(message) { Console.ForegroundColor = ConsoleColor.Red; }

		public GetAutoByParameterException(string? message, Exception? innerException) : base(message, innerException) { }
	}
}
