CREATE PROCEDURE UpdateVersion
(
@Number NVARCHAR(20),
@Type NVARCHAR(20)
)
AS
UPDATE [Versions] 
SET [Number] = @Number
WHERE [Type] = @Type