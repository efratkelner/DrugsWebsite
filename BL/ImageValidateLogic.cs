using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ImageValidateLogic
    {
        public List<string> CheckImage(string ImagePath)
        {
            List<string> Result = new List<string>();
            // Will accept only decriptions above t
            double t = 50.0;

            ImageContent img = new ImageContent(ImagePath);

            img.ImageDetails = new Dictionary<string, double>();
            

            CheckImages dal = new CheckImages();

            dal.GetDescriptions(img);

            foreach (var item in img.ImageDetails)
            {
                if (item.Value > t)
                {
                    Result.Add(item.Key);
                }
                else
                {
                    break;
                }


            }
            List<string> tmp = new List<string> { "pill bottle", "equipment", "toothbrush", "brush", "candy", "health", "medicine", "pills", "pill", "drug", "drugs", "medical", "doctor", "bottle", "syring", "prescription drug", "rubber eraser", };
            bool flag = false;
            for (int i = 0; i < Result.Count; i++)
            {
                if (tmp.Contains(Result[i]))
                    flag = true;
            }
            if (flag == false)
                throw new Exception("not a drug image");

            return Result;
        }
    }
}
