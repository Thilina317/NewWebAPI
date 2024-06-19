using Microsoft.Azure.Cosmos;
using NewWebAPI.Models;
using NewWebAPI.Models.DTOS;

namespace NewWebAPI.Service
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container _container;

        public CosmosDbService(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task AddQuestionAsync(CreateQuestionDto questionDto)
        {
            if (string.IsNullOrWhiteSpace(questionDto.Id))
            {
                questionDto.Id = Guid.NewGuid().ToString();
            }
            await _container.CreateItemAsync(questionDto, new PartitionKey(questionDto.Id));
        }

        public async Task<Question> GetQuestionAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Question>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException) // For handling item not found and other exceptions
            {
                return null;
            }
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync()
        {
            var query = _container.GetItemQueryIterator<Question>(new QueryDefinition("SELECT * FROM c"));
            var results = new List<Question>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task UpdateQuestionAsync(string id, Question question)
        {
            await _container.UpsertItemAsync(question, new PartitionKey(id));
        }

        public async Task AddApplicationAsync(Application application)
        {
            await _container.CreateItemAsync(application, new PartitionKey(application.Id));
        }
    }
}
