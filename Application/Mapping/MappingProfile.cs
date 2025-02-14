using AutoMapper;
using RedeSocial_Auth.Application.DTOs;
using RedeSocial_Auth.Domain.Models.Users;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Defina os mapeamentos entre a entidade e o DTO
        CreateMap<User, UserDTO>().ReverseMap(); // Para mapear ambos os sentidos
    }
}
