using System;
using System.Collections.Generic;
using Raven.Client.Documents;

namespace BookstoreDemo
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class Order
    {
        public string Id { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderLine> Items { get; set; } = new();
        public decimal TotalPrice { get; set; }
        public DateTime OrderedAt { get; set; }
    }

    public class OrderLine
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Connecting to RavenDB...");

            // Initialize connection to your local database
            using var store = new DocumentStore
            {
                Urls = new[] { "http://127.0.0.1:8080" },
                Database = "OnlineBookstoreDemo"
            };
            store.Initialize();

            Console.WriteLine("Connected successfully!\n");

            // 1. Seed Books
            using (var session = store.OpenSession())
            {
                session.Store(new Book { Id = "books/1-A", Title = "Domain-Driven Design", Author = "Eric Evans", Price = 54.99m, Stock = 10 });
                session.Store(new Book { Id = "books/2-A", Title = "Clean Code", Author = "Robert C. Martin", Price = 42.00m, Stock = 15 });
                session.SaveChanges();
            }
            Console.WriteLine("[+] Seeded books into database.");

            // 2. Query Books
            using (var session = store.OpenSession())
            {
                var books = session.Query<Book>().Where(b => b.Price > 40.00m).ToList();
                Console.WriteLine("\n[?] Books over $40 found:");
                foreach (var b in books)
                {
                    Console.WriteLine($"  - {b.Title} by {b.Author} (${b.Price}) [Stock: {b.Stock}]");
                }
            }

            // 3. Place an Order (Transaction)
            using (var session = store.OpenSession())
            {
                var book = session.Load<Book>("books/1-A");
                book.Stock -= 2; // Reduce stock

                var order = new Order
                {
                    CustomerEmail = "test@example.com",
                    OrderedAt = DateTime.UtcNow,
                    TotalPrice = book.Price * 2,
                    Items = new List<OrderLine>
                    {
                        new OrderLine { BookId = book.Id, Title = book.Title, Price = book.Price, Quantity = 2 }
                    }
                };

                session.Store(order);
                session.SaveChanges(); // Commits transaction atomically

                Console.WriteLine($"\n[+] Order placed successfully! Total: ${order.TotalPrice}");
                Console.WriteLine($"    Remaining stock for {book.Title}: {book.Stock}");
            }

            Console.WriteLine("\nDemo complete! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
