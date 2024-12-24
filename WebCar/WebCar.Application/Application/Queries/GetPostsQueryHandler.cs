using MediatR;
using WebCar.Api.Application.DTOs;
using WebCar.Domain.Models;
using WebCar.Domain.Repositories;
using static WebCar.Application.Application.Queries.GetPostsQueryHandler;

namespace WebCar.Application.Application.Queries
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDTO>>
    {
        private readonly IPostRepository _postRepository;
        public async Task<List<PostDTO>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = _postRepository.GetAll().Where(x =>
                request.VersionId == Guid.Empty || x.Car.Version.Id == request.VersionId ||
                request.Fuel == null            || ((int)x.Car.FuelType) == (int)request.Fuel ||
                request.Body == null            || ((int)x.Car.BodyType) == (int)request.Body ||
                request.Condition == null       || ((int)x.Car.ConditionType) == (int)request.Condition ||
                request.Clutch == null          || ((int)x.Car.TransmissionType) == (int)request.Clutch ||
                request.StartKilometer == null  || x.Car.Kilometer >= request.StartKilometer ||
                request.EndKilometer == null    || x.Car.Kilometer <= request.EndKilometer ||
                request.Armored == false        || x.Car.IsArmored == request.Armored ||
                request.Licensed == false       || x.Car.IsLicensed == request.Licensed ||
                request.StartYear == null       || (x.Car.YearOfManufacture >= request.StartYear || x.Car.YearOfModel >= request.StartYear) ||
                request.EndYear == null         || (x.Car.YearOfManufacture <= request.EndYear   || x.Car.YearOfModel <= request.EndYear) ||
                request.StartPrice == null      || x.Price >= request.StartPrice ||
                request.EndPrice == null        || x.Price <= request.EndPrice ||
                request.Localization == null    || x.Localization == request.Localization
            );
            if(posts == null)
                return null;

            return posts.Select(x => new PostDTO 
            { 
            }).ToList();
        }
        public class GetPostsQuery(
            long? startkilometer,
            long? endkilometer,
            int? startYear,
            int? endYear,
            decimal? startPrice,
            decimal? endPrice,
            bool? armored,
            bool? licensed,
            string localization,
            TransmissionTypeEnum? clutch,
            FuelTypeEnum? fuel,
            BodyTypeEnum? body,
            CarConditionTypeEnum? condition,
            Guid? versionId
            ) : IRequest<List<PostDTO>>
        {
            public long? StartKilometer { get; set; } = startkilometer;
            public long? EndKilometer { get; set; } = endkilometer;
            public int? StartYear { get; set; } = startYear;
            public int? EndYear { get; set; } = endYear;
            public decimal? StartPrice { get; set; } = startPrice;
            public decimal? EndPrice { get; set; } = endPrice;
            public bool? Armored { get; set; } = armored;
            public bool? Licensed { get; set; } = licensed;
            public string Localization { get; set; } = localization;
            public TransmissionTypeEnum? Clutch { get; set; } = clutch;
            public FuelTypeEnum? Fuel { get; set; } = fuel;
            public BodyTypeEnum? Body { get; set; } = body;
            public CarConditionTypeEnum? Condition { get; set; } = condition;
            public Guid? VersionId { get; set; } = versionId;
        }
    }
}
