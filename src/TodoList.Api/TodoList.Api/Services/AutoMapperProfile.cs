using AutoMapper;
using TodoList.Api.Data.Dtos.Response;
using TodoList.Api.Data.Models;

namespace TodoList.Api.Services {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            this.CreateMap<TodoItem, TodoItemResponse>()
                .ReverseMap()
                .ForMember(x => x.ApplicationUser, m => m.Ignore())
                .ForMember(x => x.ApplicationUserId, m => m.Ignore());
        }
    }
}