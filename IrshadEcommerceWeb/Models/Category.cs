using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IrshadEcommerceWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
