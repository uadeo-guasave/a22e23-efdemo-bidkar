// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using EFDemo.Models;
using System.Linq;

internal partial class Program
{
    static void Main(string[] args)
    {
        // InitializeDatabase();
        // CrearUsuario();
        // GetUsers();
        // https://localhost/api/User/2
        // User usuario = GetUserById(2);
        // System.Console.WriteLine(usuario.AllName);
        UserLogin("bidkar", "12345"); // incorrecta
        ChangePassword(1, "123"); // cambiar password a usuario bidkar
        UserLogin("bidkar", "123"); // correcta
        DeleteUser(2);
    }

    private static void DeleteUser(int id)
    {
        using (var db = new SqliteDbContext())
        {
            var user = GetUserById(id);
            if (user is null)
            {
                System.Console.WriteLine("Usuario no existente");
            }
            else
            {
                db.Remove(user);
                db.SaveChanges();
                System.Console.WriteLine("Usuario eliminado correctamente");
            }
        }
    }

    private static void ChangePassword(int id, string newPassword)
    {
        var user = GetUserById(id);
        if (user is null)
        {
            System.Console.WriteLine($"No se encuentra un usuario con id {id}");
        }
        else
        {
            using (var db = new SqliteDbContext())
            {
                user.Password = newPassword;
                db.Update(user);
                db.SaveChanges();
            }
        }
    }

    private static void UserLogin(string name, string password)
    {
        // Realiza el código para validar un inicio de sesión
        // a partir del usuario y la contraseña dada
        using (var db = new SqliteDbContext())
        {
            var user = db.Users!
                         .Where(u => u.Name == name && u.Password == password)
                         .FirstOrDefault();
            if (user is not null)
            {
                System.Console.WriteLine($"Login correcto para {user.AllName}");
            }
            else
            {
                System.Console.WriteLine("Login incorrecto");
            }
        }
    }

    private static User GetUserById(int id)
    {
        using (var db = new SqliteDbContext())
        {
            var user = db.Users!.Find(id);
            return user;
        }
    }



    // CRUD Create Read Update Delete
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
}


