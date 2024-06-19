using AutoMapper;
using Blog.Application.Common.Mappings;
using Blog.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Blogs.Queries.GetBlogs
{
    public class BlogDTO : IMapForm<BlogModel>
    {
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BlogModel, BlogDTO>();
        }

    }
}
