using CleanArquitecture.Application.Models.ViewModels;
using MediatR;

namespace CleanArquitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVM>>
    {
        public string _Username { get; set; } = string.Empty;
        public GetVideosListQuery(string username)
        {
            _Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
