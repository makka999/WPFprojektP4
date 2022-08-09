USE KolekcjaPlyt
GO

CREATE TRIGGER WyzwalaczDeletePlyta
ON Plyta
INSTEAD OF DELETE
NOT FOR REPLICATION
AS

	SET NOCOUNT ON;

	UPDATE Plyta
	SET StatusPosiadania = 'Usuni�ta z kolekcji'
	WHERE EXISTS (
	SELECT *
	FROM deleted AS d
	WHERE d.IdPlyta = Plyta.IdPlyta)
	PRINT N'Status zmieniony na Usuni�ta z kolekcji'
;



