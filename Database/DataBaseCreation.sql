create table if not exists Users(
	id bigint generated always as identity primary key,
	firstName varchar(255) not null,
	lastName varchar(255) not null,
	cpf varchar(14) not null,
	email varchar(255) not null,
	phone varchar(11) not null,
	passwordHash bytea not null,
	passwordSalt bytea not null,
	userToken text,
	isActive bool not null
);

