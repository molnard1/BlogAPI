using BlogAPI.Models.Dtos;

namespace BlogAPI
{
    public static class Extensions
    {
        public static BlogUser AsDto(this Models.BlogUser blogUser)
        {
            return new BlogUser(
                blogUser.Id,
                blogUser.Username,
                blogUser.UserEmail,
                blogUser.Password,
                blogUser.CreatedTime
            );
        }
    }
}