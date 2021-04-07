--I => insert 
--U => update 
--D => delete
--------- LOGIN with Email ------------
create or alter procedure dbo.User_Login
@Email char(150),
@password char(20),
@responseMessage char(256) OUTPUT
as
begin try 
	if not exists (select * from Utilisateur where Email = @Email)
		begin 
			throw 50404,'user undifounded',1;
		end
	else
		begin 
			declare @pass binary(70) = (select Password from Utilisateur where Email = @Email)
			
			if @pass = HASHBYTES('SHA2_512',trim(@password))
				throw 50500,'Connected',1;
			else
				throw 50404,'faild password',1;
		end
end try
begin catch
	SET @responseMessage= concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
end catch
----------------------------------------
declare @message char(256)
declare @connect char(5)
print @message
exec dbo.User_Login 'fijdnf','ddddd',@message output
--50500##Connected 
---------------------------------------

--INSCRIRE PREMIERE FOIS
create or alter procedure dbo.I_Utilisateur
@Email char(150),
@Password char(20),
@Nom char(20),
@Prenom char(20),
@Datenes date,
@Dateins datetime,
@Genre char,
@responseMessage char(256) OUTPUT
as 
SET NOCOUNT ON
BEGIN TRY
    INSERT INTO dbo.Utilisateur(Email,[Password],Nom,Prenom,Datenes,Dateins,Genre) 
	values (@Email,HASHBYTES('SHA2_512', TRIM(@Password)),@Nom,@Prenom,@Datenes,@Dateins,@Genre)
	if (select @@ROWCOUNT) > 0
		THROW 505000,'inscrire success',1;
END TRY
BEGIN CATCH
	if ERROR_NUMBER() = 2627
	    SET @responseMessage= concat(50404,'##','the email already exists change it')
	else
		SET @responseMessage= concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
END CATCH
----------------------
declare @message char(256)
exec dbo.I_Utilisateur 'Ayoub@gmail.com','team','gg','gg','12-12-12','12-12-20','M',@message output
print @message
----------------------

--for change profile donnees
create or alter procedure dbo.U_Utilisateur
@ID uniqueidentifier,
@Nom char(20),
@Prenom char(20),
@Datenes date,
@Dateins datetime,
@Genre char,
@responseMessage char(256) OUTPUT
as
BEGIN TRY
	if not exists(select id from utilisateur where id = @ID)
		begin
		throw 57,'this user undifounded',1;
		SET @responseMessage= concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
		end
	update Utilisateur 
	set Nom=@Nom,Prenom=@Prenom,Datenes=@Datenes,Dateins=@Dateins,Genre=@Genre
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
exec dbo.U_Utilisateur '19259835-4C54-4C22-9151-A96F6BFC1558','haha','jilan','12-12-12','12-12-20','F',@message output
print @message
-------------------------

--pour change password
create or alter procedure dbo.Change_Password_Utilisateur
@Email char(150),
@newPassword char(20), 
@responseMessage char(256) OUTPUT
as
BEGIN TRY
	if not exists(select id from utilisateur where Email = @Email)
		begin
		throw 56,'user undifounded',1;
		SET @responseMessage= concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
		end
	update Utilisateur 
	set [Password] = HASHBYTES('SHA2_512', TRIM(@newPassword))
	where Email = @Email
	
	if (Select @@CONNECTIONS) > 0
		throw 50500,'Success',1;
	else
		throw 50404,'Faild',1;
    
END TRY
BEGIN CATCH
    SET @responseMessage=concat(ERROR_NUMBER(),'##',ERROR_MESSAGE())
END CATCH
-------------------------------
--Get Nombre Compte par Id Utilisateur
create or alter Function Count_Compte(@ID uniqueidentifier)
returns int
begin
return (select count(*) from Comptes where U_id = @ID)
end
-----------------------------------------
print dbo.Count_Compte('D7232F9B-22E1-44B1-9019-BF2CFBB4D497')
------------------------------------------
--to get total Mantant 
create or alter Function Get_Total_Mantant(@ID uniqueidentifier)
returns float
begin
return (select SUM(C_Montant) from Comptes where U_id = @ID)
end
---------------------------------------------
print dbo.Get_Total_Mantant('D7232F9B-22E1-44B1-9019-BF2CFBB4D497')
--------------------------------------
--to get last_Time_Action 
create or alter Function last_Time_Action(@ID uniqueidentifier)
returns time
begin
return (select top(1) [time] =cast(A.[Time] as time(0)) from 
Comptes C inner join Action A on A.C_id = C.ID where C.U_id = @ID order by A.[Time] desc)
end
-----------------------------------
select dbo.last_Time_Action('65198CBF-DF87-4BDF-ACBA-3BC2FEBB415C')
select * From Action
select * From Comptes
---------------------------------------------------------------------
--to get profil information 
---------------------------
create or alter proc Get_Info_Profile @ID uniqueidentifier as 
select top(1)
[Nom et prenom] = concat(trim(U.Prenom),' ',TRIM(U.Nom)),
U.Dateins,
[coutCompte]= dbo.Count_Compte(@ID),
[Last_Tran] = dbo.last_Time_Action(@ID),
[Mantant] = dbo.Get_Total_Mantant(@ID)
from Utilisateur as U
where U.ID = @ID 
--------------------------------------------------------
exec dbo.Get_Info_Profile '65198CBF-DF87-4BDF-ACBA-3BC2FEBB415C'
----------------------------------------
-- Email To ID
create or alter Function Get_ID_Utilisateur(@Email char(150))
returns uniqueidentifier 
begin 
	return (select ID from Utilisateur where Email = TRIM(@Email))
end
select * from Utilisateur
                                                                                                                                        

select dbo.Get_ID_Utilisateur('hello@world.co')





