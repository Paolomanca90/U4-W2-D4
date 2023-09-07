--CREATE TABLE IMPIEGO (
--    IdImpiego INT PRIMARY KEY IDENTITY,
--    TipoImpiego NVARCHAR(20)
--)

--CREATE TABLE IMPIEGATO (
--    IdImpiegato INT PRIMARY KEY IDENTITY,
--    Cognome NVARCHAR(20),
--    Nome NVARCHAR(20),
--    CodiceFiscale NVARCHAR(20),
--    Eta INT,
--    Reddito MONEY,
--    DetrazioneFiscale BIT,
--	IdImpiego INT,
--	CONSTRAINT FK_IMPIEGATO_IMPIEGO FOREIGN KEY (IdImpiego) REFERENCES IMPIEGO(IdImpiego)
--)

--INSERT INTO IMPIEGO (TipoImpiego)
--VALUES
--	('Manager'),
--	('Dirigente'),
--	('Operaio'),
--	('Operaio senior')

--INSERT INTO IMPIEGATO (Cognome, Nome, CodiceFiscale, Eta, Reddito, DetrazioneFiscale, IdImpiego)
--VALUES
--    ('Rossi', 'Mario', 'MRR11123', 30, 1000, 1, 1),
--    ('Rossi', 'Luigi', 'LGR33345', 32, 900, 0, 3),
--    ('Cifarelli', 'Giuseppe', 'GPC99934', 26, 2000, 1, 2),
--    ('Baglio', 'Aldo', 'LDB23456', 65, 1100, 0, 3),
--	('Poretti', 'Giacomo', 'GCP89892', 67, 1100, 0, 3),
--	('Storti', 'Giovanni', 'GNS45234', 66, 1100, 0, 3),
--	('Brazorf', 'Ajeje', 'JJB56243', 32, 500, 1, 2),
--	('Puccio', 'Marco', 'MCP', 37, 3000, 0, 2),
--	('Manca', 'Paolo', 'PLM17890', 33, 1500, 1, 4),
--	('Casasola', 'Stefano', 'STC39393', 36, 3000, 0, 2),
--	('Tedesco', 'Michele', 'MCT99999', 35, 2500, 0, 4),
--	('Kovac', 'Lidia', 'LDK11111', 25, 1000, 0, 3),
--	('Potenza', 'Simone', 'SMP23232', 26, 1800, 1, 2),
--	('Baudo', 'Pippo', 'PPB54545', 90, 6000, 0, 1),
--	('Bongiorno', 'Mike', 'MKB45453', 99, 6000, 1, 1),
--	('Spencer', 'Bud', 'BDS87654', 86, 5000, 0, 2),
--	('Hill', 'Terence', 'TRH12345', 88, 3800, 0, 4),
--	('Greggio', 'Ezio', 'ZGR76543', 65, 1100, 1, 3),
--	('Iacchetti', 'Enzo', 'NZC23412', 53, 1000, 1, 3),
--	('Hogan', 'Hulk', 'HLH89123', 34, 800, 1, 3)


SELECT * FROM IMPIEGATO WHERE ETA > 29

SELECT * FROM IMPIEGATO WHERE REDDITO > 800

SELECT * FROM IMPIEGATO WHERE DETRAZIONEFISCALE = 1

SELECT * FROM IMPIEGATO WHERE DETRAZIONEFISCALE = 0

SELECT * FROM IMPIEGATO WHERE COGNOME LIKE 'G%' ORDER BY COGNOME

SELECT COUNT(*) AS NUMEROIMPIEGATI FROM IMPIEGATO

SELECT SUM(REDDITO) AS REDDITOTOTALE FROM IMPIEGATO

SELECT AVG(REDDITO) AS MEDIAREDDITO FROM IMPIEGATO 

SELECT MAX(REDDITO) AS REDDITOMAGGIORE FROM IMPIEGATO

SELECT MIN(REDDITO) AS REDDITOMAGGIORE FROM IMPIEGATO

SELECT AVG(ETA) AS ETAMEDIA FROM IMPIEGATO

