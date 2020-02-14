USE M_MeuPonto

INSERT INTO Usuarios(Ni,Nome,Email,Senha,CPF,Tipo)
	VALUES
			(00000000 ,'Admin' , 'MeuPonto@email.com' , '12345678',00000000000,'ADMINISTRADOR')
		 
INSERT INTO Pontos(IdUsuario, DataHorario, Tipo)
	VALUES
			(1, '2020-02-12 08:00:00', 'Entrada')

alter table Pontos add Imagem varchar(200);

update Pontos set Imagem = 'https://www.topdata.com.br/media/comprovante-de-ponto-do-trabalhador.jpg' where IdPonto = 1