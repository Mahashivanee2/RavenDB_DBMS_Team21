# Online Bookstore — DBMS Project Using RavenDB

## Project Details

- **Project Name:** Online Bookstore
- **Database:** RavenDB
- **Backend:** C# and .NET
- **Team Number:** Team-21
- **Course / Subject:** Database Management Systems (DBMS)

## Team Members

Replace the placeholders below with the roll number and full name of every team member.

| S. No. | Roll Number | Name |
|---|---|---|
| 1 | [CB.SC.U4CSE25745] | [Rithanya Devi] |
| 2 | [CB.SC.U4CSE25726] | [Mahashivanee M] |


## Project Overview

Online Bookstore is a DBMS project developed to demonstrate the use of RavenDB as a document-oriented NoSQL database. The application manages book information, retrieves books based on their prices, processes customer orders, and updates book stock.

The project uses C# and .NET to communicate with RavenDB through its client library. Book and order information is stored as documents in the database.

## Objectives

- Understand and implement RavenDB as a NoSQL document database.
- Connect a C# application to a RavenDB database.
- Store and retrieve book information using document operations.
- Execute queries to retrieve books based on specified conditions.
- Demonstrate order processing and inventory updates.
- Understand how database sessions and transactions work in RavenDB.

## Technology Stack

- **RavenDB:** Document-oriented NoSQL database used to store book and order information.
- **C#:** Programming language used to implement the application logic.
- **.NET:** Runtime and development platform for the application.
- **RavenDB Client Library:** Connects the C# application to RavenDB and supports document storage, retrieval, and querying.
- **LINQ:** Used to query book documents based on conditions.

## System Architecture

1. The C# application initializes a connection to the RavenDB server.
2. The application opens a database session to perform operations.
3. Book documents are inserted into the `OnlineBookstoreDemo` database.
4. LINQ queries retrieve books that satisfy the specified price condition.
5. The application loads a book document and updates its stock when an order is placed.
6. Order information is stored as a document in RavenDB.
7. The session saves the changes to the database.

## Database Design

The project uses two main document types.

### 1. Books

Each book document contains:

- **Id:** Unique document identifier.
- **Title:** Title of the book.
- **Author:** Name of the author.
- **Price:** Price of the book.
- **Stock:** Available quantity.

Sample book documents:

| Book ID | Title | Author | Price | Stock |
|---|---|---|---:|---:|
| books/1-A | Domain-Driven Design | Eric Evans | 54.99 | 10 |
| books/2-A | Clean Code | Robert C. Martin | 42.00 | 15 |

### 2. Orders

Each order document contains:

- **Id:** Unique document identifier.
- **CustomerEmail:** Email address associated with the order.
- **Items:** List of ordered books, including their IDs, titles, prices, and quantities.
- **TotalPrice:** Total cost of the order.
- **OrderedAt:** Date and time when the order was created.

The order document stores the relevant book details in its `Items` collection.

## CRUD Operations and Database Queries

The project demonstrates document creation, retrieval, and updating through the C# application.

### 1. Create

The application inserts two sample book documents into RavenDB using `session.Store()` and saves them using `session.SaveChanges()`.

It also creates an order document when a customer places an order.

### 2. Read

The application retrieves books with prices greater than $40 using a LINQ query.

It also loads a particular book document using its document ID before processing an order.

### 3. Update

When an order is placed, the application decreases the stock of the selected book by two.

The updated stock and the new order are saved using the same RavenDB session.

### 4. Delete

A delete operation is not implemented in the supplied `Program.cs`. It should only be included in the demonstration if a delete operation is implemented separately.

## Order Processing

The project demonstrates a simple bookstore transaction:

1. Load the book document for *Domain-Driven Design*.
2. Reduce the book's stock by two.
3. Calculate the total price for two copies.
4. Create an order document containing the customer email and ordered items.
5. Save the stock update and order document using `session.SaveChanges()`.

For the sample book priced at $54.99, the order total is $109.98.

The stock decreases from 10 to 8 on the first successful run against the initial sample data.

## How to Run the Project

### Prerequisites

- RavenDB Server installed and running locally.
- .NET SDK compatible with the supplied project.
- The RavenDB database named `OnlineBookstoreDemo`.

### Step 1: Start RavenDB

Start the local RavenDB server using your configured installation and ensure that it is accessible at:

`http://127.0.0.1:8080`

### Step 2: Configure the Database

Create or verify the `OnlineBookstoreDemo` database in RavenDB Studio.

Ensure that the database connection settings in `Program.cs` match your RavenDB configuration.

### Step 3: Run the C# Application

Open a terminal in the directory containing `BookStoreDemo.csproj` and execute:

```powershell
dotnet restore
dotnet run
```

### Step 4: Verify the Output

The application should:

- Connect to RavenDB.
- Insert the sample book documents.
- Display books priced above $40.
- Create an order for two copies of *Domain-Driven Design*.
- Display the order total and the remaining stock.

You can also inspect the stored book and order documents in RavenDB Studio.

**Note:** Running the program repeatedly inserts the sample book documents again using their specified IDs, creates additional orders, and decreases the stock each time. Reset the sample data before repeating the demonstration if you want to reproduce the original output.

## Files Submitted

The team submission folder contains the following deliverables:

- `RAVENDB(1).pptx` — PowerPoint presentation for the RavenDB DBMS case study.
- `demo-video.mp4` — Screen recording showing the working application, queries, and outputs.
- `queries.txt` — Database query examples and operations demonstrated in the project.
- `README.md` — Project description, database design, execution instructions, and team details.
- `Program.cs` — C# implementation of the bookstore demo.
- `BookStoreDemo.csproj` — .NET project configuration.

## Demonstration Evidence

The demo video should show:

1. The RavenDB server running and the `OnlineBookstoreDemo` database.
2. The C# application connecting to RavenDB.
3. The insertion of sample book documents.
4. The query retrieving books priced above $40.
5. The creation of an order and the calculated total.
6. The updated stock value.
7. The corresponding book and order documents in RavenDB Studio.

The `queries.txt` file should contain the relevant queries, brief explanations, and expected outputs.

## Conclusion

The Online Bookstore project demonstrates how RavenDB can be integrated with a C# application to manage document-based data. It illustrates book storage, conditional queries, order creation, and inventory updates through database sessions.

The project provides practical experience with NoSQL database concepts, document modelling, LINQ querying, and transaction-oriented application development.
