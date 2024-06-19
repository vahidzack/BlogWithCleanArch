using Blog.Domain.Entities;
using Blog.Domain.Repository;
using Blog.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDBContext _blogDBContext;

        public BlogRepository(BlogDBContext blogDBContext)
        {
            _blogDBContext = blogDBContext;
        }

        public async Task<BlogModel> CreateBlog(BlogModel blog)
        {
            await _blogDBContext.BlogModels.AddAsync(blog);
            await _blogDBContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteBlog(int Id)
        {
            return await _blogDBContext.BlogModels.Where(x => x.Id == Id).
                ExecuteDeleteAsync();

        }

        public async Task<List<BlogModel>> GetAllBlogAsync()
        {
            return await _blogDBContext.BlogModels.ToListAsync();
        }

        public async Task<BlogModel> GetByIdAsync(int Id)
        {
            return await _blogDBContext.BlogModels.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<int> UpdateBlog(BlogModel blog)
        {
            if (blog == null || blog.Id <= 0)
            {
                throw new ArgumentException("Invalid blog or blog Id.");
            }

            var existingBlog = await _blogDBContext.BlogModels.FindAsync(blog.Id);

            if (existingBlog == null)
            {
                throw new ArgumentException("Blog not found.");
            }

            existingBlog.Name = blog.Name;
            existingBlog.Author = blog.Author;
            existingBlog.Description = blog.Description;
            existingBlog.ImageUrl = blog.ImageUrl; // Assuming ImageUrl can be updated

            try
            {
                _blogDBContext.Update(existingBlog);
                return await _blogDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating blog.", ex);
            }
        }

    }
}
