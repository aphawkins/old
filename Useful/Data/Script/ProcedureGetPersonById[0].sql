CREATE PROCEDURE GetPersonById
(
@Id INTEGER
)
AS
SELECT * 
FROM [People]
WHERE [People].[Id] = @Id
