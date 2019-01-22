using AutoMapper;
using TodoList.Api.Data.Dtos.Response;
using TodoList.Api.Data.Models;

namespace TodoList.Api.Services {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            this.CreateMap<TodoItem, TodoItemResponse>();
        }
    }
}