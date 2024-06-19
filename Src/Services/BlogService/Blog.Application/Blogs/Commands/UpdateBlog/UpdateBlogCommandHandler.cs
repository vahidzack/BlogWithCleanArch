using AutoMapper;
using Blog.Application.Blogs.Queries.GetBlogs;
using Blog.Application.Common.Exceptions;
using Blog.Domain.Entities;
using Blog.Domain.Repository;
using MediatR;
using OpenQA.Selenium;

namespace Blog.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, BlogDTO>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IImageStorageService _imageStorageService;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper, IImageStorageService imageStorageService)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _imageStorageService = imageStorageService;
        }

        public async Task<BlogDTO> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var existingBlog = await _blogRepository.GetByIdAsync(request.Id);

            if (existingBlog == null)
            {
                throw new NotFoundException(nameof(BlogModel));
            }

            existingBlog.Name = request.Name;
            existingBlog.Description = request.Description;
            existingBlog.Author = request.Author;
            if (request.ImageUrl != null && request.ImageUrl.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(request.ImageUrl.FileName)}";
                var imageUrl = await _imageStorageService.StoreImageAsync(request.ImageUrl, fileName);
                existingBlog.ImageUrl = imageUrl;
            }
            await _blogRepository.UpdateBlog(existingBlog);
            return _mapper.Map<BlogDTO>(existingBlog);
        }
    }

}
