
-- Script banco: https://drive.google.com/file/d/1srZQGemOtccHAvlaq0_6h9ZOnZo5dqlg/view

-- Montando Querys passo a passo

-- Aula 1.3

SELECT * FROM videos_canais JOIN videos ON videos_canais.fk_video = videos.id_video

SELECT * FROM videos_canais AS vc JOIN videos AS v ON vc.fk_video = v.id_video
-- Simplificando a query com apelidos


-- Aula 1.4

SELECT * FROM videos_canais AS vc JOIN videos AS v ON vc.fk_video = v.id_video
JOIN canais AS c ON vc.fk_canal = c.id_canal

SELECT v.nome_video, v.autor_video, c.nome_canal
FROM videos_canais AS vc JOIN videos AS v ON vc.fk_video = v.id_video
JOIN canais AS c ON vc.fk_canal = c.id_canal


-- Aula 1.5

-- JOIN ou INNER JOIN (mesma função) retorna valores apenas de dados que possuem relacionamentos

/* OUTER JOIN inclui retornos de dados que não possuem relacionamentos, no entanto é preciso 
identificar o local onde não haverá relacionamentos */


-- Aula 1.6

SELECT * FROM videos_canais AS vc RIGHT OUTER JOIN videos AS v ON vc.fk_video = v.id_video
/* Nesse caso, alguns campos da tabela videos não possuem dados para se relacionar com a tabela
videos_canais. Como a tabela sem dados se encontra a direita da com dados (baseado na ordem
informado na consulta), é preciso informar RIGHT no OUTER JOIN */

SELECT v.id_video, v.nome_video FROM videos AS v LEFT OUTER JOIN videos_canais AS vc ON
v.id_video = vc.fk_video
UNION
SELECT c.id_canal, c.nome_canal FROM videos_canais AS vc RIGHT OUTER JOIN canais AS c ON
vc.fk_canal = c.id_canal
-- UNION une duas querys, as tabelas precisam ter o mesmo número de colunas


-- Aula 1.7

/* Já estava inserido antes
INSERT INTO canais (nome_canal) VALUES (HTML);
INSERT INTO canais (fk_canal, fk_video) VALUES (4, 5)
*/

SELECT * FROM videos_canais JOIN videos ON videos_canais.fk_video = videos.id_video
JOIN canais ON videos_canais.fk_canal = canais.id_canal


-- Aula 1.8

SELECT * FROM videos_canais JOIN videos ON videos_canais.fk_video = videos.id_video
JOIN canais ON videos_canais.fk_canal = canais.id_canal
WHERE canais.id_canal = 2

