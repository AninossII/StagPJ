------------------------Triggers For Utilisateur-----------------------------------------------------
---------------TO add Default Comptes
create or alter Trigger Creation_Compte_Par_Default 
on Utilisateur 
after insert
as
if(select count(*) from inserted)=1
	begin
		declare @id uniqueidentifier =(select top(1) ID from inserted)
		insert into Comptes(Nom,U_id) values ('Jibi',@id),('Note',@id)
	end
---------------TO 


------------------------Triggers For Compte-----------------------------------------------------
---------------TO 
/*create or alter Trigger For_not_repeate_nom_Compte 
on Comptes 
after Insert,update
as
declare @t cursor select nom from  

declare @NOM char(20) = (Select top(1) Nom from inserted)
declare @U_ID UNIQUEIDENTIFIER = (Select top(1) U_id from inserted)
	if (select Count(Nom) from Comptes where U_id = @U_ID and Nom = @NOM group by U_id) > 0 
	BEGIN 
		PRINT 'THIS IS REPETATE'
		rollback
	END 
Go

*/
------------------------Triggers For Action-----------------------------------------------------

------------------------Triggers For Utilisateur-----------------------------------------------------

declare @msg char(100)
exec dbo.I_Comptes 'CI',50,'D7232F9B-22E1-44B1-9019-BF2CFBB4D497',@msg out
print trim(@msg)

Select * from Comptes order by Nom

delete from comptes where u_id = 'D7232F9B-22E1-44B1-9019-BF2CFBB4D497' and C_montant = 50

select Count(Nom) from Comptes where Nom = 'Note' AND U_id = 'D7232F9B-22E1-44B1-9019-BF2CFBB4D497'

declare @msg char(100)
exec dbo.U_Comptes '16FC574C-CF16-4FF4-A4BE-4B9A0E8986AB','Cii',50,'D7232F9B-22E1-44B1-9019-BF2CFBB4D497',@msg out
print trim(@msg)



