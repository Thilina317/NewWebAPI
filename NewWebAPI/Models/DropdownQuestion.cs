namespace NewWebAPI.Models
{
    public class DropdownQuestion : Question
    {
        public List<string> Options { get; set; }
        public DropdownQuestion()
        {
            Type = "Dropdown";
        }
    }
}
