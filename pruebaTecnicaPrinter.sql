create DATABASE pruebaTecnicaPrinter;
use pruebaTecnicaPrinter;

CREATE TABLE Cliente (
    ClienteId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Orden (
    OrdenId INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL,
    Total DECIMAL(18, 2) NOT NULL,
    ClienteId INT NOT NULL,
    CONSTRAINT FK_Orden_Cliente FOREIGN KEY (ClienteId) REFERENCES Cliente(ClienteId) 
);

INSERT INTO Cliente (Nombre) VALUES ('Ruben Hernández');
INSERT INTO Cliente (Nombre) VALUES ('Katy Aragón');

INSERT INTO Orden (Fecha, Total, ClienteId) VALUES (GETDATE(), 100.50, 1);
INSERT INTO Orden (Fecha, Total, ClienteId) VALUES (GETDATE(), 250.75, 1);

SELECT SUM(Total) AS TotalOrdenes FROM Orden
WHERE ClienteId = 1;