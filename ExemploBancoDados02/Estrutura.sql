
DROP TABLE herois 
CREATE TABLE herois(
	id INT IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	escuridao BIT NOT NULL,
	nome_pessoa VARCHAR(150) NOT NULL,
	conta_bancaria DECIMAL (17,2) NOT NULL,
	data_nascimento DATE,
	raca VARCHAR (100),
	sexo CHAR(1),
	quantidade_filmes TINYINT NOT NULL,
	descricao TEXT 
);