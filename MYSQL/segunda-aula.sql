-- Aula 1.1
-- Operação via terminal (cmd)

/*
- Checar se o xampp (C:\xampp\mysql\bin) foi adicionados a variáveis de ambiente
- Conectar: mysql -u root -p
*/

show databases; -- Lista todos os bancos, ponto e vírgula é necessário
use dio_mysql -- Selecionar um banco de dados

show tables; -- Lista as tabelas do banco

CREATE TABLE cursos(id_curso INT NOT NULL PRIMARY KEY AUTO_INCREMENT, nome VARCHAR(10));
-- criando outra tabela

INSERT INTO cursos (nome) VALUES ('MySQL');
INSERT INTO cursos (nome) VALUES ('HTML');
INSERT INTO cursos (nome) VALUES ('CSS');
SELECT * FROM cursos;

UPDATE cursos SET nome='HTML 5' WHERE id_curso=2;
SELECT * FROM cursos;


-- Aula 1.2

ALTER TABLE cursos ADD carga_horaria INT(2)
UPDATE cursos SET carga_horaria=20;;

exit -- encerrar a conexão com o banco

CREATE DATABASES teste;
use teste
CREATE TABLE testes(id_teste INT NOT NULL PRIMARY KEY AUTO_INCREMENT);
show tables;

DROP TABLE testes; -- Apaga a tabela
show tables;

DROP DATABASES teste; -- Apaga o banco
show databases;

-- Apartir daqui, sem terminal

-- Aula 2.2

CREATE TABLE videos (id_video INT NOT NULL PRIMARY KEY AUTO_INCREMENT, author VARCHAR(30), title VARCHAR(30), likes INT, deslikes INT)

INSERT INTO videos (author, title, likes, deslikes) VALUES ('Maria', 'MySQL', 10, 2);
INSERT INTO videos (author, title, likes, deslikes) VALUES ('Joao', 'HTML', 30, 1);
INSERT INTO videos (author, title, likes, deslikes) VALUES ('Maria', 'CSS', 18, 3);
INSERT INTO videos (author, title, likes, deslikes) VALUES ('Pedro', 'JavaScript', 15, 8);
INSERT INTO videos (author, title, likes, deslikes) VALUES ('Maria', 'Python', 50, 0);

CREATE TABLE author (id_author INT NOT NULL PRIMARY KEY AUTO_INCREMENT, name VARCHAR(30), born DATE)

INSERT INTO author (name, born) VALUES ('Maria', '1992-04-19');
INSERT INTO author (name, born) VALUES ('Pedro', '2000-10-12');
INSERT INTO author (name, born) VALUES ('João', '1998-03-09');
INSERT INTO author (name, born) VALUES ('Flávia', '2008-12-05');


-- Aula 2.3

ALTER TABLE videos MODIFY author INT;
-- Muda o tipo de dado da coluna

UPDATE videos SET author=1 WHERE id_video=1;
UPDATE videos SET author=1 WHERE id_video=3;
UPDATE videos SET author=1 WHERE id_video=5;
UPDATE videos SET author=2 WHERE id_video=4;
UPDATE videos SET author=3 WHERE id_video=2;


-- Aula 2.4

ALTER TABLE videos CHANGE author fk_author INT
-- Muda o nome da coluna

ALTER TABLE videos ADD FOREIGN KEY (fk_author) REFERENCES author(id_author) ON DELETE CASCADE 
ON UPDATE CASCADE;
/* Adiciona o FK na coluna fk_author da tabela videos, referente a coluna id_author da
tabela author. CASCADE faz as alterações de um tabela pai se refletirem em uma tabela
filha de forma automatica. */

SELECT * FROM videos JOIN author ON videos.fk_author = author.id_author
/* Leitura: Selecione todos os dados da tabela videos, jutando com os dados da tabela author,
onde a coluna fk_author da tabela videos for igual a coluna id_author da tabela author. */

SELECT videos.title, author.name FROM videos JOIN author ON videos.fk_author = author.id_author
/* O mesmo que o anterior mas exibindo somente as colunas title e name. */


-- Aula 2.5

CREATE TABLE seo (id_seo INT NOT NULL PRIMARY KEY AUTO_INCREMENT, category VARCHAR(20))

INSERT INTO videos (fk_author, title, likes, deslikes) VALUES (2, 'PHP', 20, 8)

INSERT INTO seo (category) VALUES ('Frontend');
INSERT INTO seo (category) VALUES ('Backend');

ALTER TABLE videos ADD fk_seo INT AFTER title

UPDATE videos set fk_seo=1 WHERE id_video=2;
UPDATE videos set fk_seo=1 WHERE id_video=3;
UPDATE videos set fk_seo=1 WHERE id_video=4;

UPDATE videos set fk_seo=2 WHERE id_video=1;
UPDATE videos set fk_seo=2 WHERE id_video=5;
UPDATE videos set fk_seo=2 WHERE id_video=6;

ALTER TABLE videos ADD FOREIGN KEY (fk_seo) REFERENCES seo(id_seo) ON DELETE CASCADE
ON UPDATE CASCADE;


-- Aula 2.6

-- Montando passo a passo
SELECT * FROM videos JOIN seo ON videos.fk_seo = seo.id_seo;

SELECT videos.title, seo.category FROM videos JOIN seo ON videos.fk_seo = seo.id_seo;

SELECT videos.title, author.name, seo.category FROM videos JOIN seo ON videos.fk_seo = seo.id_seo
JOIN author on videos.fk_author = author.id_author;


-- Aula 2.7

CREATE TABLE playlist (id_playlist INT NOT NULL PRIMARY KEY AUTO_INCREMENT, name_pl VARCHAR(30))

INSERT INTO playlist (name_pl) VALUES ('HTML + CSS');
INSERT INTO playlist (name_pl) VALUES ('HTML + PHP + JS');
INSERT INTO playlist (name_pl) VALUES ('Python + PHP');


-- Aula 2.8

CREATE TABLE videos_playlist (id_vp INT NOT NULL PRIMARY KEY AUTO_INCREMENT, fk_videos INT,
fk_playlist INT);

INSERT INTO videos_playlist (fk_videos, fk_playlist) VALUES (2, 1);
INSERT INTO videos_playlist (fk_videos, fk_playlist) VALUES (3, 1);

-- Montando passo a passo
SELECT * FROM playlist JOIN videos_playlist ON playlist.id_playlist = videos_playlist.fk_playlist

SELECT * FROM playlist JOIN videos_playlist ON playlist.id_playlist = videos_playlist.fk_playlist
JOIN videos ON videos.id_video = videos_playlist.fk_videos;

SELECT playlist.name_pl, videos.title FROM playlist
JOIN videos_playlist ON playlist.id_playlist = videos_playlist.fk_playlist
JOIN videos ON videos.id_video = videos_playlist.fk_videos;

SELECT playlist.name_pl, videos.title, author.name FROM playlist
JOIN videos_playlist ON playlist.id_playlist = videos_playlist.fk_playlist
JOIN videos ON videos.id_video = videos_playlist.fk_videos
JOIN author ON videos.fk_author = author.id_author;


ALTER TABLE playlist ADD fk_author INT

UPDATE playlist SET fk_author=4 WHERE id_playlist=1;

SELECT author.name, playlist.name_pl FROM playlist
JOIN author ON playlist.fk_author = author.id_author;