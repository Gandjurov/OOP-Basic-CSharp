using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        private const double HardDriveWeight = 1.0;

        public HardDrive(double price) 
            : base(price, HardDriveWeight)
        {
        }
    }
}
