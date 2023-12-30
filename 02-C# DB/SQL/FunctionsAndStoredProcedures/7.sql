CREATE FUNCTION ufn_IsWordComprised
(
	@setOfLetters NVARCHAR(255), 
	@word NVARCHAR(255)
)
RETURNS BIT
AS
	BEGIN
		DECLARE @result BIT = 1;
		DECLARE @charCount INT = LEN(@word);
		DECLARE @i INT = 1;

		WHILE @i <= @charCount
		BEGIN
			DECLARE @charToCheck CHAR(1) = SUBSTRING(@word, @i, 1);

			IF CHARINDEX(@charToCheck, @setOfLetters) = 0
			BEGIN
				SET @result = 0;
				BREAK;
			END
			
			SET @i = @i + 1;
		END

		RETURN @result;
END;