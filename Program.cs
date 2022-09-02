// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using EFDemo.Models;

var usuario = new User() {
    Id = 1,
    Name = "bidkar",
    Password = "123456",
    Firstname = "Bidkar",
    Lastname = "Aragón Cárdenas",
    Email = "bidkar.aragon@uadeo.mx"
};

// Crear conexión y tablas
// var db = new SqliteDbContext();
using (var db = new SqliteDbContext()) {
    db.Database.EnsureCreated();
    db.Users.Add(usuario);
    db.SaveChanges();
};
