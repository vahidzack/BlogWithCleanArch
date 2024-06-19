using Blog.Application.Blogs.Queries.GetBlogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Blogs.Queries.GetBlogsById
{
    public class GetblogByIdQuery : IRequest<BlogDTO>
    {
        public int BlogId { get; set; }
    }
}
