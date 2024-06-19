using AutoMapper;
using Blog.Application.Blogs.Queries.GetBlogs;
using Blog.Application.Common.Exceptions;
using Blog.Domain.Entities;
using Blog.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Blogs.Commands.Createblog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogDTO>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IImageStorageService _imageStorageService; 
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper, IImageStorageService imageStorageService)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _imageStorageService = imageStorageService;
        }

        public async Task<BlogDTO> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            if (request.ImageUrl != null && request.ImageUrl.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(request.ImageUrl.FileName)}";
                var imageUrl = await _imageStorageService.StoreImageAsync(request.ImageUrl, fileName);

                var newBlog = new BlogModel
                {
                    Name = request.Name,
                    Description = request.Description,
                    Author = request.Author,
                    ImageUrl = imageUrl  
                };

                var result = await _blogRepository.CreateBlog(newBlog);
                return _mapper.Map<BlogDTO>(result);
            }
            else
            {
                var newBlog = new BlogModel
                {
                    Name = request.Name,
                    Description = request.Description,
                    Author = request.Author
                };

                var result = await _blogRepository.CreateBlog(newBlog);
                return _mapper.Map<BlogDTO>(result);
            }
        }
    }
}
