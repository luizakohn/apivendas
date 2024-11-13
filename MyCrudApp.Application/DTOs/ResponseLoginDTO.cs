namespace MyCrudApp.Application.DTOs
{
    public class ResponseLoginDTO
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
        public string ImageLink { get; set; }
        public DateTime Expiration { get; set; }
    }
}
