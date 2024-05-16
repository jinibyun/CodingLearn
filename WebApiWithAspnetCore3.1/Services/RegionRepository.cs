using EFCoreConsole.NorthwindModel;
using System.Collections.Generic;
using System.Linq;
using WebApiWithAspnetCore31.Data;
using WebApiWithAspnetCore31.Dtos;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Services
{
    public class RegionRepository : IRegion
    {
        private NorthwindContext dbContext;
        public RegionRepository(NorthwindContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public RegionRepository()
        {

        }

        public IQueryable<Region> GetRegions()
        {
            return dbContext.Region;
        }
        public Region GetRegion(int id)
        {
            var region = dbContext.Region.SingleOrDefault(m => m.RegionId == id);
            return region;
        }
        public bool AddRegion(RegionDto region)
        {
            try
            {
                bool isExist = dbContext.Region.Where(x => x.RegionId == region.RegionId).Any();
                if (!isExist)
                {
                    // convert RegionDto to Region
                    var r = new Region
                    {
                        RegionId = region.RegionId,
                        RegionDescription = region.RegionDescription,
                    };
                    dbContext.Region.Add(r);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateRegion(RegionDto region)
        {
            try
            {
                var existingRegion = dbContext.Region.Where(x => x.RegionId == region.RegionId).FirstOrDefault();
                if (existingRegion != null)
                {
                    existingRegion.RegionDescription = region.RegionDescription;
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteRegion(int id)
        {

            try
            {
                var existingRegion = dbContext.Region.Where(x => x.RegionId == id).FirstOrDefault();
                if (existingRegion != null)
                {
                    dbContext.Region.Remove(existingRegion);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
