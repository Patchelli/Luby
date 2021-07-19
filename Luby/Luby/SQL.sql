-- 2.1 Crie uma query para selecionar todas as pessoas 'tabela_pessoa' e os respectivos eventos 'tabela_evento' o qual elas participam.

    SELECT * FROM tabela_pessoa as tp
    INNER JOIN  tabela_evento as te on te.pessoa_id = tp.id


-- 2.2 Crie uma query para selecionar todas as pessoas 'tabela_pessoa' com sobrenome 'Doe'.

    SELECT * FROM tabela_pessoa as tp
    INNER JOIN  tabela_evento as te on te.pessoa_id = tp.id
    WHERE nome like '% Doe %'

-- 2.3 Crie uma query para adicionar um novo evento 'tabela_evento' e relacionar à pessoa 'Lisa Romero'.

    INSERT INTO tabela_evento  (evento, pessoa_id)
    VALUES ( 'Evento E' , 5) 

-- 2.4 Crie uma query para atualizar 'Evento D' na 'tabela_evento' e relacionar à pessoa 'Joh Doe'

    UPDATE tabela_evento
    SET evento = 'Evento Atualizado' , pessoa_id = 1
    WHERE id = 5

-- 2.5 Crie uma query para remover o 'Evento B' na 'tabela_evento'.

    DELETE FROM tabela_evento 
    WHERE id = 5

-- 2.6 Crie uma query para remover todas as pessoas 'tabela_pessoa' que não possuem eventos 'tabela_evento' relacionados.

    DELETE FROM tabela_pessoa WHERE id not in (select distinct pessoa_id from tabela_evento)

 --2.7 Crie uma query para alterar a tabela 'tabela_pessoa' e adicionar a coluna 'idade' (int)

    ALTER TABLE tabela_pessoa ADD COLUMN idade INT(4) NULL ;

 -- 2.8 Crie uma query para criar uma tabela chamada 'tabela_telefone' que pertence a uma pessoa com seguintes campos:\
   -- id: int (PK)
   --telefone: varchar(200)
   --pessoa_id int(4)

    CREATE TABLE tabela_telefone
   (
        id int NOT NULL,
        telefone varchar(50),
        pessoa_id int(4),
        CONSTRAINT PK_ PRIMARY KEY NONCLUSTERED (id),
        CONSTRAINT FK_ FOREIGN KEY (pessoa_id)
        REFERENCES tabela_pessoa (id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
   )

    -- 2.9 Crie uma query para criar uma índice do tipo único na coluna telefone da 'tabela_telefone'.

    CREATE UNIQUE INDEX uidx_telefone 
    ON tabela_telefone(telefone);


    -- 2.10 Crie uma query para remover a 'tabela_telefone'.

    DROP TABLE tabela_telefone;