IF ( SELECT DB_ID('MyDb') ) IS NULL
BEGIN
	CREATE DATABASE MyDb;
END

