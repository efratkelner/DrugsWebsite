﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public List<string> Descriptions { get; set; }
    }
}