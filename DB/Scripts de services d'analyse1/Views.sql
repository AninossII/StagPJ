-----------------------------------------------
create or alter proc Get_Comptes_from_ID_Utili 
@ID uniqueidentifier
as
select ID,Nom from Comptes where U_id = @ID
-----------------------------------------------



