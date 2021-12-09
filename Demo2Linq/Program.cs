namespace demo2linq
{
    class Program
    {
       
     
        

        static void Main(string[] args)
        {
            List<Teacher> list =new List<Teacher>();
            list.Add(new Teacher() { Id = 1 , Name = "Ninh",Age=18 ,Income = 10000000 , Address ="Ha Noi"} );
            list.Add(new Teacher() { Id = 2, Name = "Tuan", Age = 19, Income = 20000000, Address = "Ha Nam" });
            list.Add(new Teacher() { Id = 3, Name = "Dien", Age = 20, Income = 10000000, Address = "Hai DUong" });
            list.Add(new Teacher() { Id = 4, Name = "Bach", Age = 21, Income = 15000000, Address = "Ha Noi" });
            list.Add(new Teacher() { Id = 5, Name = "Thuong", Age = 22, Income = 13000000, Address = "Ha Nam" });
            list.Add(new Teacher() { Id = 6, Name = "Nham", Age = 23, Income = 17000000, Address = "Ha Nam" });
            list.Add(new Teacher() { Id = 7, Name = "Anh", Age = 18, Income = 12000000, Address = "Ha Noi" });

            Console.WriteLine("------danh sach giao vien------");
           
            foreach (Teacher t in list)
            {
                Console.WriteLine("Id={0}  Name: {1}   Age= {2}   Income= {3}  Adress: {4}  TaxCoe= {5}",t.Id,t.Name,t.Age,t.Income,t.Address,t.TaxCoe());
            }


            var teacher = from t in list
                          where t.Name.StartsWith("n", StringComparison.OrdinalIgnoreCase)
                          select new
                          { 
                              ID = t.Id,
                              Name = t.Name,
                              Age=t.Age,
                              Income = t.Income,
                              Address = t.Address,
                              Taxcoe =t.TaxCoe()
                          };
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("-----nhung nguoi bat dau bang chu N------");
            foreach (var teachers in teacher)
            {
                Console.WriteLine("Id={0}  Name: {1} Age= {2}   Income= {3}  Adress: {4}  TaxCoe= {5}", teachers.ID,teachers.Name,teachers.Age,teachers.Income,teachers.Address,teachers.Taxcoe);
            }

            var address = from s in list
                          where s.Address.Equals("HA NOI", StringComparison.OrdinalIgnoreCase)
                          select new
                          {
                              ID = s.Id,
                              Name = s.Name,
                              Age = s.Age,
                              Income = s.Income,
                              Address = s.Address,
                              Taxcoe = s.TaxCoe()
                          };
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("-----nhung nguoi dia chi o ha noi-----");
            foreach (var teachers in address)
            {
                Console.WriteLine("Id={0}  Name: {1} Age= {2}   Income= {3}  Adress: {4}  TaxCoe= {5}", teachers.ID, teachers.Name, teachers.Age, teachers.Income, teachers.Address, teachers.Taxcoe);
            }
            var income = from i in list
                          where i.Income <= 15000000
                         select new
                          {
                             ID = i.Id,
                             Name = i.Name,
                             Age = i.Age,
                             Income = i.Income,
                             Address = i.Address,
                             Taxcoe = i.TaxCoe()
                         };
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("-----nhung nguoi thu nhap <=15000000-----");
            foreach (var teachers in income)
            {
                Console.WriteLine("Id={0}  Name: {1} Age= {2}   Income= {3}  Adress: {4}  TaxCoe= {5}", teachers.ID, teachers.Name, teachers.Age, teachers.Income, teachers.Address, teachers.Taxcoe);
            }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("-----nhung nguoi dong thue  <=1500000-----");
            var taxcoe = from t in list
                         where t.TaxCoe() <= 1500000 && t.TaxCoe()!=0
                         select new
                         {
                             ID = t.Id,
                             Name = t.Name,
                             Age= t.Age,
                             Income = t.Income,
                             Address = t.Address,
                             Taxcoe = t.TaxCoe()
                         };
            foreach (var teachers in taxcoe)
            {
                Console.WriteLine("Id={0}  Name: {1} Age= {2}   Income= {3}  Adress: {4}  TaxCoe= {5}", teachers.ID, teachers.Name, teachers.Age, teachers.Income, teachers.Address, teachers.Taxcoe);
            }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("-----nhung nguoi khong can dong thue-----");
            var taxcoe1 = from t in list
                         where t.TaxCoe()==0
                         select new
                         {
                             ID = t.Id,
                             Name = t.Name,
                             Age = t.Age,
                             Income = t.Income,
                             Address = t.Address,
                             Taxcoe = t.TaxCoe()
                         };
            foreach (var teachers in taxcoe1)
            {
                Console.WriteLine("Id={0}  Name: {1} Age= {2}   Income= {3}  Adress: {4}  TaxCoe= {5}", teachers.ID, teachers.Name, teachers.Age, teachers.Income, teachers.Address, teachers.Taxcoe);
            }

            Console.ReadKey();
        }
    }
}