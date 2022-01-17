﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Models.Requests
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
