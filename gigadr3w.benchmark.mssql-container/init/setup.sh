# Arbitrary waiting time to ensure that the SQL istance is running:
sleep 15s

# Execute the init db script
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -d master -i create_database.sql

# Execute the populate db
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -d MyDB -i populate_database.sql