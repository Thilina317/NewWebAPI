using NewWebAPI.Models;
using NewWebAPI.Models.DTOS;

namespace NewWebAPI.Service
{
    public interface ICosmosDbService
    {
        Task AddQuestionAsync(CreateQuestionDto questionDto);
        Task<Question> GetQuestionAsync(string id);
        Task<IEnumerable<Question>> GetQuestionsAsync();
        Task UpdateQuestionAsync(string id, Question question);
        Task AddApplicationAsync(Application application);
    }
}
