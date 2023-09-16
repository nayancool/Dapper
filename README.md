# Dapper - King of Micro ORM

## Agenda
1. What is Dapper?
2. How Dapper Works?
3. Methods of Dapper.
4. Why use Dapper?
5. Disadvantages
6. Demo steps
7. Refrences

## 1. What is Dapper?
a. Dapper is a micro ORM(object relationship mapping) for the .NET world. Now what is Micro ORM? It is a very lightweight object relational mapping tool. It should convert the output of SQL calls into objects in your server side language.

b. Dapper is architected to focus on working with database table instead of creating, modyfying the database schema, tracking changes etc.

## 2. How Dapper Works?

```
Step 1
    Create an IDBConnection object with Connection String.

	Step 2
		Write a query and store it in a normal string variable.

	Step 3
		Call db.execute() and pass the query and it's done.
```

## 3. Methods of Dapper

| Methods | Explanations                                                                                                                      |
| ------- | --------------------------------------------------------------------------------------------------------------------------------- |
| Execute | Execute is a method which can execute command one or multiple times and return the number of affected rows in the database table. |
| QueryFirstOrDefault | It can execute the query and map the first result or a default value if sequence contains no element.                                                   |
| QueryFirst          | QueryFirst is a method which can execute a query and map the first result.                                                                              |
| ExecuteReader       | It execute a command and return a reader.                                                                                                               |
| QueryMultiple       | It can execute multiple queries within same command and map result.                                                                                     |
| Query               | It can execute the query and map the result.                                                                                                            |
| QuerySingle         | QuerySingle is a method which can execute a query and map the first result and throws an exception if there is not exactly one element in the sequence. |            


  ## 4. Why use Dapper.
* Perform CRUD operations directly using the IDBConnection object.
* Provide querying static and dynamic data over the database.
* Get generic results for simple or complex data types.
* Dapper allows storing bulk data at once.
* 
  ![image](https://github.com/nayancool/Dapper/assets/64027222/ee5154a1-e3fd-4abe-9e68-c9876f08ef1d)




## 5. Disadvantages

*  Dapper can't genetate class model for you.
*  Dapper can't generates queries for you.
*  It cannot track object and their changes.

  ## 6. Demo steps

### Database design

  1. Create a database named ProductManagementDB.
  2. Create a table named Product with columns like Id(int), Name(varchar(25)), Barcode(varchar(20), Description(varchar(50)), Rate(decimal(13,2)), AddedOn(datetime), ModifiedOn(datetime).
``` SQL
Create Database ProductManagementDB
Use ProductManagementDB

CREATE TABLE Product (
    Id INT PRIMARY KEY,
    Name VARCHAR(25),
    Barcode VARCHAR(20),
    Description VARCHAR(50),
    Rate DECIMAL(13, 2),
    AddedOn DATETIME,
    ModifiedOn DATETIME
);
```

### Getting started with ASP.NET Core WebApi Project.
1. we will build a real time simple webApi that perform CRUD Operation using Dapper and Repository Pattern.
2. Architecture that we will follow
   * Core and Application - All the interfaces and domain models live here.
   * Infrastructure - Dapper will present here along with implementaion of repository and other interfaces.
   * WebApi - API controllers to access the repositories.

<img width="240" alt="image" src="https://github.com/nayancool/Dapper/assets/64027222/57a3df2c-b412-4c60-9997-7a2ce7b6d755">


 * In Dapper.Core class library will create folder named Entities and add class named Product then will add all columns name in class product.
 * In Dapper.Application class library will create folder named interfaces and add Interface name IGenericRepository, IProductRepository, IUnitOfWork.
 * In Dapper.Infrastrucure class library will create a folder named Repositories. **add NuGet package named Dapper in Dapper.Infrastrucure**
 * In Dapper.WebApi add controller name ProductController.

  
