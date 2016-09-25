# _HairSalon_

#### _this application mimics a hair salon webpage. 9-24-16_

#### By _**ian Wilcox**_

## Description

_This application mimics a hair salon webpage in that a user can input clients and stylists and see how they are connected. They can check what clients a stylist is scheduled with _


## Setup/Installation Requirements

* _to Creat database and tables manually: _
* _sqlcmd -S "(localdb)\mssqllocaldb"_
* _CREATE DATABASE hair_salon; _
* _GO _
* _USE hair_salon; _
* _GO _
* _CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255)); _
* _CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT); _
* _GO _


## Known Bugs

_yes. soon to be fixed_

## Technologies Used

_HTML, C#, CSS, sql, and Nancy_

### License

*licensed under Mit*

Copyright (c) 2016 **_Ian Wilcox_**
