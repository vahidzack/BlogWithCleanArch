using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities
{
    public class BlogModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20, ErrorMessage = "{نمیتواند بیشتر از {1} کاراکتر باشد {0")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{نمیتواند بیشتر از {1} کاراکتر باشد {0")]
        public string Description { get; set; }

        [Display(Name = "نام نویسنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20, ErrorMessage = "{نمیتواند بیشتر از {1} کاراکتر باشد {0")]
        public string Author { get; set; }

        [Display(Name = "تصویر")]
        public string? ImageUrl { get; set; }
    }
}
