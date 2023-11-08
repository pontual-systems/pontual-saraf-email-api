namespace EmailAPI.Domain.DTO
{
    public class Email
    {
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string Subject { get; set; }
        public string HtmlBody { get; set; }        
    }
}
