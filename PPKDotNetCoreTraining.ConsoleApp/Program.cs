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

DapperExample dapper = new DapperExample();
dapper.Read();

Console.ReadKey();

