# message-forward-service
A Windows Service that watches a SQL DB, pushing updates to a remote REST Api.
### Note:
The Windows Service can be run from Visual Studio as a console application, or it can be installed and started in the traditional manner. 
In order to easily send messages into the database, build the Notifier.UI project in release mode - then run the executable from outside Visual Studio.
