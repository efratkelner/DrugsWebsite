using System;
using System.Collections.Generic;

namespace BE
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string GenericName { set; get; }
        public string Producer { get; set; }
        public string ActiveIngredients { get; set; }
        public string Properties { get; set; }
        public string MImage { get; set; }
        public string Ndc { get; set; }
    }
}

