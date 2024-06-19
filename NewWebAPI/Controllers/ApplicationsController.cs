using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWebAPI.Models;
using NewWebAPI.Models.DTOS;
using NewWebAPI.Service;

namespace NewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;

        public ApplicationsController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitApplication([FromBody] CreateApplicationDto applicationDto)
        {
            var application = new Application
            {
                Id = Guid.NewGuid().ToString(),
                PersonalInfo = new PersonalInformation
                {
                    FirstName = applicationDto.PersonalInfo.FirstName,
                    LastName = applicationDto.PersonalInfo.LastName,
                    Email = applicationDto.PersonalInfo.Email,
                    Phone = applicationDto.PersonalInfo.Phone,
                    Nationality = applicationDto.PersonalInfo.Nationality,
                    CurrentResidence = applicationDto.PersonalInfo.CurrentResidence,
                    IdNumber = applicationDto.PersonalInfo.IdNumber,
                    DateOfBirth = applicationDto.PersonalInfo.DateOfBirth,
                    Gender = applicationDto.PersonalInfo.Gender
                },
                Answers = applicationDto.Answers.ConvertAll(answerDto => new QuestionAnswer
                {
                    QuestionId = answerDto.QuestionId,
                    Answer = answerDto.Answer
                })
            };

            await _cosmosDbService.AddApplicationAsync(application);
            return Ok();
        }
    }
}
