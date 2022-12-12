CREATE DATABASE ApiVendas;

CREATE TABLE Produto(
CodProduto int PRIMARY KEY IDENTITY(1,1),
Estoque int,
Nome varchar (250),
Valor decimal,
);


CREATE TABLE PedidoItem(
CodPedidoItem int PRIMARY KEY IDENTITY(1,1),
Quantidade int,
CodPedido int,
CodProduto int
); 

ALTER TABLE PedidoItem
ADD
CONSTRAINT fk_CodProduto FOREIGN KEY (CodProduto) REFERENCES Produto (CodProduto),
CONSTRAINT fk_CodPPedido FOREIGN KEY (CodPedido) REFERENCES Pedido (CodPedido);


CREATE TABLE Pedido(
CodPedido int PRIMARY KEY IDENTITY(1,1),
DtPedido dateTime,
CodCLiente int,
CodItem int);

ALTER TABLE Pedido
ADD
CONSTRAINT fk_CodCLiente FOREIGN KEY (CodCLiente) REFERENCES Cliente (CodCLiente),
CONSTRAINT fk_CodItem FOREIGN KEY (CodItem) REFERENCES PedidoItem (CodPedidoItem);


CREATE TABLE Cliente(
CodCliente int PRIMARY KEY IDENTITY(1,1),
Pedido int,
Nome varchar(250),
Email varchar (250),
DtNascimento datetime,
);
ALTER TABLE Cliente
ADD
CONSTRAINT fk_Pedido FOREIGN KEY (Pedido) REFERENCES Pedido (CodPedido)


--INSERTS PRODUTO--
INSERT INTO Produto (Estoque, Valor, Nome )
VALUES (5, 5, 'arroz');
INSERT INTO Produto (Estoque, Valor, Nome )
VALUES (5, 5, 'feijão');
INSERT INTO Produto (Estoque, Valor, Nome )
VALUES (9, 30.7, 'carne');
INSERT INTO Produto (Estoque, Valor, Nome )
VALUES (8, 9, 'massa');

select * from Produto

SELECT CodProduto, Nome, Valor, Estoque FROM Produto WHERE CodProduto = 1

--INSERT PRODUTO ITEM--

insert into PedidoItem (Quantidade, CodPedido, CodProduto)
values (2,1,1)

select * from pedido
select * from pedidoitem

insert into Pedido (DtPedido,CodCLiente, CodItem)
values ('30-11-2022',1,1)

insert into Cliente (Nome,Email,DtNascimento,Pedido)
values ('Matheus', 'matheus@gmail.com','24-11-1997',1)

select * from cliente

select * from Pedido

select Produto.Nome, Produto.Valor, PedidoItem.Quantidade from Produto
inner join PedidoItem
on Produto.CodProduto = PedidoItem.CodProduto


