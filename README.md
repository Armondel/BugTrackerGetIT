# BugTrackerGetIT

## System requirements

MSSql local database

## Installing

Clone this repository or just load zip archive.
Open with Visual Studio.
On first launch it might take some extra time to run, due to database initialization (creating datatables and so on)

## Usage

You can start work with app :

1) Create user (you can use fake email for sure)
2) Go to "net bug"
3) Fill required fields(there jquery validation for that on client side ;) )
4) after creating go to "bug tracker" and find your issue

## Specification

1. Create system using ASP.NET Core 2.0 MVC	**guess done**
2. System functionality:						
* Enter data in DB							**done**
* Save data in DB							**done**
* It is possible to check error list		**done**
* Authentification							**done**
* No anonimous access						**done**
* Fixed error lifecycle						**done**
* Fullfilin given DB models					**done**

3. UI functionality:
* Authentification							**done**
3.1 Wokring with bugs/errors:					
* Creating									**done**
* Editing									**partly**
* Bug history in separate table			**done**
* Buttons for status changing				**done**
* Required comment on status change		**done**

3.2 Bug/Error List:
* Sorting									**done**
* Links to detailed bug/error view			**done**

4. User:
* Editing user information					**default**

5. Each Page:
* New bug link								**done**
* Bug table link							**done**
* New user link								**partly**
* List of users link						**done**
* Logout									**done**


## Browser compatability

Chrome:	**success**
IE 11:	**success**


