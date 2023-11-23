﻿using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ICategories
{
    public interface InterfaceCategory : InterfaceGeneric<Category>
    {
        Task<IList<Category>> UserCategoriesList(string emailUser);
    }
}