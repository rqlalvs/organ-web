use dbOrgan;
/*https://web.archive.org/web/20130509230922/http://dev.mysql.com/tech-resources/articles/mysql-storedprocedures.pdf*/
DELIMITER $
    
drop procedure if exists spInsertEstoque$
create procedure spInsertEstoque(
in
	Qnt double,
    UnM int
)
begin
	if Qnt < 0 then
		signal sqlstate '45000'
		   set message_text = 'Valor menor que zero!';
	else
      
      insert into tbEstoque(Qtd, UM) values(Qnt, UnM);
    end if;
end$
    
drop procedure if exists spInsertSemente$
create procedure spInsertSemente(
in 
	Qnt double,
    UnM int,
	Nome1 varchar(30),
    `Desc1` varchar(100)
)
begin
	declare conta1 int;
    declare conta2 int;
    declare idE int;
    set conta1 = (select count(*) from tbEstoque); 
        
	call spInsertEstoque(Qnt, UnM);
    
    set conta2 = (select count(*) from tbEstoque); 
      
    if (conta2 = conta1 + 1) then
		set idE = (select Id from tbEstoque order by Id desc limit 1 );
		insert into tbSemente(IdEstoque, Nome, `Desc`) value(IdE, Nome1, `Desc1`);
	end if;
end$

drop procedure if exists spInsertMaquina$
create procedure spInsertMaquina(
in 
	Qnt double,
    UnM int,
    Nome1 varchar(30),
    Tipo1 int,
    Montadora1 varchar(50),
    `Desc1` varchar(100)
)
begin
	declare conta1 int;
    declare conta2 int;
    declare idE int;
    set conta1 = (select count(*) from tbEstoque); 
    
	call spInsertEstoque(Qnt, UnM);
    
    set conta2 = (select count(*) from tbEstoque); 
        
    if (conta2 = conta1 + 1) then
		set idE = (select Id from tbEstoque order by Id desc limit 1 );
		insert into tbMaquina(IdEstoque, Nome, Tipo, Montadora, `Desc`)
						value(IdE, Nome1, Tipo1, Montadora1, `Desc1`);
	end if;
end$

drop procedure if exists spInsertInsumo$
create procedure spInsertInsumo(
in 
	Qnt double,
    UnM int,
    Nome1 varchar(30),
    `Desc1` varchar(100),
    Categoria1 int
)
begin
	declare conta1, conta2, idE int;
    set conta1 = (select count(*) from tbEstoque); 
       
	call spInsertEstoque(Qnt, UnM);

    set conta2 = (select count(*) from tbEstoque); 
        
    if (conta2 = conta1 + 1) then
		set idE = (select Id from tbEstoque order by Id desc limit 1 );
		insert into tbInsumo(IdEstoque, Nome, `Desc`, Categoria) value(IdE, Nome1, `Desc1`, Categoria1);
	end if;
end$

drop procedure if exists spInsertProduto$
create procedure spInsertProduto(
in 
	Qnt double,
    UnM int,
    Nome1 varchar(30),
    `Desc1` varchar(100)
)
begin
    declare conta1, conta2, idE int;
        
    set conta1 = (select count(*) from tbEstoque); 
        
	call spInsertEstoque(Qnt, UnM);

    set conta2 = (select count(*) from tbEstoque); 
        
    if (conta2 = conta1 + 1) then
		set idE = (select Id from tbEstoque order by Id desc limit 1 );
		insert into tbProduto(IdEstoque, Nome, `Desc`) value(IdE, Nome1, `Desc1`);
	end if;
end$

drop procedure if exists spVerQtd$
CREATE PROCEDURE spVerQtd (IN qtd double)
BEGIN
IF qtd < 0 THEN
SIGNAL SQLSTATE '45000'
   SET MESSAGE_TEXT = 'Valor menor que zero!';
END IF;
END$
 
drop procedure if exists spCertQtd$
CREATE PROCEDURE spCertQtd (IN qtd double, IdE int)
BEGIN
declare qtdE double;
set qtdE = (select Qtd from tbEstoque where Id = IdE);

IF qtd > qtdE THEN
SIGNAL SQLSTATE '44001'
   SET MESSAGE_TEXT = 'Quantidade maior do que a presente no estoque';
END IF;
END$
DELIMITER ;



use dbEcommerce;
DELIMITER $
drop function if exists spIsAn$
create function spIsAn(IdU nvarchar(128))
	returns boolean DETERMINISTIC
begin
	declare resp boolean;
	
	if(exists(select * from tbAnunciante where IdUsuario = IdU)) then
	 set resp = true;
	else
	 set resp = false;
	end if;
	return resp;
end$ 

drop function if exists spUsuario$
create function spUsuario(IdU nvarchar(128))
	returns varchar(50) DETERMINISTIC
begin
	declare nome varchar(50);
    
    if(spIsAn(IdU)) then
		set nome = (select NomeFazenda from tbAnunciante where IdUsuario = IdU);
	else
		set nome = (select `UserName` from tbUsuario where Id = IdU);
	end if;
    return nome;
end$
DELIMITER ;
