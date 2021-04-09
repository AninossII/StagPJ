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
	if (select count(Nom) from Comptes where Nom = @Nom and U_id = @U_id) > 0
		begin
			set @responseMessage = '50404##Le nom de compte deja existe';
		end
	else
		begin
		INSERT INTO dbo.Comptes(Nom,C_Montant,U_id) 
		values (@Nom,@C_Montant,@U_id)
		if (Select @@CONNECTIONS) > 0
			throw 50500,'Success',1;
		else
			throw 50404,'Faild',1;
	end
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
	if (select count(Nom) from Comptes where Nom = @Nom and U_id = @U_id) > 0
		begin
			set @responseMessage = '50404##Le nom de compte deja existe';
		end
	else
	begin
	update Comptes 
	set Nom = @Nom,C_Montant = @C_Montant,U_id = @U_id
	where id = @ID
    
			if (Select @@CONNECTIONS) > 0
				throw 50500,'Success',1;
			else
				throw 50404,'Faild',1;
	end
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
create or alter function Get_name_from_ID(@ID uniqueidentifier)
returns char(20)
begin
return (select Nom from comptes where ID = @ID)
end

select dbo.Get_name_from_ID('0F475268-396E-4374-9147-0E3DF0E155DC')
select * from Comptes
--------------------------------------------------------------------
CREATE OR ALTER function [dbo].[Get_ID_from_nom_U_ID](@Nom char(50), @U_id uniqueidentifier)
returns uniqueidentifier
begin
return (select ID from comptes where Nom = @Nom AND U_id =@U_id)
end

SELECT dbo.Get_ID_from_nom_U_ID('CIH','CDFA2082-41C6-42D2-B82E-68D0643799D4')
--------------------------------------------------------------------
----- To add montant to compte
create or alter procedure Add_Money
@id_C uniqueidentifier,
@id_U uniqueidentifier,
@Montant float,
@responseMessage char(256) OUTPUT
as
BEGIN TRY
	update Comptes
	set C_Montant += @Montant 
	where ID = @id_C and U_id = @id_U
END TRY
BEGIN CATCH
    SET @responseMessage=concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
END CATCH

declare @msg char(100)
exec dbo.Add_Money 'E64A4B93-B5E1-4D40-ABC3-2CDCDF229E6D','D7232F9B-22E1-44B1-9019-BF2CFBB4D497',500.1,@msg out
print concat('dddddddd',@msg,'vvvvvvvvvv')
-----------------------------------------------------------------------------

create or alter procedure Withdraw_Money_from_compte
@id_C uniqueidentifier,
@id_U uniqueidentifier,
@Montant float,
@responseMessage char(256) OUTPUT
as
BEGIN TRY
	if((select C_Montant from Comptes where ID = @id_C and U_id = @id_U	) - @Montant)>=0
	begin 
		update Comptes
		set C_Montant -= @Montant 
		where ID = @id_C and U_id = @id_U	
	end
	else
	begin 
		 SET @responseMessage = '50404##You don`t have money enough!!';
	end
END TRY
BEGIN CATCH
    SET @responseMessage=concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
END CATCH


declare @msg char(100)
exec dbo.Withdraw_Money_from_compte 'E64A4B93-B5E1-4D40-ABC3-2CDCDF229E6D','D7232F9B-22E1-44B1-9019-BF2CFBB4D497',10,@msg out
print @msg


select * from Comptes