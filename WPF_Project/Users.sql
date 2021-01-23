USE [Course Project]
CREATE TABLE Users (
	id INTEGER  IDENTITY(1,1) PRIMARY KEY, 
	login TEXT NOT NULL,
	password TEXT NOT NULL,
	email TEXT NOT NULL,
)
USE [Course Project]
SELECT * FROM  Users