# Employee_Management_System

Project Title:  Employee Management System

Overview:    Employee management system is an web application that enables users to create and store various employee details. This app is helpful to department of organization which maintains data of employees related to an organization.
You need to create web application using below technologies
1.	Front-end : - Angular 14
2.	Back-end:- ASP.Net Core Web API 6.0
3.	Database:  MS SQL Server
•	To develop back-end solution, you need to create RESTful Web API.
•	To access data from database (MS-SQL) you must have to use EF Core, you can use any one of the following approach
o	 Database First
o	Code first.
 
Create a new database named “EMS”, While designing Database use below structure

1)	Employee
•	Id (P.K.)
•	FirstName (Required)
•	LastName (Required)
•	Email (Required)
•	DateOfBirth (Required)
•	Age (Required)
•	JoinedDate
•	IsActive
•	DepartmentId (F.K)

2)	Department
a.	Id (P.K.)
b.	Name (Required)
c.	IsActive

•	Create a store procedure to insert record into Department table.  Using this S.P. please insert at least 5 records.

Constraints of Model Classes
•	should use appropriate data-type and length while designing above data structure.
•	JoinedDate field (column) should not appear in UI. 
o	User will not get option to enter data. 
o	But While adding new Record, you need to assign current Date to it.

•	The Default value for the IsActive field should be true.

•	Max length for any text field must be 100 characters.


 
Functional Requirement and General Design Constraint

ASP.Net Core Web API: 
o	EmployeesController
	Actions : 
•	Get:  Fetch all active employee details
E.g:- /api/v1/Employees/
•	Get:  Fetch specific employee details (irrespective of status of IsActive field)
o	E.g:- /api/v1/Employees/1

•	Post:  Create new Employee
o	/api/v1/Employees/Post
•	Put: update the employee
o	api/v1/Employee/Put

o	DepartmentController
	Actions: 

•	Get:  Fetch information of all department
o	/api/v1/ departments /
•	Get:  fetch detail of specific department
o	Ex:- /api/v1/ departments /1
•	Get: fetch all the employee details by department id
o	Ex:- /api/v1/ departments /1/Employees
•	Delete: 
o	If IsActive =0 delete the department
o	If IsActive =1 and there is no employee in that department then only delete the department
 
Angular:

•	Design appropriate UI (View, Update, List and Add) based on above Action. 
•	Following UI should be there
o	Employee UI:   
1.	View (of specific employee)
2.	Create New Employee
•	Calculate age based on DateofBirth field
•	Apply proper validations
•	Require fields are firstname, lastname, email, dateofbirthd and department
3.	Update existing employee
4.	List all the employee details by department id
o	Department UI
5.	List (only active employee)
	Delete department
•	It should display proper response message.
•	If department is not deleted, display message with reason

•	Develop Service  for calling appropriate REST API.
•	While deleting a record, delete confirmation popup should display.
•	Value of Age field must be calculated after entering DateofBirth.
•	In List UI, only display active Department and Employee records.
•	Any employee age must be between 18 to 58.
•	Display proper error message for all required field if user try to submit empty UI besides specific control
1.	Empty Message:   ‘Field or property Name’ can’t be blank.
2.	Min Length Message:  for first and last name length should be 3, if less than this then display message :  ‘first/last Name’ length can not  be less than 3.
3.	Max Length Message:   for first and Last name length should not be greater 100, if greater then this display message: ‘first/last name’ length should not be greater than 100.
	Email Message:  in case of wrong e-mail format, display message: ‘email address’ is not proper format. Please correct it.

General Guidelines

1.	Code should have Error Handling mechanism whenever interact with database.
2.	Solution must be  Testable via any Http Client (Swagger, Fiddler or Postman) apart from Angular.
3.	Only use below two Naming standard whenever applicable while creating class, controller, method to name but a few
1.	camelCase
2.	Pascal cases
4.	RESTful API Guidelines
a.	Response of each method should return appropriate HTTP Status Code. (200,201,204,400,404,406,500)
b.	All the method only access via proper HTTP methods (verb- Get, Post, Put, Delete)
