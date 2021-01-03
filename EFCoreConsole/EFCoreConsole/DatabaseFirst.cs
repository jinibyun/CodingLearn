using EFCoreConsole.Model;
using EFCoreConsole.NorthwindModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
namespace EFCoreConsole
{
    public class DatabaseFirst
    {
        public void AddData(int regionId, string regionDescription)
        {
            if (string.IsNullOrEmpty(regionDescription)) throw new Exception("region description cannot be null");

            using (var context = new NorthwindContext())
            {
                var region = new Region()
                {
                    RegionDescription = regionDescription,
                    RegionId = regionId
                };
                context.Region.Add(region);
                context.SaveChanges();
            }
        }

        public void UpdateData(int regionId, string regionDescription)
        {
            if (regionId < 1) throw new Exception("region id should be greater than zero");

            using (var context = new NorthwindContext())
            {
                // LINQ : Language INtegrated Query
                var region = context.Region.Where(x => x.RegionId == regionId).FirstOrDefault<Region>();
                
                if (region != null)
                {
                    region.RegionDescription = regionDescription;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("There is no region id : " + regionId.ToString());
                }
            }
        }

        public void DeleteData(int regionIde)
        {
            if (regionIde < 1) throw new Exception("region id should be greater than zero");
            using (var context = new NorthwindContext())
            {
                // First and FirstOrDefault
                var region = context.Region.Where(x => x.RegionId == regionIde).FirstOrDefault();

                if (region != null)
                {
                    context.Region.Remove(region);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("No region has been found");
                }
            }
        }

        public void GetData()
        {
            using (var context = new NorthwindContext())
            {
                // explanation
                // NOTE: What is difference between IQueryable and IEnumerable

                var lstRegions = context.Region.ToList<Region>();
                foreach (var member in lstRegions)
                {
                    Console.WriteLine(string.Format("Region Id: {0}, Region Description: {1}", member.RegionId, member.RegionDescription));
                }
            }
        }

        public void GetData(string regionDescription)
        {
            using (var context = new NorthwindContext())
            {
                var regionDesc = context.Region.Where(s => s.RegionDescription == regionDescription).Any() ? 
                                        context.Region.Where(s => s.RegionDescription == regionDescription).ToList<Region>() 
                                        : null;

                var found = 0;
                if (regionDesc != null)
                {
                    found = regionDesc.Count;
                }
                Console.WriteLine("Region found: " + found);

                // explanation
                // Difference Between Eager Loading and Lazy Loading
                // ref: https://www.itorian.com/2013/06/what-is-eager-loading-and-what-is-lazy.html
                // Eager Loading: It loads the related data in scalar and navigation properties along with query result at first shot.
                // Lazy Loading:  EF loads only the data for the primary object in the LINQ query (the Friend) and leaves the Contact object.
                // Lazy loading brings in the related data on an as-needed basis

                // Eager Loading                
                var regionWithTerritories = context.Region
                           .Where(s => s.RegionDescription == regionDescription)
                           .Include(s => s.Territories)
                           .FirstOrDefault();
                // lazy loading (default)
                var regionWithTerritories2 = context.Region
                           .Where(s => s.RegionDescription == regionDescription)
                           .FirstOrDefault();



                if (regionWithTerritories2 != null)
                {
                    int regionId = regionWithTerritories2.RegionId;
                    var territories = context.Territories.Where(x => x.RegionId == regionId).ToList<Territories>();
                }


                if (regionWithTerritories != null)
                {
                    var territoryDescriptions = regionWithTerritories.Territories;
                    foreach (var member in territoryDescriptions)
                    {
                        Console.WriteLine(regionWithTerritories.RegionDescription + " : " + member.TerritoryDescription);
                    }
                }
            }
        }

        public void GetDataUsingRawSQL()
        {
            using (var context = new NorthwindContext())
            {
                var lstCustomers = context.Customers.FromSqlRaw("Select * from Customers").ToList<Customers>();
                foreach (var member in lstCustomers)
                {
                    Console.WriteLine(string.Format("Customer Id: {0}, Customer Name: {1}", member.CustomerId, member.ContactName));
                }
            }
        }

        public void ExecuteSqlCommand()
        {
            using (var context = new NorthwindContext())
            {
                // TODO: using second parameter to pass database parameter to database
                // TODO
                //Insert command
                string insertSQL = "exec CustOrdersDetail {0}";
                int noOfRowInsert = context.Database.ExecuteSqlCommand(new RawSqlString(insertSQL), 12);

                string updateSQL = "";
                //Update command
                int noOfRowUpdate = context.Database.ExecuteSqlCommand(updateSQL);

                string deleteSQL = "";
                //Delete command
                int noOfRowDeleted = context.Database.ExecuteSqlCommand(deleteSQL);
            }
        }

        public void TransactionSupport()
        {
            using (var context = new NorthwindContext())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // TODO
                        // 1. Shippers 
                        // 2. Orders
                        // 3. Order details

                        // process 1
                        context.Shippers.Add(new Shippers()
                        {
                            
                        });

                        // process 2
                        context.Orders.Add(new Orders() { });

                        // process 3
                        context.OrderDetails.Add(new OrderDetails() { });


                        context.SaveChanges();

                        // pretend something happens here!!
                        // throw new Exception();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
            }
        }
    }
}
