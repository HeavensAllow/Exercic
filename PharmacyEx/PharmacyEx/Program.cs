using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;


namespace PharmacyEx
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ExFarmaciasEntities())
            {
                int option = 0;
                while (option != 4)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to your menu. What do you wish to do today?");
                    Console.WriteLine("1 - Insert new Pharmacy");
                    Console.WriteLine("2 - List all Pharmacy's");
                    Console.WriteLine("3 - Delete a Pharmacy");
                    Console.WriteLine("4 - Close");
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1)
                    {
                        Console.Clear();
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Identification code: ");
                        int code = Convert.ToInt32(Console.ReadLine());
                        Console.Write("City: ");
                        string city = Console.ReadLine();
                        Console.Write("Created by: ");
                        string createdby = Console.ReadLine();
                        DateTime date = DateTime.Now;

                        db.Database.ExecuteSqlCommand("CreatePharmacy @Code, @Name, @City, @CreatedOn, @CreatedBy", new SqlParameter("@Code", code),
                            new SqlParameter("@Name", name),
                            new SqlParameter("@City", city),
                            new SqlParameter("@CreatedOn", date),
                            new SqlParameter("@CreatedBy", createdby));

                        //db.Database.ExecuteSqlCommand("execute createPharmacy @Code, @Name, @City, @CreatedOn",
                        //    new SqlParameter("@Code", code),
                        //    new SqlParameter("@Name", name),
                        //    new SqlParameter("@City", city),
                        //    new SqlParameter("@CreatedOn", date),
                        //    new SqlParameter("@CreatedBy", createdby));

                    }
                    else if (option == 2)
                    {
                        Console.Clear();
                        List<ListPharmacy_Result> listPharmacy = db.Database.SqlQuery<ListPharmacy_Result>("ListPharmacy").ToList();
                        foreach (var phar in listPharmacy)
                        {
                            Console.WriteLine("Name: " + phar.Name);
                            Console.WriteLine("Code: " + phar.Code);
                            Console.WriteLine("City: " + phar.City);
                            Console.WriteLine("Created on: " + phar.CreatedOn);
                            Console.WriteLine("Created by: " + phar.CreatedBy);
                            Console.WriteLine("");
                        }
                        Console.WriteLine("Click enter to return");
                        Console.ReadLine();
                    }
                    else if (option == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter a Pharmacy ID to continue");
                        int id = Convert.ToInt32(Console.ReadLine());
                        SqlParameter delete = new SqlParameter("@ID", id);
                        Pharmacy deletePharmacy = db.Database.SqlQuery<Pharmacy>("ReadPharmacy @ID", delete).Single();
                        Console.Clear();
                        Console.WriteLine("Name: " + deletePharmacy.Name);
                        Console.WriteLine("Code: " + deletePharmacy.Code);
                        Console.WriteLine("City: " + deletePharmacy.City);
                        Console.WriteLine("Created on: " + deletePharmacy.CreatedOn);
                        Console.WriteLine("Created by: " + deletePharmacy.CreatedBy);
                        Console.WriteLine("Do you wish to delete this pharmacy?");
                        Console.WriteLine("1 - Yes");
                        Console.WriteLine("2 - No");
                        int option3 = Convert.ToInt32(Console.ReadLine());
                        if(option3 == 1)
                        {
                            SqlParameter todelete = new SqlParameter("@ID", id);
                            db.Database.ExecuteSqlCommand("DeletePharmacy @ID", todelete);
                        }
                    }

                }
            }

        }

    }
}

