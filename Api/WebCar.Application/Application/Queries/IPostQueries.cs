using Dapper;
using Newtonsoft.Json;
using WebCar.Api.Application.DTOs;
using WebCar.Application.Application.DTOs;
using WebCar.Application.Application.Infrastructure;
using WebCar.Application.Application.Models.Filters;
using WebCar.Application.Application.Queries.Resources;

namespace WebCar.Application.Application.Queries
{
    public interface IPostQueries
    {
        Task<PostDetailsDTO> GetById(Guid id);
        Task<List<PostDTO>> Get(PostFilter filter);
    }
    public class PostQueries(SqlConnectionProvider sqlConnectionProvider) : IPostQueries
    {
        private readonly SqlConnectionProvider _sqlConnectionProvider = sqlConnectionProvider ?? throw new ArgumentNullException(nameof(sqlConnectionProvider));

        public async Task<List<PostDTO>> Get(PostFilter filter)
        {
            var connection = _sqlConnectionProvider.GetConnection();
            connection.Open();

            string json = await connection.QueryFirstOrDefaultAsync<string>(PostResources.GET_ALL, new
            {
                VersionId = filter.VersionId,
                Fuel = filter.Fuel,
                Body = filter.Body,
                Condition = filter.Condition,
                Clutch = filter.Clutch,
                StartKilometer = filter.StartKilometer,
                EndKilometer = filter.EndKilometer,
                Armored = filter.Armored,
                Licensed = filter.Licensed,
                StartYear = filter.StartYear,
                EndYear = filter.EndYear,
                StartPrice = filter.StartPrice,
                EndPrice = filter.EndPrice,
                Localization = filter.Localization
            });

            List<PostDTO> postList = JsonConvert.DeserializeObject<List<PostDTO>>(json);
            return postList;
        }

        public async Task<PostDetailsDTO> GetById(Guid id)
        {
            var connection = _sqlConnectionProvider.GetConnection();
            connection.Open();

            var json = await connection.QueryFirstOrDefaultAsync<string>(PostResources.GET_DETAILS_BY_ID, new { PostId = id });

            var post = JsonConvert.DeserializeObject<PostDetailsDTO>(json);

            return post;
        }
    }
}
