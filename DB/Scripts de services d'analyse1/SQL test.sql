declare @message char(50)
exec dbo.I_Utilisateur 'test11@gmail.com','test1','jiji','ayoub','12-12-12','12-12-20','M',@message output
print @message

select * from Utilisateur
select Password from Utilisateur
declare @password binary(70) = hashbytes('SHA2_512','test1')
print @password
if @message = 's'
	print 'true'
	
declare @t table(id uniqueidentifier default newid() primary key,[user] int)

insert into @t ([user]) values(1),(2),(3)

select * from @t

select * from INFORMATION_SCHEMA.TABLES
select * from utilisateur where Email ='test11@gmail.com'


drop table Sours
drop table categorie
drop table [Action]
drop table Comptes
drop table Utilisateur


declare @t table(id int)
insert into @t values(1),(4),(2),(4)


select *,t.* from @t,@t t
select @@ROWCOUNT

declare @ms char(256)
exec dbo.I_Utilisateur 'hello@world.co','pass','ALaui','Rachid','12-12-12','01-01-12','M',@ms output
print @ms 
insert into utilisateur (Email,[Password],Nom,prenom) values('sss',HASHBYTES('SHA2_512', 'sss'),'sss','sss')
select * from Utilisateur
select * from Comptes where U_id = 'D7232F9B-22E1-44B1-9019-BF2CFBB4D497'




