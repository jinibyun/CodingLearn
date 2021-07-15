using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreConsole.Model
{
    public class Facility
    {
        public int Id { get; set; }

        public string FacilityName { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public double Price { get; set; }
    }
}
