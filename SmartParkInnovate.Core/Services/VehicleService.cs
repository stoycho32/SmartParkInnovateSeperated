using SmartParkInnovate.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkInnovate.Core.Services
{
    public class VehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
