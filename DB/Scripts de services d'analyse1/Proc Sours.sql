--I => insert 
--U => update 
--D => delete

--INSCRIRE PREMIERE FOIS
create or alter procedure dbo.I_Sours
@Designation char(256),
@A_id uniqueidentifier,
@responseMessage char(256) OUTPUT
as 
SET NOCOUNT ON
BEGIN TRY
    INSERT INTO dbo.Sours(Designation,A_id) 
	values (@Designation,@A_id)

    if (Select @@CONNECTIONS) > 0
		throw 50500,'Success',1;
	else
		throw 50404,'Faild',1;

END TRY
BEGIN CATCH
    SET @responseMessage= concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
END CATCH


----------------------
--declare @message char(256)

--print @message
----------------------

--for update Category
create or alter procedure dbo.U_Sours
@ID int,
@Designation char(256),
@A_id uniqueidentifier,
@responseMessage char(256) OUTPUT
as
BEGIN TRY
	update Sours 
	set Designation=@Designation,A_id=@A_id
	where id = @ID
    
    if (Select @@CONNECTIONS) > 0
		throw 50500,'Success',1;
	else
		throw 50404,'Faild',1;

END TRY
BEGIN CATCH
    SET @responseMessage=concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
END CATCH
------------------------
--declare @message char(256)

--print @message
-------------------------

--for delete categorie
create or alter procedure dbo.D_Sours
@ID int,
@responseMessage char(256) OUTPUT
as
BEGIN TRY
	Delete Sours where id = @ID

    if (Select @@CONNECTIONS) > 0
		throw 50500,'Success',1;
	else
		throw 50404,'Faild',1;

END TRY
BEGIN CATCH
    SET @responseMessage=concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
END CATCH
------------------------
--declare @message char(256)

--print @message
-------------------------