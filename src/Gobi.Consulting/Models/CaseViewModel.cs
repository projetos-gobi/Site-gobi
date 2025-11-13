namespace Gobi.Consulting.Models
{
	public record CaseViewModel
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string ButtonText { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string Problem { get; set; }
		public string Solution { get; set; }
		public string Results { get; set; }
	}
}
