using AutoMapper;
using Blog.Application.Blogs.Queries.GetBlogs;
using Blog.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Blogs.Queries.GetBlogsById
{
    public class GetblogByIdQueryHandler : IRequestHandler<GetblogByIdQuery, BlogDTO>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetblogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<BlogDTO> Handle(GetblogByIdQuery request, CancellationToken cancellationToken)
        {
            var Blog = await _blogRepository.GetByIdAsync(request.BlogId);
            return _mapper.Map<BlogDTO>(Blog);
        }
    }
}
