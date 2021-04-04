------------------------Triggers For Utilisateur-----------------------------------------------------
create or alter Trigger Creation_Compte_Par_Default 
on Utilisateur 
after insert
as
if(select count(*) from inserted)=1
	begin
		declare @id uniqueidentifier =(select top(1) ID from inserted)
		insert into Comptes(Nom,U_id) values ('Jibi',@id),('Note',@id)
	end









------------------------Triggers For Compte-----------------------------------------------------

------------------------Triggers For Action-----------------------------------------------------

------------------------Triggers For Utilisateur-----------------------------------------------------


