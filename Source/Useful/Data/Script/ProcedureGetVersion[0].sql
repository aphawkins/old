CREATE PROCEDURE GetVersion
(
@Type NVARCHAR(20)
)
AS
SELECT [Number] 
FROM [Versions] 
WHERE [Type] = @Type