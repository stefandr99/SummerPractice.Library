sqllocaldb stop "MSSQLLocalDB"
sqllocaldb delete "MSSQLLocalDB"

sqllocaldb create "MSSQLLocalDB"
sqllocaldb start "MSSQLLocalDB"

sqlcmd -S "(localdb)\MSSQLLocalDB" -Q "CREATE DATABASE LibraryDb;"