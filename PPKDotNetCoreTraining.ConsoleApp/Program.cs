// See https://aka.ms/new-console-template for more information
using PPKDotNetCoreTraining.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadLine();

//AdoDotNet adoDotNet = new AdoDotNet();
//adoDotNet.Read();
//adoDotNet.Create();
//adoDotNet.Edit();
//adoDotNet.Update();
//adoDotNet.Delete();

//DapperExample dapper = new DapperExample();
//dapper.Read();
//dapper.Create("HIII", "p2k", "test dapper create");
//dapper.Edit();
//dapper.Update();
//dapper.Delete();

EFcore eFcore = new EFcore();
//eFcore.read();
eFcore.Create("EF core", "ppk", "Testring ef core");

Console.ReadKey();

