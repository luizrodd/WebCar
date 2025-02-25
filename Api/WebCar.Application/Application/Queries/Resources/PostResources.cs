namespace WebCar.Application.Application.Queries.Resources
{
    public class PostResources
    {
        public const string GET_DETAILS_BY_ID= @"
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
            SELECT 
                i.ScannedFileId,
                i.Filename
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

		public const string GET_ALL = @"
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
            SELECT 
                i.ScannedFileId,
                i.Filename
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
    (@VersionId IS NULL OR v.Id = @VersionId) AND
    (@Fuel IS NULL OR c.FuelTypeId = @Fuel) AND
    (@Body IS NULL OR c.BodyTypeId = @Body) AND
    (@Condition IS NULL OR c.ConditionTypeId = @Condition) AND
    (@Clutch IS NULL OR c.TransmissionTypeId = @Clutch) AND
    (@StartKilometer IS NULL OR c.Kilometer >= @StartKilometer) AND
    (@EndKilometer IS NULL OR c.Kilometer <= @EndKilometer) AND
    (@Armored IS NULL OR c.IsArmored = @Armored) AND
    (@Licensed IS NULL OR c.IsLicensed = @Licensed) AND
    (@StartYear IS NULL OR (c.YearOfManufacture >= @StartYear OR c.YearOfModel >= @StartYear)) AND
    (@EndYear IS NULL OR (c.YearOfManufacture <= @EndYear OR c.YearOfModel <= @EndYear)) AND
    (@StartPrice IS NULL OR p.Price >= @StartPrice) AND
    (@EndPrice IS NULL OR p.Price <= @EndPrice) AND
    (@Localization IS NULL OR p.Localization = @Localization)
FOR JSON PATH;
";
    }
}
