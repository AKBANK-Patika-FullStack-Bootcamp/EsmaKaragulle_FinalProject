using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ApartmentDetailDto
    {
        public int ApartmentId { get; set; }
        public string OwnerName { get; set; }
        public string? TenantName { get; set; }
        public string BlockNo { get; set; }
        public string FloorNo { get; set; }
        public string DoorNo { get; set; }
        public string ApartmentType { get; set; }
        public bool IsBlank { get; set; }
        public bool IsActive { get; set; }
    }
}
