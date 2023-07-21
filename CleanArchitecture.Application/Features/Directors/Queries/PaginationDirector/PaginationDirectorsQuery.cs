using CleanArchitecture.Application.Features.Directors.Queries.Vms;
using CleanArchitecture.Application.Features.Shared.Queries;
using MediatR;

namespace CleanArchitecture.Application.Features.Directors.Queries.PaginationDirector
{
    //                                    : Lo que voy a ingresar, Lo que voy a devolver PaginationVm<DirectorVm>
    public class PaginationDirectorsQuery : PaginationBaseQuery, IRequest<PaginationVm<DirectorVm>>
    {
        //Aca se pueden agregar parametros extra
    }
}
