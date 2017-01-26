# Widgets.API
A very basic WEBAPI2 application demonstrating the use of Repository and Factory patterns

##Repository and Factory Design Patterns
Using ASP.NET 4

These are my notes in regards to using the Repository and Factory design patterns in an ASP.NET MVC / Web-API application.

###Definitions
Repository = A repository is used to separate the concerns between the domain logic and data layer of an application. It helps the domain layer to be decoupled from the data layer. 

Factory = A factory’s man purpose is to create instances of objects. In the case of a web application using Web-API / MVC, the factory is often used to create instances of the view model objects or data model objects.

###Usage
In modern MVC and Web-API applications, a repository and / or factory pattern are often used to provide a separation of concern as well as aid the developer in code reuse. The repository pattern allows business logic to stay in the domain layer and out of the data layer. In other words – the repository is kind of an abstract layer and as such, it’s easier to expand the two other layers without worrying about dependencies (such as type dependencies). This also allows easier use of unit testing, caching, and overall code maintenance.

###Example
The example project is an application where users could order widgets. Widgets can have a type, or category. It’s a very simple application with only these data models.
-	Widget
-	Category
-	Order
-	User

For the sake of example, the names of these models are different at the business layer. From the businesses point of view, the application sells products to users and these products may have different types. From the business layer, the models are:
-	Product
-	Type
-	PurchaseOrder

There are two repositories connecting these two layers. They are
-	WidgetsRepository
-	OrdersRepository

The business layer interacts with these repositories. There is no database in this application so instead, it uses a static mock data that is persisted in memory. 

The objective of this project is to show how these repositories are used by the controllers (the business layer). For sake of example, the business rule shown is how the Total Price is calculated. This is done in the repository before going into the data layer. One can imagine other business rules being implemented here, or near this layer outside the data layer.

Another example shown is the ModelFactory. This is a very simple class that basically translates domain models (or view models) into data models and vice versa. You can see how the controllers use this factory as it interacts with the different repositories.

###Entity Framework
This example is simplified without the use of an actual database. As such, no ORM (like Entity Framework) was necessary or used. This example was focused on the patterns only.

###Eager Loading vs Lazy Loading
This project does not give example of loading related data (to keep it simple and focused on the patterns). But when loading related data, there are two ways to do it – Eagerly vs Lazy.

Simply put, Eager loading loads the dependency records (related data) with the parent record. This is usually done in a single SQL transaction. Oppositely, Lazy loading loads the dependency records (related data) only when those records are referenced. This usually translates to multiple SQL operations.

Eager loading is activated when calling the .Include() method in the LINQ query. This also requires a .ToList() at the end of the query in order to begin execution. 

Generally we use eager loading and is the default. To use lazy loading it is configured through the DbContext. It is set in the contextObjects:

context.ContextOptions.LazyLoadingEnabled = true;

###IQueryable vs IEnumerable
This project does not give example of lazy loading. However, if we were to use lazy loading our common options would be IQueryable or IEnumerable. The difference between these two are where the query filters are executed. IQueryable executes the filters at the server side whereas IEnumerable executes it at the client side.

For example, lets assume GetAllWidgets() returns IEnumerable:

IEnumerable<Widget> widgets = Repository.Widgets.GetAllWidgets().Where(x => x.Price > 5);

In this case, the widgets variable would actually get all the widget records first, then it would apply the “x.Price > 5” filter.

Lets assume the GetAllWidgets() returns IQueryable:

IQueryable<Widget> widgets = Repository.Widgets.GetAllWidgets().Where(x => x.Price > 5);

In this case, the widgets variable would only get those records from the database where “x.Price > 5”. 

From the client’s point of view, IQueryable should return the smaller result set than IEnumerable.

###Unit of Work Pattern
Another pattern often found when using repositories is the UnitOfWork pattern. This allows a transaction like process allowing multiple calls to the data layer be grouped into a single transaction. If any of the calls fails or errors, the whole transaction would be rolled back. This pattern also improves performance since the multiple database operations are essentially grouped together as a single operation. 

Our example here was focused on the repository pattern only so the Unit Of Work pattern is not shown. This helps keep it simple without introducing too many concepts at once. 

###References
The Repository Pattern
https://msdn.microsoft.com/en-us/library/ff649690.aspx

Eager and Lazy loading in EF6
https://msdn.microsoft.com/en-us/library/dd456846(v=vs.100).aspx

Eager and Lazy loading in EF Core
https://docs.microsoft.com/en-us/ef/core/querying/related-data


###Source Code
https://github.com/johnlee/Widgets.API






