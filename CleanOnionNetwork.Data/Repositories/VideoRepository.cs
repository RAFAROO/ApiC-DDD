using CleanOnionNetwork.Application.Contracts.Persistence;
using CleanOnionNetwork.Domain;
using CleanOnionNetwork.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanOnionNetwork.Infrastructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {

        }
        public async Task<Video> GetVideoByNombre(string nombreVideo)
        {
            return await _context.Videos!.Where(v => v.Nombre == nombreVideo).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
        {
            return await _context.Videos!.Where(v => v.CreatedBy == username).ToListAsync();
        }
    }
}
