CREATE PROCEDURE SetVersion
(
@Version NVARCHAR(20),
@Type NVARCHAR(20)
)
AS
UPDATE [Versions] 
SET [Number] = @Version 
WHERE [Type] = @Type
