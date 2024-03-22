CREATE TABLE Evento(
eventoID INT PRIMARY KEY IDENTITY(1,1),
nomeEvento VARCHAR(250) NOT NULL,
descrizioneEvento TEXT,
dataEvento DATETIME NOT NULL,	
luogoEvento VARCHAR(250) NOT NULL,
capacitaMassima INT NOT NULL CHECK (capacitaMassima >= 0),
deleted DATETIME
);
 
CREATE TABLE Partecipante (
partecipanteID INT PRIMARY KEY IDENTITY(1,1),
nominativo VARCHAR(250) NOT NULL,
telefono VARCHAR(30) NOT NULL,
email VARCHAR(250),
deleted DATETIME
);
 
CREATE TABLE Risorse(
risorseID INT PRIMARY KEY IDENTITY(1,1),
quantita INT NOT NULL CHECK(quantita >= 0),
costo DECIMAL(5,2) NOT NULL CHECK (costo >= 0),
fornitore VARCHAR(250) NOT NULL,
tipo VARCHAR(250) NOT NULL CHECK(tipo IN ('cibo', 'bevanda','attrezzatura')),
deleted DATETIME,
eventoRIF INT NOT NULL,
FOREIGN KEY (eventoRIF) REFERENCES evento(eventoID)
);
 
CREATE TABLE Evento_Partecipante(
eventoRIF INT NOT NULL,
partecipanteRIF INT NOT NULL,
FOREIGN KEY (eventoRIF) REFERENCES Evento(eventoID),
FOREIGN KEY (partecipanteRIF) REFERENCES Partecipante(partecipanteID),
PRIMARY KEY (eventoRIF,partecipanteRIF),
);

INSERT INTO Evento (nomeEvento, descrizioneEvento, dataEvento, luogoEvento, capacitaMassima) VALUES 
('Concerto Rock', 'Un fantastico concerto di musica rock', '2023-12-02', 'Teatro della città', 500),
('Fiera del Libro', NULL, '2024-06-05', 'Centro Fieristico', 1000),
('Sfilata di moda', 'La sfilata presenterà le ultime tendenze della moda', '2024-04-03', 'Piazza principale', 300),
('Corso di Cucina', NULL, '2024-08-10', 'Scuola di Cucina Gourmet', 20),
('Conferenza Tecnologica', 'Una conferenza sulle ultime innovazioni tecnologiche', '2024-05-02', 'Centro Congressi', 200);	
 
INSERT INTO Partecipante (nominativo, telefono, email) VALUES 
('Mario Rossi', '1234567890', 'mario@example.com'),
('Paolo Bianchi', '9876543210', NULL),
('Anna Verdi', '5551234567', 'anna@example.com'),
('Giovanni Neri', '3334445555', NULL),
('Laura Gialli', '6667778888', 'laura@example.com');
 
INSERT INTO Risorse (quantita, costo, fornitore, tipo, eventoRIF) VALUES 
(100, 500, 'Fornitore A', 'cibo', 1),
(50, 300, 'Fornitore B', 'bevanda', 2),
(20, 100, 'Fornitore C', 'attrezzatura', 3),
(200, 800, 'Fornitore D', 'cibo', 4),
(150, 600, 'Fornitore E', 'bevanda', 5),
(80, 400, 'Fornitore F', 'attrezzatura', 1),
(120, 700, 'Fornitore G', 'cibo', 2),
(30, 200, 'Fornitore H', 'bevanda', 3),
(15, 150, 'Fornitore I', 'attrezzatura', 4),
(180, 900, 'Fornitore J', 'cibo', 5);
 
INSERT INTO Evento_Partecipante (eventoRIF, partecipanteRIF) VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4 ),
(5, 5),
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(5, 1);
