CREATE TABLE tb_produtora (
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
)

CREATE TABLE tb_filme (
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	ano INT,
	id_produtora INT FOREIGN KEY REFERENCES tb_produtora(id)
)

INSERT INTO tb_produtora(nome)
VALUES('WARNER BROS'),('SONY'),('MARVEL STUDIOS'),('WALT DISNEY PICTURES')

INSERT INTO tb_filme(nome,ano,id_produtora)
VALUES ('Harry Potter e a Pedra Filosofal', 2001,1),('A Órfã',2009,1),('A Mulher rei',2022,2),('Viúva Negra',2021,3)

select * from tb_filme

select
f.id Id,
f.nome Nome,
f.ano Ano,
p.nome Produtora
from tb_filme f
inner join tb_produtora p on f.id_produtora = p.id
where f.id = 2