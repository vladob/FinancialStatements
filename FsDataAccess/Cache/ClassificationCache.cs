using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FsDataAccess.Cache
{
    public class ClassificationCache
    {
        public Dictionary<string, int> LegalForms { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> OrganizationSizes { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> OwnershipTypes { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> SkNace { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> Locations { get; set; } = new Dictionary<string, int>();

        public static async Task<ClassificationCache> LoadCacheAsync(ClassificationsDbContext context, ILogger logger)
        {
            var cache = new ClassificationCache();
/*
            logger.LogInformation("Loading LegalForms...");
            cache.LegalForms = await context.LegalForms.ToDictionaryAsync(lf => lf.Code, lf => lf.Id);
            logger.LogInformation("Loaded LegalForms.");

            logger.LogInformation("Loading OrganizationSizes...");
            cache.OrganizationSizes = await context.OrganizationSizes.ToDictionaryAsync(os => os.Code, os => os.Id);
            logger.LogInformation("Loaded OrganizationSizes.");

            logger.LogInformation("Loading OwnershipTypes...");
            cache.OwnershipTypes = await context.OwnershipTypes.ToDictionaryAsync(ot => ot.Code, ot => ot.Id);
            logger.LogInformation("Loaded OwnershipTypes.");

            logger.LogInformation("Loading SkNace...");
            cache.SkNace = await context.SkNaces.ToDictionaryAsync(sn => sn.Code, sn => sn.Id);
            logger.LogInformation("Loaded SkNace.");

            logger.LogInformation("Loading Locations...");
            cache.Locations = await context.Locations.ToDictionaryAsync(loc => loc.Code, loc => loc.Id);
            logger.LogInformation("Loaded Locations.");
*/
            return cache;
        }
    }
}
