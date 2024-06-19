namespace NewWebAPI.Models
{
    public class Application
    {
        public string Id { get; set; }
        public PersonalInformation PersonalInfo { get; set; }
        public List<QuestionAnswer> Answers { get; set; }
    }
}
