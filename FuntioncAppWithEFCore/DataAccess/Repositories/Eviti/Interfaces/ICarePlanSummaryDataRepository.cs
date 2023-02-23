﻿using Empower.DataAccess.Entities.Eviti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.DataAccess.Repositories.Eviti.Interfaces
{
    public interface ICarePlanSummaryDataRepository : IGenericRepository<CarePlanSummaryData>
    {
        CarePlanSummaryData GetCarePlanDataByCarePlanGuid(Guid cpGuid);
    }
}
