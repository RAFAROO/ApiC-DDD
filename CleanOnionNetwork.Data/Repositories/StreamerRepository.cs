using CleanOnionNetwork.Application.Contracts.Persistence;
using CleanOnionNetwork.Domain;
using CleanOnionNetwork.Infrastructure.Persistence;

namespace CleanOnionNetwork.Infrastructure.Repositories
{
    public class StreamerRepository : RepositoryBase<Streamer>, IStreamerRepository
    {
        public StreamerRepository(StreamerDbContext context) : base(context)
        {

        }
    }
}
