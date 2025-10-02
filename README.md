# CODECLAN_OrderManagementAPI
Senior .Net Core Developer Assignment


# Setup instructions
In our project Order Management we have set flow to easy control our code, so i have create folder by each other such as 
 - ApiController
 - ApiReponse
 - DataModel 
 - Dto
 - Helper 
 - Model 
 - Repository 
 - Service

# Use Dependency Injection
 - Microsoft.EntityFrameworkCore
 - Microsoft.EntityFrameworkCore.SqlServer
 - Microsoft.EntityFrameworkCore.Tools
 - Microsoft.AspNetCore.Authentication.JwtBearer

# Architecture explanation
 - ApiController : to control route from client when user request data
 - ApiReponse: to control the response message or status anything back to client
 - DataModel : to control the body that we get from request by client as object Ex (Login, Item, Customer)
 - Dto : to control the data when request success as object to client 
 - Helper : to control the String , Message that we have fix data
 - Model : to control about our Table or Entity in SQL
 - Repository : to control error when user have request invalid data or something wrong
 - Service : to control process between data and database

# Security
 - When a user registers in our system, we encrypt their password to make sure no one can access their data.

# Branch
 - Our data can be used across multiple branches, such as Branch TekTla, Branch DeyTmey, and Branch Steng MeanChey
 
# Progression
 - When we receive a request from the user through the API, we first need to check whether the HTTP method and the API URL match. If the client’s request does not match the allowed method, we return the message "HTTP method not allowed for this endpoint." Otherwise, we proceed to the repository layer to validate the data. If the data is invalid, we send an error message back to the client. If the data is valid, we then proceed to the service layer to handle database operations such as CREATE, DELETE, UPDATE, or LIST.

