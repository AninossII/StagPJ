--I => insert 
--U => update 
--D => delete

--INSCRIRE PREMIERE FOIS
create or alter procedure dbo.I_Action
@Time datetime,
@Designation char(256),
@Prix float,
@C_id uniqueidentifier,
@responseMessage char(256) OUTPUT
as 
SET NOCOUNT ON
BEGIN TRY
    INSERT INTO dbo.Action(Time,Designation,Prix,C_id) 
	values (@Time,@Designation,@Prix,@C_id)

	if(select @@ROWCOUNT) > 0
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
create or alter procedure dbo.U_Action
@ID  uniqueidentifier,
@Time datetime,
@Designation char(256),
@Prix float,
@C_id uniqueidentifier,
@responseMessage char(256) OUTPUT
as
BEGIN TRY
	update Action 
	set Time = @Time,Designation = @Designation,Prix= @Prix,C_id = @C_id
	where id = @ID
		
	if(select @@ROWCOUNT) > 0
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
create or alter procedure dbo.D_Action
@ID  uniqueidentifier,
@responseMessage char(256) OUTPUT
as
BEGIN TRY
	delete Action where id = @ID
		
	if(select @@ROWCOUNT) > 0
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
create or alter proc Get_A_id_By_C_id 
@ID_C uniqueidentifier,
@ID_A uniqueidentifier out
as
set @ID_A = (select top(1) ID from [Action] where C_id = @ID_C order by Time Desc)
declare @id uniqueidentifier
exec Get_A_id_By_C_id '973809C7-DD33-4E8C-B0CB-3450449CF75E',@id out
select @id