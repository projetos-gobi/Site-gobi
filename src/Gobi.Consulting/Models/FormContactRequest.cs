using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Gobi.Consulting.Models
{
	public record FormContactRequest
	{
		[Required(ErrorMessage = "Obrigatório")]
		[MinLength(3)]
		public string Name { get; set; }

		[EmailAddress]
		[Required(ErrorMessage = "Obrigatório")]
		public string Email { get; set; }

		public string Phone { get; set; }

		[Required(ErrorMessage = "Obrigatório")]
		public string CompanyName { get; set; }

		public string CompanySize { get; set; }

		public static List<SelectListItem> CompanySizeSelectListItems { get; } =
        [
            new ("De 1 a 10 funcionários", "De 1 a 10 funcionários"),
            new ("De 10 a 50 funcionários", "De 10 a 50 funcionários"),
            new ("De 50 a 100 funcionários", "De 50 a 100 funcionários"),
			new ("De 100 a 200 funcionários", "De 100 a 200 funcionários"),
			new ("Mais de 200 funcionários", "Mais de 200 funcionários")
		];

		public string Subject { get; set; }


		[Required]
		[Range(typeof(bool), "true", "true", ErrorMessage = "The field Is Active must be checked.")]
		public bool PrivacyPolicy { get; set; }

		public bool AllowsContact { get; set; }
	}
}
