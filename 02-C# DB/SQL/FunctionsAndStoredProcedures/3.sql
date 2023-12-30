CREATE PROCEDURE usp_GetTownsStartingWith
(
	@StartsWith VARCHAR(255)
)
AS
	BEGIN
		SELECT
			Name AS "Town"
		FROM
			Towns
		WHERE
			Name LIKE @StartsWith + '%'
	END;

EXEC usp_GetTownsStartingWith 'Wa'