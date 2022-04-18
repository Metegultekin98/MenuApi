﻿using System;

namespace MenuApi.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
