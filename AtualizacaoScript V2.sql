CREATE TABLE Drone (
  Id [uniqueidentifier]  NOT NULL,
  Capacidade INT NOT NULL,
  Velocidade INT NOT NULL,
  Autonomia INT NOT NULL,
  Carga INT NOT NULL,
  Status VARCHAR(25) NULL,
  DataAtualizacao DATETIME NULL,
  PRIMARY KEY(Id)
);

CREATE TABLE Cliente (
  ID INT NOT NULL IDENTITY,
  Nome VARCHAR(255) NULL,
  Endereco VARCHAR(255) NULL,
  Latitude float NULL,
  Longitude float NULL,
  PRIMARY KEY(ID)
);

CREATE TABLE Pedido (
  Id [uniqueidentifier]  NOT NULL,
  Cliente_ID INT NOT NULL,
  Peso INT NULL,
  DataHora DATETIME NULL,
  Status VARCHAR(25) NULL,
  PRIMARY KEY(Id)
 ,
  FOREIGN KEY(Cliente_ID)
    REFERENCES Cliente(ID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE INDEX Pedido_FKIndex1 ON Pedido(Cliente_ID);

CREATE TABLE DronePedido (
  Drone_Id [uniqueidentifier] NOT NULL,
  Pedido_Id [uniqueidentifier] NOT NULL,
  PRIMARY KEY(Drone_Id, Pedido_Id)
 ,
  FOREIGN KEY(Drone_Id)
    REFERENCES Drone(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Pedido_Id)
    REFERENCES Pedido(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE INDEX Drone_has_Pedido_FKIndex1 ON DronePedido(Drone_Id);
CREATE INDEX Drone_has_Pedido_FKIndex2 ON DronePedido(Pedido_Id);

--/* INSERIR DADOS */
insert into [Drone]
values(NEWID(),5, 20, 35, 5, 'EmTransito', getdate())
insert into [Drone]
values(NEWID(),5, 20, 35, 5, 'Pronto', getdate())
insert into [Drone]
values(NEWID(),5, 20, 35, 5, 'Carregando', getdate())