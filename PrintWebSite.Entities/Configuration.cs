﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrintWebSite.Entities
{
    public class Configuration
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public int ConfigurationType { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
