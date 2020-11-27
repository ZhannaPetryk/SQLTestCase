using System.ComponentModel.DataAnnotations;

namespace SQLTestCase.Data.Enums
{
    public enum ProductCategory
    {
        Electronics,
        Computers,
        [Display(Name = "Smart Home")]
        SmartHome,
        [Display(Name = "Arts&Crafts")]
        ArtsAndCrafts
    }
}