using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using WebCar.Api.Application.DTOs;
using WebCar.Domain.Models;
using WebCar.Domain.Repositories;
using Newtonsoft.Json;
using WebCar.Application.Infrastructure;
using static WebCar.Application.Application.Queries.GetPostsQueryHandler;

namespace WebCar.Application.Application.Queries;

public class GetPostsQueryHandler(SqlConnectionProvider  sqlConnectionProvider) : IRequestHandler<GetPostsQuery, List<PostDTO>>
{
    private readonly SqlConnectionProvider _sqlConnectionProvider = sqlConnectionProvider ?? throw new ArgumentNullException(nameof(sqlConnectionProvider));
    public async Task<List<PostDTO>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionProvider.GetConnection();

        await connection.OpenAsync(cancellationToken);

        string sql = @"
SELECT 
    p.Id,
    p.Price,
	JSON_QUERY(
		(
			SELECT 
				u.Id,
				u.Name
			FROM Users u
			WHERE u.Id = p.UserId 
			FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
		)
	) AS [User],
    p.Localization,
    JSON_QUERY(
        (
            SELECT 
                c.Kilometer,
                c.YearOfManufacture,
                c.YearOfModel,
                c.TransmissionTypeId AS TransmissionType,
                c.FuelTypeId AS FuelType,
				JSON_QUERY(
					(
						 SELECT 
                            v.Id,
                            v.Name,
							JSON_QUERY(
								(
								 SELECT 
									m.Id,
									m.Name,
									JSON_QUERY(
										(
										SELECT 
                                            b.Id,
                                            b.Name
                                        FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
										)
									) as Brand
									FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
								)
							) AS Model
					FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
					)
				) AS Version
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
        )
    ) AS Car,
    p.CreatedAt,
    JSON_QUERY(
        (
            SELECT i.ScannedFileId
            FROM PostStorage i 
            WHERE i.PostId = p.Id
            FOR JSON PATH
        )
    ) AS Images
FROM Posts p
JOIN Car c ON c.Id = p.CarId
JOIN Versions v ON v.Id = c.VersionId
JOIN Models m ON m.Id = v.ModelId
JOIN Brands b ON b.Id = m.BrandId
WHERE 
    (@request_VersionId IS NULL OR v.Id = @request_VersionId) AND
    (@request_Fuel IS NULL OR c.FuelTypeId = @request_Fuel) AND
    (@request_Body IS NULL OR c.BodyTypeId = @request_Body) AND
    (@request_Condition IS NULL OR c.ConditionTypeId = @request_Condition) AND
    (@request_Clutch IS NULL OR c.TransmissionTypeId = @request_Clutch) AND
    (@request_StartKilometer IS NULL OR c.Kilometer >= @request_StartKilometer) AND
    (@request_EndKilometer IS NULL OR c.Kilometer <= @request_EndKilometer) AND
    (@request_Armored IS NULL OR c.IsArmored = @request_Armored) AND
    (@request_Licensed IS NULL OR c.IsLicensed = @request_Licensed) AND
    (@request_StartYear IS NULL OR (c.YearOfManufacture >= @request_StartYear OR c.YearOfModel >= @request_StartYear)) AND
    (@request_EndYear IS NULL OR (c.YearOfManufacture <= @request_EndYear OR c.YearOfModel <= @request_EndYear)) AND
    (@request_StartPrice IS NULL OR p.Price >= @request_StartPrice) AND
    (@request_EndPrice IS NULL OR p.Price <= @request_EndPrice) AND
    (@request_Localization IS NULL OR p.Localization = @request_Localization)
FOR JSON PATH;";

        string json = await connection.QueryFirstOrDefaultAsync<string>(sql, new
        {
            request_VersionId = request.VersionId,
            request_Fuel = request.Fuel,
            request_Body = request.Body,
            request_Condition = request.Condition,
            request_Clutch = request.Clutch,
            request_StartKilometer = request.StartKilometer,
            request_EndKilometer = request.EndKilometer,
            request_Armored = request.Armored,
            request_Licensed = request.Licensed,
            request_StartYear = request.StartYear,
            request_EndYear = request.EndYear,
            request_StartPrice = request.StartPrice,
            request_EndPrice = request.EndPrice,
            request_Localization = request.Localization
        });

        List<PostDTO> postList = JsonConvert.DeserializeObject<List<PostDTO>>(json);

        return postList;
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
        Guid? versionId,
        Guid? modelId,
        Guid? brandId
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
        public Guid? ModelId { get; set; } = modelId;
        public Guid? BrandId { get; set; } = brandId;
    }
}
