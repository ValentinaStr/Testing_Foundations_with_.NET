namespace EmaiGmailHotmail.Model
{
	public class Letter
	{
		public string Term { get; set; }
		public string Text { get; set; }

		public Letter( string therm, string text)
		{
			Term = therm;
			Text = text;
		}

		public Letter(string text)
		{
			Text = text;
		}
	}
}