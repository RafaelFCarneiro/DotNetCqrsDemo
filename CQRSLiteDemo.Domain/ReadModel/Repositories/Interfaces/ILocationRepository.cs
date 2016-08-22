﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLiteDemo.Domain.ReadModel.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        bool LocationExists(int locationID);
        LocationDTO GetByID(int locationID);
        bool HasEmployee(int locationID, int employeeID);
    }
}
