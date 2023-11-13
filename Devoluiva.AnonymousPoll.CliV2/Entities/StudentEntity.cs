﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoluiva.AnonymousPoll.CliV2.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Education { get; set; } = string.Empty;
        public int AcademicYear { get; set; }
    }
}
