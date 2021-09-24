drop database if exists api_nba;

create database if not exists api_nba;

use api_nba;

create table if not exists usuario(
	id_usuario int auto_increment primary key,
    email_usuario varchar(20) not null,
    user_usuario varchar(20) not null,
    senha_usuario varchar(20) not null
);

create table if not exists arena(
	id_arena int auto_increment primary key,
    nome_arena varchar(200) not null,
    cidade_arena varchar(200) not null,
    estado_arena varchar(200) not null,
    capacidade_arena bigint not null,
    id_equipe int
);

create table if not exists favorita_jogador(
	id_jogador int,
    id_usuario int,
    foreign key(id_usuario) references usuario (id_usuario)
    ON DELETE CASCADE 
    ON UPDATE CASCADE
);

create table if not exists favorita_equipe(
	id_equipe int, 
    id_usuario int, 
    foreign key(id_usuario) references usuario (id_usuario)
    ON DELETE CASCADE 
    ON UPDATE CASCADE
);

create table if not exists favorita_arena(
	id_usuario int,
    id_arena int,
    foreign key(id_usuario) references usuario (id_usuario),
    foreign key(id_arena) references arena (id_arena)
    ON DELETE CASCADE 
    ON UPDATE CASCADE
);

insert into usuario 
values (default, "gabi123@gmail.com","neves", "25082003"),
		(default, "renan123@gmail.com", "damprelli", "11092003");

insert into arena
values(default, "Staples Center", "Los Angeles", "Califoria", 18118, 1), 
	(default, "Quicken Loans Arena", "Cleveland", "Ohio", 19432, 2),
	(default, "Madison Square Garden", "Manhattan", "New York", 19033, 3),
	(default, "American Airlines Arenas", "Miami", "Florida", 19600, 4),
	(default, "Barclays Center", "Broklyn", "New York", 17732, 5);
    
insert into favorita_arena 
values (1,1),
	(2,1),
    (1,2);
    
insert into favorita_jogador
values (1,2),
	(2,2),
    (2,1);
    
insert into favorita_equipe
values (1,2),
	(2,1),
    (1,1);