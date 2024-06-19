namespace NewWebAPI.Models.DTOS
{
    public class CreateQuestionDto
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public QuestionTypes Type { get; set; }
    }
}
