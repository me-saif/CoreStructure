using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreStructure.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SelectListItem ListItem { get; set; }
    }
}
