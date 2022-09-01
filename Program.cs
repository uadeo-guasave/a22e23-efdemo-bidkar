// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using EFDemo.Models;

var usuario = new User();
System.Console.WriteLine(usuario.Id);
System.Console.WriteLine(usuario.Name);
System.Console.WriteLine(usuario.RememberToken);