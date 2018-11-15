I. File list
------------
globe.cs	 	            Define globe variable
entrance.cs	            Entrance for two types of customers and administrators
custom//custom.cs               Login and Registration for customers
custom//signup.cs                Form for registration
custom//customid.cs            Main frame for this customer to fill up personal information, reserve tickets and select seats
custom//flight_inf.cs             User Control for flight information   
custom//person_inf.cs           User Control for personal information
custom//Myflight.cs              User Control for flight ordered
custom//order.cs                   Form for reserve a ticket 
custom//Selectecoseat.cs       Form for select a economy seat
custom//Selectfirseat.cs         Form for select a first class seat
admin//admin.cs                    Login and Registration for administrators
admin//adminid.cs                 Main frame for this administrator to manage accounts and flights
admin//Flightlist.cs                 User Control for flights management
admin//usermanagement.cs   User Control for users management

II. Design
----------
This project was created using C# .NET and SQL database(Azure), designed in VS2017, to achieve a airline reservation system. Administrator can setup seating capacity, price, airport, time for flights and manage all of accounts. Cusomters can lookup a flight list, choose a flight and select a seat in this flight. 

III. Install
Operator need to change the path in globe.cs to make sure pictures of seat can be loaded successfully. there are six strings in class globals need to be changed.
Defuat customer account (username:x, password:x) administrator account(username:admin, password:123)

IV. Author
Name: Andong Xiao 
Email: andongxi@usc.edu


 
