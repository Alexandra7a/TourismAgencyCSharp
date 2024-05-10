﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyModel.model
{
    [Serializable]

    public class Entity<ID>
    {
        protected ID id;
        public ID Id { get; set; }
    }
}