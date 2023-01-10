using PlutoTool.Models;

namespace PlutoTool.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string NameParent { get; set; }
    }
}
