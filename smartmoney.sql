CREATE DATABASE smartmoney;
USE smartmoney;

CREATE TABLE Users(
	UserId INT PRIMARY KEY IDENTITY(1,1),
	_Name VARCHAR(32),
	_Surname VARCHAR(32),
	Telephone VARCHAR(20),
	_Password VARCHAR(32),
	Balance INT,
	StockBuy INT,
	StocksBuyCount INT,
	countReplenish INT,
	countWithdraw INT,
	_Admin INT
);

INSERT INTO Users(_Name, _Surname, Telephone, _Password, Balance, StockBuy, StocksBuyCount, countReplenish, countWithdraw, _Admin) VALUES
('���������', '�������', '+76177135143', 'qwerty123', 525, 1, 33, 4215, 0, 1),
('�������', '������', '+74178362754', '123456Tv', 313, 0, 16, 0, 0, 0);

CREATE TABLE Stocks(
	StockId INT PRIMARY KEY IDENTITY(1,1),
	_Name VARCHAR (92),
	OldPrice INT,
	Price INT,
	Company VARCHAR(56),
	Buyers INT
);

INSERT INTO Stocks(_Name, OldPrice, Price, Company, Buyers) VALUES
('�������.�����', 315, 317, '�������', 13),
('������.��������', 439, 442, '������', 11),
('���.���������', 563, 561, '���', 5),
('��������.����������', 471, 475, '��������', 17),
('VK ������', 636, 631, '���������', 9),
('���.����������', 517, 521, '���', 5);

CREATE TABLE StockBuy(
	UserId INT,
	StockId INT,
	StockName VARCHAR(92)
);

CREATE TABLE Withdraw(
	WithdrawId INT PRIMARY KEY IDENTITY(1,1),
	UserId INT,
	CardNumber VARCHAR(15),
	Summ INT,
	_Status VARCHAR(16)
);

SELECT * FROM Users;
SELECT * FROM Stocks;
SELECT * FROM StockBuy;
SELECT * FROM Withdraw;

