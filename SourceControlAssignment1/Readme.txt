--------------------------READ ME---------------------

Install Mysql Server Management studio
Add UserDB.bak Database to mysql server

Steps:
	1.Copy UserDb.bak file to given path
		C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup
	
	2.OPEN Microsoft SQL Server Management Studio

	3.Connect to Sql Server:  a)Servertype:Database Engine
				  b)ServerName:localhost
				  c)Authentation:Windows Authentation
					then click on connect
	4.Right click on Database
		-Restore Database
		-Small window will open:Change Source from Database to Device
		-Click on ... Which is on right side of Device
		-Select Backup device window will pop up 
		-click on Add
		-C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup
		-Then Select UserDB.bak file