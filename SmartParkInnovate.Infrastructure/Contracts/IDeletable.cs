﻿namespace SmartParkInnovate.Infrastructure.Contracts
{
    public interface IDeletable
    {
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
