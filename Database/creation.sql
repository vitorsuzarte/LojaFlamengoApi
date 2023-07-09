create table if not exists Users(
	Id serial primary key,
	FirstName varchar(255) not null,
	LastName varchar(255) not null,
	Email varchar(255) not null,
	Phone varchar(11) not null,
	Cpf varchar(13) unique not null,
	PasswordHash bytea not null,
	PasswordSalt bytea not null,
	UserToken text not null
);

create table if not exists Items(
	Id serial primary key,
	Description varchar(255) not null,
	Price numeric(8,2) not null,
	Tag varchar(255) not null,
	Image text not null,
	IsActive bool not null
);