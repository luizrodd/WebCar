using Dapper;
using MediatR;
using Newtonsoft.Json;
using WebCar.Application.Application.DTOs;
using WebCar.Application.Application.Infrastructure;

namespace WebCar.Application.Application.Queries;

public class GetBrandsFromPostQueryHandler(SqlConnectionProvider sqlConnectionProvider) : IRequestHandler<GetBrandsFromPostQuery, List<BrandDetailsDTO>>
{
    private readonly SqlConnectionProvider _sqlConnectionProvider = sqlConnectionProvider ?? throw new ArgumentNullException(nameof(sqlConnectionProvider));
    public async Task<List<BrandDetailsDTO>> Handle(GetBrandsFromPostQuery request, CancellationToken cancellationToken)
    {
        var sql = @"
SELECT
    b.Id,
    b.Name,
    JSON_QUERY((
        SELECT
            m.Id,
            m.Name,
            JSON_QUERY((
                SELECT DISTINCT
                    v.Id,
                    v.Name
                FROM
                    Versions AS v
                INNER JOIN
                    Car AS c ON c.VersionId = v.Id
                WHERE 
                    v.ModelId = m.Id
                    AND EXISTS (  
                        SELECT 1
                        FROM Car AS c2
                        WHERE c2.VersionId = v.Id
                    )
                FOR JSON PATH
            )) AS Versions
        FROM 
            Models AS m
        WHERE 
            m.BrandId = b.Id
        AND EXISTS ( 
            SELECT 1
            FROM Versions AS v
            INNER JOIN Car AS c ON c.VersionId = v.Id
            WHERE v.ModelId = m.Id
        )
        FOR JSON PATH
    )) AS Models
FROM 
    Brands AS b
WHERE EXISTS (  
    SELECT 1
    FROM Models AS m
    INNER JOIN Versions AS v ON v.ModelId = m.Id
    INNER JOIN Car AS c ON c.VersionId = v.Id
    WHERE m.BrandId = b.Id
)
FOR JSON PATH;
";
        var connection = _sqlConnectionProvider.GetConnection();
        connection.Open();


        var json = await connection.QueryFirstOrDefaultAsync<string>(sql);

        List<BrandDetailsDTO> brands = JsonConvert.DeserializeObject<List<BrandDetailsDTO>>(json);

        return brands;
    }
}
public class GetBrandsFromPostQuery() : IRequest<List<BrandDetailsDTO>>;

