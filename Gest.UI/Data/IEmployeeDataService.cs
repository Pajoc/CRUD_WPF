﻿using System.Collections.Generic;
using Gest.Model;

namespace Gest.UI.Data
{
    public interface IEmployeeDataService
    {
        IEnumerable<Employee> GetAll();
    }
}