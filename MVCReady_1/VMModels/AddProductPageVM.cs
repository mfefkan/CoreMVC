using MVCReady_1.Models.Entities;

namespace MVCReady_1.VMModels
{
	public class AddProductPageVM
	{
		public ProductVM Product { get; set; }
		public List<CategoryVM> Categories { get; set; }

	}
}
