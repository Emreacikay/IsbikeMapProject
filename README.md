Hi welcome, this is my Isbike Map project. Let me tell you how you can run the application. This project uses a msSql database(ibbDb). So firstly, you need to adjust your database to this project. I will share a .Bak file with you so you can recover the database from that file. But if you are using another database except from msSql you need to adjust your connection string in the appSettings file. In this .Bak file there will be full of bike data so you need to also fullfil them manually if you are using another database.

I am using a local database so my connection string is "server=(LocalDb)\MSSQLLocalDb;Database=ibbDb;trusted_connection=True", if you have a another database name please also modify the connection string and then recover from .bak file.

You also need to set up a multiptle start-up. To do this, right click on the solution and click "set start up projects". Then select api and mvc applications to start together.

What Isbike Map does ?

- It is basically a location based map project that shows isbike(bike rental company) stations on the map to the user. We can say an admin panel type of project but there is a map on the website. You can service only the map with users to see them or you let them edit its up to you. When you edit a data, it will update itself on the map instantly. For example, let's say you changed coordinates of a station then it will automatically pop up in the new coordinates with same infos.

- You can edit the data, add a new station or delete one. To be able to do this operations you must first register then login so a token based auth works and let's the user change data.

API does the auth, token and database operations.

MVC does the request,view and some geolocation operations.

If there is no token you can't do crud operations so you must login. (register first :) )

I will update the code as much as I can. I will add Email Confirm method when registered. I'll also add a Password Reset function. I want to implement best practices to my project so I am still learning. Thank you for your time !.
