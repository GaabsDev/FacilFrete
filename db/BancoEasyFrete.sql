CREATE TABLE EasyFrete.Empresa
(
	Id int IDENTITY NOT NULL PRIMARY KEY,
	Nome varchar(80) NOT NULL UNIQUE,
	Email varchar(80) NOT NULL,
	NomeResponsavel varchar(80),
	TelefoneResponsavel varchar(80),
	Ativo bit NOT NULL DEFAULT 1
)

CREATE TABLE EasyFrete.Usuario
( 
  Id int IDENTITY NOT NULL PRIMARY KEY,
  IdEmpresa int NOT NULL,
  UserName varchar(80) NOT NULL unique,
  Email varchar(80) NOT NULL unique,
  Senha varchar(80) NOT NULL,
  Ativo bit NOT NULL DEFAULT 1,
  CONSTRAINT Fk_EMPRESA_USUARIO FOREIGN KEY (IdEmpresa) REFERENCES EasyFrete.Empresa(Id)
)

CREATE TABLE EasyFrete.CentroDistribuicao
(
	Id int IDENTITY NOT NULL PRIMARY KEY,
	IdEmpresa int NOT NULL,
	Descricao varchar(80),
	Codigo varchar(80),
	Latitude DECIMAL(20, 10),
	Longitude DECIMAL(20, 10),
	Ativo bit NOT NULL DEFAULT 1,
	CONSTRAINT Fk_EMPRESA_CENTRO_DISTRIBUICAO FOREIGN KEY (IdEmpresa) REFERENCES EasyFrete.Empresa(Id)
)

CREATE TABLE EasyFrete.Cep
(
  Id int IDENTITY NOT NULL PRIMARY KEY,
  Cep numeric(8) UNIQUE,
  Logradouro varchar(120) NOT NULL,
  Bairro varchar(120),
  Cidade varchar(120),
  UF char(2),
  DataInclusao datetime NOT NULL DEFAULT GetDate(),
  Ativo bit NOT NULL DEFAULT 1
)


CREATE TABLE EasyFrete.RaioPreco
(
	Id int IDENTITY NOT NULL PRIMARY KEY,
	IdCentroDistribuicao int NOT NULL,
	Latitude DECIMAL(20, 10) NOT NULL,
	Longitude DECIMAL(20, 10) NOT NULL,
	Raio DECIMAL(20, 10) NOT NULL,
	Preco DECIMAL(20, 10) NOT NULL,
	Ativo bit NOT NULL DEFAULT 1,
	CONSTRAINT Fk_CENTRO_DISTRIBUICAO_RAIO_PRECO FOREIGN KEY (IdCentroDistribuicao) REFERENCES EasyFrete.CentroDistribuicao(Id)
)