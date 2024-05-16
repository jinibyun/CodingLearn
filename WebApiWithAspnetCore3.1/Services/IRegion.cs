using EFCoreConsole.NorthwindModel;
using System.Linq;
using WebApiWithAspnetCore31.Dtos;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Services
{
    public interface IRegion
    {
        IQueryable<Region> GetRegions();
        Region GetRegion(int id);
        bool AddRegion(RegionDto region);
        bool UpdateRegion(RegionDto region);
        bool DeleteRegion(int id);
    }
}
