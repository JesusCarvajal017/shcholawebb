﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.UserRol
{
    public class UserRolCreateDtos
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RolId { get; set; }
    }
}
