using AutoMapper;
using CleanOnionNetwork.Application.Features.Directors.Commands.CreateDirector;
using CleanOnionNetwork.Application.Features.Streamers.Commands.CreateStreamer;
using CleanOnionNetwork.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanOnionNetwork.Application.Features.Videos.Queries.GetVideosList;
using CleanOnionNetwork.Domain;

namespace CleanOnionNetwork.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
            CreateMap<CreateStreamerCommand, Streamer>();
            CreateMap<UpdateStreamerCommand, Streamer>();
            CreateMap<CreateDirectorCommand, Director>();
        }
    }
}
