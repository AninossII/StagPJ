--I => insert 
--U => update 
--D => delete


--INSCRIRE PREMIERE FOIS
create or alter procedure dbo.I_Comptes
@Nom char(20),
@C_Montant float,
@U_id uniqueidentifier,
@responseMessage char(256) OUTPUT
as 
SET NOCOUNT ON
BEGIN TRY
    INSERT INTO dbo.Comptes(Nom,C_Montant,U_id) 
	values (@Nom,@C_Montant,@U_id)

	if (Select @@CONNECTIONS) > 0
		throw 50500,'Success',1;
	else
		throw 50404,'Faild',1;

END TRY
BEGIN CATCH
    SET @responseMessage= concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
END CATCH
----------------------
declare @message char(256)

print @message
----------------------

--for change pasword
create or alter procedure dbo.U_Comptes
@ID uniqueidentifier,
@Nom char(20),
@C_Montant float,
@U_id uniqueidentifier,
@responseMessage char(256) OUTPUT
as
BEGIN TRY

	update Comptes 
	set Nom = @Nom,C_Montant = @C_Montant,U_id = @U_id
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
declare @message char(256)

print @message
-------------------------

--for 
create or alter procedure dbo.D_Comptes
@ID uniqueidentifier,
@responseMessage char(256) OUTPUT
as
BEGIN TRY

	Delete Comptes where id = @ID
    if (Select @@CONNECTIONS)> 0
		throw 50500,'Success',1;
	else
		throw 50404,'Faild',1;

END TRY
BEGIN CATCH
    SET @responseMessage=concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
END CATCH
------------------------
declare @message char(256)

print @message
-------------------------