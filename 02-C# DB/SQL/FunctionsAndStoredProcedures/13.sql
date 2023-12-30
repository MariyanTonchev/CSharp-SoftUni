CREATE FUNCTION ufn_CashInUsersGames
(
	@gameName NVARCHAR(255)
) RETURNS TABLE
AS
RETURN 
(
	SELECT
		SUM(gg.Cash) AS "SumCash"
	FROM
	(
		SELECT
			g.Name,
			ug.Cash,
			ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS RowN
		FROM 
			Games AS g
			JOIN UsersGames AS ug ON ug.GameId = g.Id
		WHERE
			Name = @gameName
	) AS gg
	WHERE gg.RowN % 2 != 0
);

--Check
--SELECT * FROM ufn_CashInUsersGames('Love in a mist');