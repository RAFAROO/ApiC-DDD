using CleanOnionNetwork.Domain;
using Microsoft.Extensions.Logging;

namespace CleanOnionNetwork.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if(!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("success record Streamer!");
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer {CreatedBy = "roo", Nombre = "Maxi HBP", Url = "http://www.hp.com.mx"}
            };
        }


    }
}
