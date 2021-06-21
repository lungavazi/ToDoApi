using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Models.Enums
{
    enum ToDoTypeId
    {
        [Description("Shopping")]
        Shopping = 1,
        [Description("Training")]
        Training = 2,
        [Description("Budget")]
        Budget = 3,
        [Description("Budget")]
        Other = 4
    }

}
