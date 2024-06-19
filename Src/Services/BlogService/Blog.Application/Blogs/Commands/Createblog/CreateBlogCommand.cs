using Blog.Application.Blogs.Queries.GetBlogs;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace Blog.Application.Blogs.Commands.Createblog
{
    public class CreateBlogCommand : IRequest<BlogDTO>
    {
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
        public IFormFile ImageUrl { get; set; }
    }
}
