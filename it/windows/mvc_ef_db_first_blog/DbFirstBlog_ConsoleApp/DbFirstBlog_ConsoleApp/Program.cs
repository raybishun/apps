using System;
using System.Linq;

namespace DbFirstBlog_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                Console.Write("Enter the name for a new blog: ");
                var name = Console.ReadLine();

                try
                {
                    db.Blogs.Add(new Blog() { Name = name });
                    db.SaveChanges();

                    var query = from blog in db.Blogs
                                orderby blog.Name
                                select blog;

                    foreach (var blog in query)
                    {
                        Console.WriteLine($"\t --> {blog.Name}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
