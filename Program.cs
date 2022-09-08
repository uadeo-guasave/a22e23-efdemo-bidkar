// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using EFDemo.Models;

// InitializeDatabase();
// CRUD Create Read Update Delete

GetUsers();
static void GetUsers()
{
    using (var db = new SqliteDbContext())
    {
        var users = db.Users!.ToList();
        foreach (var u in users)
        {
            System.Console.WriteLine($"Usuario:{u.Name} Email:{u.Email}");
        }
    }
}

// CrearUsuario();
static User SaveNewUser(User user)
{
    using (var db = new SqliteDbContext())
    {
        db.Database.EnsureCreated();
        db.Users!.Add(user);
        db.SaveChanges();
        return user;
    };
}

static void InitializeDatabase()
{
    var usuario = new User()
    {
        Id = 1,
        Name = "bidkar",
        Password = "123456",
        Firstname = "Bidkar",
        Lastname = "Aragón Cárdenas",
        Email = "bidkar.aragon@uadeo.mx"
    };

    // Crear conexión y tablas
    // var db = new SqliteDbContext();
    using (var db = new SqliteDbContext())
    {
        db.Database.EnsureCreated();
        db.Users!.Add(usuario);
        db.SaveChanges();
    };
}

static void CrearUsuario()
{
    var user = SaveNewUser(new User
    {
        Name = "maria",
        Password = "123456",
        Firstname = "Maria",
        Lastname = "Victoria",
        Email = "maria@victoria.mx"
    });
    System.Console.WriteLine($"User:{user.Name} Id:{user.Id}");
}