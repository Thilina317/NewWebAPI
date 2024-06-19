namespace NewWebAPI.Models.DTOS
{
    public class CreateApplicationDto
    {
        public PersonalInformationDto PersonalInfo { get; set; }
        public List<QuestionAnswerDto> Answers { get; set; }
    }
}
