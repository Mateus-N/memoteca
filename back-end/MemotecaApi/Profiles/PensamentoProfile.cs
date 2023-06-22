using AutoMapper;
using MemotecaApi.Dtos;
using MemotecaApi.Models;

namespace MemotecaApi.Profiles;

public class PensamentoProfile : Profile
{
    public PensamentoProfile()
    {
        CreateMap<CreatePensamentoDto, Pensamento>();
        CreateMap<Pensamento, ReadPensamentoDto>();
        CreateMap<UpdatePensamentoDto, Pensamento>();
    }
}
