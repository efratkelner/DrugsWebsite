using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ImageContent
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        // key is detected image content, value is propabilty
        public Dictionary<string, double> ImageDetails { get; set; }

        public ImageContent(string ImagePath)
        {
            this.ImagePath = ImagePath;
        }
    }
}
