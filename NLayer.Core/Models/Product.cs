﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Model
{
    public class Product : BaseEntity //class'ların default access modifier'ları internal iken property,field,method ların ki ise private'dır.
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }


        public int CategoryId { get; set; }    
        public Category Category { get; set; }

        public ProductFeature ProductFeature { get; set; }

    }
}
