/*
create or alter proc statistiques
@Id_U uniqueidentifier
as
with view1 as(
select distinct A.C_id,[count] = count(*) over(partition by A.C_id) 
from [Action] as A inner join Comptes as C on C.ID = A.C_id
where C.U_id = @Id_U 
)
select C.Nom,C.C_montant from Comptes C
inner join view1 v on v.C_id = C.ID
where Id in (select top(3) C_id from view1 order by [count] desc)
order by v.[count] 
go
select * from Comptes where ID ='973809C7-DD33-4E8C-B0CB-3450449CF75E'

select * from Utilisateur where ID = 'CDFA2082-41C6-42D2-B82E-68D0643799D4'
select * from Action where C_id = '973809C7-DD33-4E8C-B0CB-3450449CF75E'

exec statistiques 'CDFA2082-41C6-42D2-B82E-68D0643799D4'
/*select U.ID,COUNT(*) from Utilisateur U inner join Comptes C on U.ID = C.U_id
group by U.ID*/
*/
--------------------------------------------------------------------------------
create or alter proc statistiques_Added_And_Withdraw_Money
@Id_U uniqueidentifier,@Withdraw float out,@Added float out
as
declare @t T_AW
insert into @t select 
	[withdraw]= SUM(Prix) from Action 
	where Prix < 0 and C_id in (select ID from Comptes where U_id =@Id_U)
group by Time
having (datediff(dd,concat(month(EOMONTH(GETDATE())),'-1-',year(EOMONTH(GETDATE()))),[Time]))>=0

set @Withdraw = (select SUM(sun) from @t )
delete from @t
insert into @t select 
	[withdraw]= SUM(Prix) from Action 
	where Prix > 0 and C_id in (select ID from Comptes where U_id =@Id_U)
group by Time
having (datediff(dd,concat(month(EOMONTH(GETDATE())),'-1-',year(EOMONTH(GETDATE()))),[Time]))>=0
set @Added = (select SUM(sun) from @t )
-------------------------------------------------------------------
Declare @a float,@w float
exec statistiques_Added_And_Withdraw_Money 'CDFA2082-41C6-42D2-B82E-68D0643799D4',@w out,@a out
select @w as 'Withdraw'
select @a as 'Added'
select * from Action where C_id in (select ID from Comptes where U_id = 'CDFA2082-41C6-42D2-B82E-68D0643799D4')
-----------------------------------------------------------------------

----------------------------


---------------------------------------------------
create or alter proc statistiques_Added_Money
@Id_U uniqueidentifier
as
with _view1 as 
(
select 
[Added]= SUM(Prix) from Action 
where Prix > 0 and C_id in (select ID from Comptes where U_id =@Id_U)
group by [Time]
having day(EOMONTH(GETDATE())) - datediff(DAY,[Time],getdate())>=0
)
select 
	[Added] = sum(Added)
from _view1

------------------------------------------------------------------
exec dbo.statistiques_Added_Money 'CDFA2082-41C6-42D2-B82E-68D0643799D4'
exec dbo.statistiques_Withdraw_Money 'CDFA2082-41C6-42D2-B82E-68D0643799D4'
--select * from Comptes where U_id = 'CDFA2082-41C6-42D2-B82E-68D0643799D4'
exec dbo.statistiques_Added_Money 'D7232F9B-22E1-44B1-9019-BF2CFBB4D497'
exec dbo.statistiques_Withdraw_Money 'D7232F9B-22E1-44B1-9019-BF2CFBB4D497'







select * from Utilisateur
where ID in (select U_id from Comptes C inner join Action A on C.ID = A.C_id)
select ID from Utilisateur
-----------------------------------------------
SELECT GETDATE()
SELECT day(EOMONTH(GETDATE())) - datediff(DAY,'2021-03-12 00:00:00.000',getdate())
select * from Action

added = 5000
withdraw = -451

DECLARE @ADate DATETIME
SET @ADate = GETDATE()
SELECT @ADate 
SELECT day(EOMONTH(@ADate)) AS DaysInMonth
SELECT month(EOMONTH(@ADate)) AS DaysInMonth
SELECT year(EOMONTH(@ADate)) AS DaysInMonth



select GETDATE()
select * from Action 
select * from Comptes where U_id = (select U_id from Comptes where ID='E64A4B93-B5E1-4D40-ABC3-2CDCDF229E6D')
declare @msg char(100)
exec dbo.I_Action '2021-04-11 07:01:02','eat',-50,'E64A4B93-B5E1-4D40-ABC3-2CDCDF229E6D',@msg out
print @msg
create or alter procedure dbo.I_Action
@Time datetime,
@Designation char(256),
@Prix float,
@C_id uniqueidentifier,
@responseMessage char(256) OUTPUT
-------------------------------------------------------------



