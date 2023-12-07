using BlogAPI.Models.Dtos;

namespace BlogAPI
{
    public static class Extensions
    {
        public static BlogUserDto AsDto(this Models.BlogUser blogUser)
        {
            return new BlogUserDto(
                blogUser.Id,
                blogUser.Username,
                blogUser.UserEmail,
                blogUser.Password,
                blogUser.CreatedTime
            );
        }
    }
}