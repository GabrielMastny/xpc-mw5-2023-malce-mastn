using System.Data.SqlClient;
using Eshop.DAL;
using Eshop.DAL.Mappers;
using Eshop.DAL.QueryObjects;
using Eshop.DAL.Repositories;

namespace Eshop.ConsoleApp;

class Program
{

    private static CategoryRepository _categoryRepository = new CategoryRepository(new EshopContext(), new CategoryMapper());

    private static CommodityRepository _commodityRepository =
        new CommodityRepository(new EshopContext(), new CommodityMapper());

    private static ManufacturerRepository _manufacturerRepository =
        new ManufacturerRepository(new EshopContext(), new ManufacturerMapper());

    private static ReviewRepository _reviewRepository = new ReviewRepository(new EshopContext(), new ReviewMapper());

    public static void Main(string[] args)
    {


        var commodity = _commodityRepository.GetById(Guid.Parse("000d0f21-7d41-44cd-9323-e5df99300c6d"));
        
        Console.WriteLine(commodity);

        foreach (var r in commodity.Reviews)
        {
            Console.WriteLine("Print console");
            Console.WriteLine(r);
        }

        // var commodities =
        //     new GetCommoditiesByCommodityDataFilterQuery(new EshopContext(), new CommodityMapper()).Execute(
        //         new CommodityDataFilter());
        
        // foreach (var c in commodities)
        // {
        //     var reviews = GenerateDatabase.GenerateFakeReviews(3);
        //
        //     foreach (var r in reviews)
        //     {
        //         c.Reviews.Add(r);
        //
        //         r.Commodity = c.Id;
        //         
        //         _reviewRepository.Create(r);
        //     }
        //
        //     Console.WriteLine(c.Name);
        // }

        // Random rnd = new Random();
        //
        // Console.WriteLine("Hello, World!");
        //
        // var mans = GenerateDatabase.GenerateFakeManufacturer(10);
        //
        // var cats = GenerateDatabase.GenerateFakeCategory(20);
        //
        // var comms = GenerateDatabase.GenerateFakeCommodities(100);
        //
        // var array = cats.ToArray();
        //
        // var marray = mans.ToArray();
        //
        // foreach (var m in mans)
        // {
        //     _manufacturerRepository.Create(m);
        //     Console.WriteLine(m.Name);
        // }
        //
        // foreach (var ca in cats)
        // {
        //     var id = _categoryRepository.Create(ca);
        //     Console.WriteLine(id);
        // }
        //
        // foreach (var c in comms)
        // {
        //     c.Category = array[rnd.Next(array.Length)];
        //     
        //     c.Manufacturer = marray[rnd.Next(marray.Length)];
        //     
        //     //c.Category = _categoryRepository.GetById(Guid.Parse("00e02cde-a825-429f-8c8e-da826f7f2755"));
        //     
        //     //c.Manufacturer = _manufacturerRepository.GetById(Guid.Parse("0459fbc6-2b12-489c-9b73-e89a5d543f7c"));
        //     
        //     // var revs = GenerateDatabase.GenerateFakeReviews(3);
        //     //
        //     // foreach (var r in revs)
        //     // {
        //     //     c.Reviews.Add(r);
        //     //     r.Commodity = c.Id;
        //     //
        //     //     _reviewRepository.Create(r);
        //     // }
        //     
        //     _commodityRepository.Create(c);
        //     
        //     Console.WriteLine(c.Name);
        // }

        // const string connstring =
        //     "Data Source=DESKTOP-TA4S5VB\\SQLEXPRESS; Initial Catalog=Eshop; Integrated Security=true; TrustServerCertificate=true";
        //
        // using var conn = new SqlConnection(connstring);
        //
        // //var services = new ServiceCollection();
        //
        // //services.AddScoped<GenerateDatabase>();
        //
        // //services.AddDbContext<StudentsContext>();
        //
        // //var serviceProvider = services.BuildServiceProvider();
        //
        // //var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
        //
        // //using (var scope = serviceScopeFactory.CreateScope())
        // //{
        // //var generateStudents = scope.ServiceProvider.GetRequiredService<GenerateDatabase>();
        //
        // //var students = generateStudents.Init(10);
        //
        // conn.Open();
        //
        // foreach (var m in mans)
        // {
        //     
        //     string commandAddress = "INSERT INTO [Eshop].[dbo].[Manufacturers] (Id, City, State) VALUES (";
        //
        //     //s.Address.Id = Guid.NewGuid();
        //
        //     commandAddress = commandAddress + "'" + s.Address.Id + "','" + s.Address.City + "','" + s.Address.State + "')";
        //
        //     var commandA = new SqlCommand(commandAddress, conn);
        //
        //     commandA.ExecuteScalar();
        //
        //     s.Id = Guid.NewGuid();
        //     
        //     string commandString =
        //         "INSERT INTO [Students].[dbo].[students] (Id, Name, Surname, Program, AddressId) VALUES (";
        //     //_studentRepository.Create(s);
        //
        //     commandString = commandString +  "'" + s.Id + "','" + s.Name + "','" + s.Surname + "','" + s.Program + "','" + s.Address.Id + "')";
        //     
        //     // string commandStringAddress =
        //     //     "INSERT INTO [Students].[dbo].[addresses] (Id, City, State) VALUES (";
        //     // //_studentRepository.Create(s);
        //     //
        //     // commandStringAddress = commandString +  "'" + s.Id + "','" + s.Name + "','" + s.Surname + "','" + s.Program + "','" + s.Address.Id + "')";
        //     
        //     var command1 = new SqlCommand(commandString, conn);
        //
        //     command1.ExecuteScalar();
        //     
        //     Console.WriteLine("Create new student");
        //     Console.WriteLine(s.Name);
        //
        // }
        // conn.Close();
        // //}
        //
        // const string st = "SELECT TOP (100) [Id],[Name],[Surname],[Program],[AddressId] FROM [Students].[dbo].[students] WHERE Program='IBE'";
        //
        // var command = new SqlCommand(st, conn);
        //
        // Console.WriteLine("############## Student database");
        // try
        // {
        //     
        //     conn.Open();
        //     
        //     var reader = command.ExecuteReader();
        //
        //     while (reader.Read())
        //     {
        //         Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
        //
        //     }
        //     
        //     reader.Close();
        //     
        //     conn.Close();
        //
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e.Message);
        // }


    }
    
}