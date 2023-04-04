-- Use the database
USE LRCH;

GO

-- Insert statement
INSERT INTO PATIENT (PT_FNAME, PT_LNAME, PT_PROVINCE, PT_CITY, PT_STREET, PT_POSTAL_CODE, PT_TEL, PT_SEX, PT_HCN, PT_EXT) 
VALUES 
	('Lionel', 'Messi', 'Ontario', 'Toronto', '142 Marry St', 'K9V4D3', '999-644-5433', 'M', '1234567890', '001'),
	('Neymar', 'Junior', 'Ontario', 'Oakville', '12 Dundas St', 'KD6S6V', '324-537-4325', 'M', '9876543210', '002'),
	('Harry', 'Kane', 'Ontario', 'Oshawa', '45 Robert St', 'KB6Z3F', '643-654-3847', 'M', '8364756345', '003'),
	('John', 'Cena', 'Ontario', 'Whitby', '88 Niagra St', 'L7V6S4', '777-525-7557', 'M', '3748372748', '055'),
    ('Cristiano', 'Ronaldo', 'Ontario', 'Hamilton', '456 Oak St', 'D4E5F6', '554-545-8632', 'M', '2345678901', '066'),
    ('Kylian', 'Mbapp', 'Ontario', 'Brampton', '2468 Maple Ave', 'J1K2L3', '555-555-5555', 'M', '4567890123', '004'),
    ('Mohamed', 'Salah', 'Ontario', 'Barrie', '1357 Cedar Rd', 'M4N5O6', '908-876-5825', 'M', '5678901234', '005'),
    ('Kevin', 'De Bruyne', 'Ontario', 'Mississauga', '369 Pine St', 'P7Q8R9', '755-775-8885', 'M', '6789012345', '016'),
    ('Virgil', 'Van', 'Ontario', 'Waterloo', '2468 Chestnut St', 'S1T2U3', '245-554-2355', 'M', '7890123456', '007'),
    ('Sadio', 'Man', 'Ontario', 'Mississauga', '13579 Oakwood Dr', 'V4W5X6', '644-775-3345', 'M', '8901234567', '008'),
	('Avery', 'Jones', 'Ontario', 'Toronto', '122 Main St', 'M4C1R6', '416-543-9765', 'F', '786554322', '023'),
	('Ethan', 'Wright', 'Ontario', 'Ottawa', '29 Oak St', 'K1Y4Y4', '613-789-5432', 'M', '998767653', '047'),
	('Olivia', 'Nguyen', 'Ontario', 'Mississauga', '98 Glen Abbey Dr', 'L5M5P6', '905-123-4567', 'F', '345623156', '011'),
	('Benjamin', 'Liu', 'Ontario', 'Hamilton', '56 Wellington St', 'L8N2V6', '905-777-8888', 'M', '123456789', '087'),
	('Aria', 'Patel', 'Ontario', 'Markham', '17 Heatherwood Cres', 'L6C2Y6', '905-555-4321', 'F', '287654321', '029'),
	('Jacob', 'Garcia', 'Ontario', 'London', '33 Oxford St', 'N6A5C6', '519-444-5555', 'M', '564738291', '052'),
	('Sofia', 'Baker', 'Ontario', 'Windsor', '44 Riverside Dr', 'N9A5K4', '519-999-8888', 'F', '192837465', '067'),
	('Lucas', 'Chen', 'Ontario', 'Brampton', '71 Main St', 'L6W3L3', '905-111-2222', 'M', '657483920', '035'),
	('Amelia', 'Morris', 'Ontario', 'Oakville', '21 Lakeshore Rd', 'L6J1H6', '905-987-6543', 'F', '123456789', '032'),
	('Ryan', 'Adams', 'Ontario', 'Vaughan', '10 Mill St', 'L4K2Y9', '905-222-3333', 'M', '978654321', '019'),
	('Emily', 'Lee', 'Ontario', 'Richmond Hill', '78 Yonge St', 'L4C3B6', '905-333-4444', 'F', '345621789', '044'),
	('Mason', 'Thompson', 'Ontario', 'Barrie', '12 Simcoe St', 'L4N6C5', '705-555-1212', 'M', '546372819', '059'),
	('Sophia', 'Gupta', 'Ontario', 'Waterloo', '90 University Ave W', 'N2L3C5', '519-111-2222', 'F', '203948576', '028'),
	('William', 'Singh', 'Ontario', 'Kingston', '50 Union St', 'K7L2N8', '613-777-7777', 'M', '465738291', '074'),
	('Victoria', 'Park', 'Ontario', 'North York', '5 Sheppard Ave E', 'M2N5Y7', '416-987-6543', 'F', '534678921', '031'),
	('Tony', 'Stark', 'Ontario', 'Peterborough', '65 Orchard Pard Rd', 'K3X6C7', '864-245-6757', 'M', '3856725458', '006'),
	('Emma', 'Watson', 'Quebec', 'Montreal', '123 Hollywood Blvd', '90210', '310-555-1234', 'F', '785634128', '095'),
	('Ryan', 'Reynolds', 'Ontario', 'London', '456 Sunset Blvd', 'K7V5D2', '415-777-9999', 'M', '456789123', '033'),
	('Jennifer', 'Aniston', 'Ontario', 'Markham', '789 Rodeo Dr', 'J0Y1B2', '310-444-5555', 'F', '654321789', '022'),
	('Leonardo', 'DiCaprio', 'Ontario', 'Vaughan', '321 Pacific Coast Hwy', 'D2D6X5', '310-222-1111', 'M', '987654321', '019');

GO

--Insert Statement
INSERT INTO PHYSICIAN_SPECIALTY (SPECIALTY_DESC)
VALUES ('Orthopedics'),
	   ('Psychiatry');

-- Insert physician patient rows
INSERT INTO PHYSICIAN_PATIENT (PHY_NO, PT_NO)
VALUES (1000, 10000),
	(1000, 10001),
	(1000, 10002),
	(1000, 10003),
	(1000, 10004),
	(1000, 10005),
	(1001, 10006),
	(1001, 10007),
	(1001, 10008),
	(1001, 10009),
	(1001, 10010),
	(1001, 10011),
	(1002, 10012),
	(1002, 10013),
	(1002, 10014),
	(1002, 10015),
	(1002, 10016),
	(1002, 10017),
	(1003, 10018),
	(1003, 10019),
	(1003, 10020),
	(1003, 10021),
	(1003, 10022),
	(1003, 10023);

GO

--Insert Statements
INSERT INTO PHYSICIAN (PHY_FNAME, PHY_LNAME, PHY_TEL, SPECIALTY_ID)
VALUES ('James', 'Portsmith', '667-6443-657', 1),
	('Seth', 'Westbery', '767-6443-658', 1),
	('Ethan', 'Piggot', '867-6443-659', 1),
	('Matthew', 'Bryan', '967-6443-650', 1),
	('Lee', 'Anderson', '067-6443-651', 1),
	('Jimmy', 'Rollins', '167-6443-652', 1);

GO

-- Insert statement
INSERT INTO APPOINTMENT (APT_DATE, PT_NO, PHY_NO)
VALUES ('2023-01-23', 10000, 1000),
('2023-01-21', 10001, 1001),
('2023-02-1', 10002, 1002),
('2023-02-12', 10003, 1003),
('2023-03-09', 10004, 1004);

GO

--Insert Satements
INSERT INTO TREATMENT (TRMT_NOTE, APT_ID)
VALUES ('note 1', 2),
	('note 2', 3),
	('note 3', 4),
	('note 4', 5);

GO

--Insert Statements
INSERT INTO ROOM_TYPE (RM_TYPE_ID, RM_TYPE_DESC)
VALUES ('PR', 'Private'),
	('SP', 'Semi-private'),
	('IC', 'Intensive Care'),
	('W3', 'Ward, 3'),
	('W4', 'Ward, 4');

GO

--Insert statements
INSERT INTO ROOM (RM_NO, RM_TYPE_ID)
VALUES (101, 'PR'), -- 1 bed; (1/1) Occupied
	(102, 'PR'), -- 1 bed	  (0/1) Unoccupied
	(103, 'SP'), -- 2 beds	  (2/2) Occupied
	(104, 'SP'), -- 2 beds	  (0/2) Unccupied
	(105, 'IC'), -- 1 bed	  (0/1) Unoccupied
	(106, 'W3'), -- 3 beds	  (2/3) Occupied
	(107, 'W4'); -- 4 bed     (4/4) Unoccupied
GO

--Insert Statements
INSERT INTO BED (RM_NO, BED_LETTER)
VALUES (101, 'A'),
	(102, 'A'),
	(103, 'A'),
	(103, 'B'),
	(104, 'A'),
	(104, 'B'),
	(105, 'A'),
	(106, 'A'),
	(106, 'B'),
	(106, 'C'),
	(107, 'A'),
	(107, 'B'),
	(107, 'C'),
	(107, 'D');
GO

--Insert Statements
INSERT INTO PATIENT_STAY (PT_ADMITTED_DATE, PT_DISCHARGE_DATE, PT_NO, RM_NO, BED_LETTER)
VALUES ('2023-01-21', '2023-02-10', 10000, 101, 'A'),
	('2023-01-12', '2023-03-12', 10001, 103, 'A'),
	('2023-01-03', '2023-02-04', 10002, 103, 'B'),
	('2023-01-13', '2023-03-17', 10003, 106, 'A'),
	('2023-01-22', '2023-02-21', 10004, 106, 'B'),
	('2023-02-17', '2023-03-15', 10005, 107, 'A'),
	('2023-02-18', '2023-03-16', 10006, 107, 'B'),
	('2023-02-19', '2023-03-17', 10007, 107, 'C'),
	('2023-02-20', '2023-03-18', 10008, 107, 'D');

GO

--Insert Statements
INSERT INTO FIN_STATUS (FIN_STATUS_DESC)
VALUES ('Paid'),
	('Overdue'),
	('Pending'),
	('Declined'),
	('Partially paid'),
	('Refunded');

GO

--Insert Statements
INSERT INTO PATIENT_FIN_STATUS (PT_NO, FIN_STATUS_ID)
VALUES (10001, 1),
       (10000, 2),
       (10003, 3),
       (10005, 4),
       (10004, 5);

GO

--Insert Statements
INSERT INTO FIN_SOURCE (FIN_SRC_DESC)
VALUES ('Private donation'),
	('Fundraising event'),
	('Private donation'),
	('Insurance'),
	('Patient payment'),
	('Investments'),
	('Government subsidy');

GO

-- Insert statement
INSERT INTO PATIENT_FIN_SOURCE (PT_NO, FIN_SRC_ID)
VALUES (10001, 1),
	(10002, 2),
	(10003, 3),
	(10004, 4),
	(10005, 4),
	(10006, 1);

GO

--Insert Statements
INSERT INTO COST_CENTER (COST_CENTER_NAME) 
VALUES ('Laboratory'),
	('Room & Board'), 
	('Entertainment'), 
	('Pharmacy'), 
	('Radiology');

GO

-- Insert statement
INSERT INTO ITEM_PRICE (ITEM_PRICE)
VALUES ($200.00),
	($5.00),
	($25.00),
	($250.00),
	($30.00);

GO

-- Insert statement
INSERT INTO ITEM (ITEM_DESC, ITEM_PRICE_ID, COST_CENTER_ID)
VALUES ('Television', 1, 100),
	('Glucose', 2, 101),
	('Semi-Private Room', 1, 102),
	('Private Room', 3, 103),
	('Chest X-Ray', 4, 104);

GO

-- Insert statement
INSERT INTO FIN_TRANSACTION (TRANS_DATE, PT_FIN_SRC_ID, ITEM_ID)
VALUES ('2022-10-09', 1, 1000),
	('2022-02-13', 2, 1001),
	('2023-03-08', 3, 1002),
	('2023-03-20', 4, 1003),
	('2023-01-31', 5, 1004);

GO

-- Insert statement
INSERT INTO INVOICE (INV_DATE, TRANS_ID)
VALUES ('2023-03-21', 2),
	('2023-02-01', 3),
	('2023-03-09', 4),
	('2022-02-14', 5),
	('2022-10-10', 1);
GO
