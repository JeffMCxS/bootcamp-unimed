-- Aula 1.3 - 1.4

CREATE TABLE pessoas (
    id INT NOT NULL PRIMARY KEY AUTOINCREMENT,
    nome VARCHAR(30) NOT NULL,
    nascimento DATE
)

INSERT INTO pessoas (nome, nascimento) VALUES ('Nathally', '1990-05-22')


-- Aula 2.1
-- SELECT (read)
SELECT * FROM pessoa
SELECT nome FROM pessoa
SELECT nome, nascimento FROM pessoa

-- UPDATE
UPDATE pessoa SET nome='Nathally Souza' -- Alterou todos os nomes
UPDATE pessoa SET nome='Nathally Souza' WHERE id=1 -- Alterou somente onde havia o id 1


-- Aula 2.2
-- DELETE

-- Boas práticas de segurança
/* Dê um SELECT e verifique se o valor está correto, e em caso afirmativo, ao invés de
digitar o comando novamente, apenas altere o SELECT para DELETE para evitar erros de
digitação */

SELECT * FROM pessoa WHERE id=1
/*SELECT*/ DELETE * FROM pessoa WHERE id=1


-- ORDER BY
SELECT * FROM pessoa ORDER BY nome
SELECT * FROM pessoa ORDER BY nome DESC -- Decrescente


-- Aula 2.3
-- ALTER TABLE
ALTER TABLE `pessoa` ADD `genero` VARCHAR(1) NOT NULL AFTER `nascimento`
UPDATE pessoa SET genero='F' WHERE id=1

-- COUNT, GROUP BY
SELECT COUNT(id), genero FROM pessoa GROUP BY genero
    /* Será contado quantas pessoas tem em cada genero, quantos IDs únicos em cada grupo
    de generos. GROUP BY cria duas tabelas, uma para cada genero */

SELECT COUNT(genero), genero FROM pessoa GROUP BY genero
    /* Assim seria contado quantos generos existem...
