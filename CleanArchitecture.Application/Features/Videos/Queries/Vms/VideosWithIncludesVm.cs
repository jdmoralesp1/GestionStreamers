using CleanArchitecture.Application.Features.Actores.Queries.Vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Videos.Queries.Vms
{
    public class VideosWithIncludesVm
    {
        public string? Nombre { get; set; }
        public int StreamerId { get; set; }
        public string? StreamerNombre { get; set; }
        public int DirectorId { get; set; }
        public string? DirectorNombreCompleto { get; set; }
        public virtual ICollection<ActorVm>? Actores { get; set; }
    }
}
