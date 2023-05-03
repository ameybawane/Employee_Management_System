CREATE PROCEDURE AddDepartment_sp 
	@Name nvarchar(100),
	@IsActive bit
AS
BEGIN
	INSERT INTO Departments (Name,IsActive) VALUES (@Name,@IsActive);
END
GO