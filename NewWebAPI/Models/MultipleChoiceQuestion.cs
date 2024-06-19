namespace NewWebAPI.Models
{
    public class MultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public MultipleChoiceQuestion()
        {
            Type = "MultipleChoice";
        }
    }
}
