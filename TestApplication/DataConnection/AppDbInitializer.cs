using TestApplication.DataConnection.Models;

namespace TestApplication.DataConnection
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Ensure database is seeded only if there are no books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book()
                        {
                            Title = "Title nr.1",
                            ISBN = 421145522
                        },
                        new Book()
                        {
                            Title = "Title nr.2",
                            ISBN = 45245215
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
