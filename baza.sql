create database Kladionica;
use Kladionica;

create table Utakmica(
	id int identity(1, 1) primary key,
	domaci varchar(32) not null,
	gosti varchar(32) not null,
	pocetak datetime not null
);
create table Kvota(
	id int identity(1, 1) primary key,
	opis varchar(128) not null
);

create table UtakmicaKvota(
	id int identity(1, 1) primary key,
	kvotaId int not null,
	utakmicaId int not null,
	kvota float not null
);

insert into Utakmica(domaci, gosti, pocetak) values
('Liverpool', 'Watford', '2022-04-02T13:30:00'),
('Brighton', 'Norwich', '2022-04-02T16:00:00'),
('Burnley', 'Manchester City', '2022-04-02T16:00:00'),
('Chelsea', 'Brentford', '2022-04-02T16:00:00'),
('Leeds United', 'Southampton', '2022-04-02T16:00:00'),
('Wolves', 'Aston Villa', '2022-04-02T16:00:00'),
('Manchester United', 'Leicester City', '2022-04-02T18:30:00'),
('West Ham', 'Everton', '2022-04-03T15:00:00'),
('Tottenham', 'Newcastle United', '2022-04-03T17:30:00');

insert into Kvota(opis) values
('Tim 1 ce pobediti'),
('Tim 2 ce pobediti'),
('Utakmica ce se zavriti neresenim rezultatom'),
('Oba tima ce postici najmanje po jedan gol'),
('Ukupno ce biti barem 3 gola na mecu');

insert into UtakmicaKvota(kvotaId, utakmicaId, kvota) values
(1, 1, 1.15),
(2, 1, 18.00),
(3, 1, 10.00),
(4, 1, 1.87),
(5, 1, 1.30),

(1, 2, 1.50),
(2, 2, 8.00),
(3, 2, 4.20),
(4, 2, 2.20),
(5, 2, 2.05),

(1, 3, 14.00),
(2, 3, 1.23),
(3, 3, 7.00),
(4, 3, 2.15),
(5, 3, 1.55),

(1, 4, 1.35),
(2, 4, 9.50),
(3, 4, 4.90),
(4, 4, 2.15),
(5, 4, 1.85),

(1, 5, 2.40),
(2, 5, 2.95),
(3, 5, 3.35),
(4, 5, 1.55),
(5, 5, 1.65),

(1, 6, 3.00),
(2, 6, 2.65),
(3, 6, 3.10),
(4, 6, 1.85),
(5, 6, 2.15),

(1, 7, 1.58),
(2, 7, 6.25),
(3, 7, 4.30),
(4, 7, 1.67),
(5, 7, 1.60),

(1, 8, 1.83),
(2, 8, 4.80),
(3, 8, 3.70),
(4, 8, 1.83),
(5, 8, 1.85),

(1, 9, 1.55),
(2, 9, 6.25),
(3, 9, 4.00),
(4, 9, 1.85),
(5, 9, 1.75);

