﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.Entities
{
    public class UserProfile
    {
        public UserProfile()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
