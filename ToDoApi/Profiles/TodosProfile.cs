using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Profiles
{
    public class TodosProfile: Profile
    {
        public TodosProfile()
        {
            CreateMap<Entities.ToDo, Models.TodoDTO>().ReverseMap();
        }
    }
}
