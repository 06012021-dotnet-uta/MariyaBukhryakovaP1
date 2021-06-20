﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Models
    {
    public partial class Store
        {
        public int StoreLocation { get; set; }
        public int StoreProduct { get; set; }
        public int ProductInventory { get; set; }

        public virtual LocationDirectory StoreLocationNavigation { get; set; }
        public virtual Product StoreProductNavigation { get; set; }
        }
    }
