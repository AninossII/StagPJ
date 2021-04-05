---------------
create table Utilisateur(ID uniqueidentifier default newid(),
						Email char(150) not null constraint UQ_Utilisat_Email unique,
						[Password] binary(70),
						Nom char(20),Prenom char(20),
						Datenes date,Dateins datetime,
						Genre char,
						constraint PK_utilisateur primary key (ID))


create table Comptes(ID uniqueidentifier default newid() constraint PK_comptes primary key,
						Nom char(20),C_Montant float default(0),
		    			U_id uniqueidentifier not null,
						constraint FK_util_compt foreign key (U_id) references Utilisateur(ID))

create table [Action](ID uniqueidentifier default newid() constraint PK_Action primary key,
					[Time] datetime,
					Designation char(256),
					Prix float,
					C_id uniqueidentifier,
					constraint FK_util_Cl_note foreign key (U_id) references Utilisateur(ID),
					constraint FK_compt_Cl_note foreign key (C_id) references Comptes(ID))



create table Sours(ID int identity constraint PK_Sours primary key,
					Designation char(256),
					A_id uniqueidentifier 
					constraint FK_Action_Sours foreign key (A_id) references [Action](ID))

create table Categorie(ID int identity constraint PK_Categorie primary key,
					Designation char(256),
					A_id uniqueidentifier 
					constraint FK_Action_Categorie foreign key (A_id) references [Action](ID))

----------------------------------------------------------------




