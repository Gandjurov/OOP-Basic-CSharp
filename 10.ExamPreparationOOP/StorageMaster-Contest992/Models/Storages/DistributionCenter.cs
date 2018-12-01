using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class DistributionCenter : Storage
    {
        private const int DistributionCenterCapacity = 2;
        private const int DistributionCenterGarageSlots = 5;

        private static Vehicle[] DefaultVehicles =
        {
            new Van(),
            new Van(),
            new Van()
        };

        public DistributionCenter(string name) 
            : base(name, DistributionCenterCapacity, DistributionCenterGarageSlots, DefaultVehicles)
        {
        }
    }
}
