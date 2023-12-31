SELECT CountryName AS "Country Name", IsoCode AS "ISO Code"
FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(UPPER(CountryName), 'A', '')) >= 3
ORDER BY IsoCode