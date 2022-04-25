using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuShared.Dtos
{
    public class BaseEntityDto
    {
        public int IdDto { get; set; }
        public bool ActiveDto { get; set; }
        public bool? DeletedDto { get; set; }
        public DateTime CreatedOnDto { get; set; } = DateTime.Now;
        public DateTime? UpdatedOnDto { get; set; }
    }
}
