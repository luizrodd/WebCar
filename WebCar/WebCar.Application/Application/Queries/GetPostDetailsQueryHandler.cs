using Dapper;
using MediatR;
using Newtonsoft.Json;
using WebCar.Application.Application.DTOs;
using WebCar.Application.Infrastructure;

namespace WebCar.Application.Application.Queries;

public class GetPostDetailsQueryHandler(SqlConnectionProvider sqlConnectionProvider) : IRequestHandler<GetPostDetailsQuery, PostDetailsDTO>
{
    private readonly SqlConnectionProvider _sqlConnectionProvider = sqlConnectionProvider ?? throw new ArgumentNullException(nameof(sqlConnectionProvider));
    public async Task<PostDetailsDTO> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
    {
        string sql = @"
use [DB-CAR-APP]

SELECT 
    p.Id,
	p.Description,
	p.AcceptTrade,
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
				c.ConditionTypeId AS ConditionType,
                c.TransmissionTypeId AS TransmissionType,
                c.FuelTypeId AS FuelType,
				c.BodyTypeId AS BodyType,
				c.IsArmored,
				c.IsLicensed,
                c.YearOfManufacture,
                c.YearOfModel,
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
WHERE p.Id = @PostId
FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
";

		var connection = _sqlConnectionProvider.GetConnection();

		connection.Open();

		var json = await connection.QueryFirstOrDefaultAsync<string>(sql, new { PostId = request.PostId });

		var post = JsonConvert.DeserializeObject<PostDetailsDTO>(json);

		return post;
    }
}

public class GetPostDetailsQuery(Guid postId) : IRequest<PostDetailsDTO>
{
    public Guid PostId { get; set; } = postId;
}
