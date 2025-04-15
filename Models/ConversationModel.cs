namespace Hackathon_2025_Filipino_Homes.Models
{
    public class ConversationModel
    {
        public string OtherUserId { get; set; }
        public Message LastMessage { get; set; }
        public string OtherUserFirstName { get; set; }
        public string OtherUserLastName { get; set; }
    }
}
