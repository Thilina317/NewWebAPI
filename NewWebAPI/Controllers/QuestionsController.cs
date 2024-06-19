using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWebAPI.Models;
using NewWebAPI.Models.DTOS;
using NewWebAPI.Service;

namespace NewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;

        public QuestionsController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDto questionDto)
        {
            questionDto.Id = Guid.NewGuid().ToString();

            await _cosmosDbService.AddQuestionAsync(questionDto);
            return Ok(questionDto);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateQuestion(string id, [FromBody] UpdateQuestionDto questionDto)
        //{
        //    var question = await _cosmosDbService.GetQuestionAsync(id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    question.Text = questionDto.Text;
        //    if (question is DropdownQuestion dropdownQuestion)
        //    {
        //        dropdownQuestion.Options = questionDto.Options;
        //    }
        //    else if (question is MultipleChoiceQuestion multipleChoiceQuestion)
        //    {
        //        multipleChoiceQuestion.Options = questionDto.Options;
        //    }

        //    await _cosmosDbService.UpdateQuestionAsync(id, question);
        //    return Ok(question);
        //}

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _cosmosDbService.GetQuestionsAsync();
            return Ok(questions);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitApplication([FromBody] Application application)
        {
            await _cosmosDbService.AddApplicationAsync(application);
            return Ok();
        }
    }
}
