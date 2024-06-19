using Blog.Domain.Entities;

namespace Blog.Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<BlogModel>> GetAllBlogAsync();
        Task<BlogModel> GetByIdAsync(int Id);
        Task<BlogModel> CreateBlog(BlogModel blog);
        Task<int> UpdateBlog(BlogModel blog);
        Task<int> DeleteBlog(int Id);


    }
}
