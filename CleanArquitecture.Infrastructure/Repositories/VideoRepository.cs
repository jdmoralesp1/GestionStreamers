using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Domain;
using CleanArquitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Infrastructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        { }

        public async Task<Video> GetVideoByNombre(string nombreVideo)
        {
            return await _context!.Videos!.Where(x => x.Nombre == nombreVideo).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
        {
            return await _context.Videos!.Where(x => x.CreatedBy == username).ToListAsync();
        }
    }
}
