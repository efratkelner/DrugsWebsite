using BE;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CheckImages
    {
        public void GetDescriptions(ImageContent CurrentImage)
        {

            string apiKey = "";
            string apiSecret = "";
            string image = CurrentImage.ImagePath;

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            request.AddFile("image", image);//image = "C:\\Users\\User\\Downloads\\DrugsWebsite\\GUI\\images\\medic3.jpg"

            IRestResponse response = client.Execute(request);

            Root DetailsTree = JsonConvert.DeserializeObject<Root>(response.Content);

            foreach (var item in DetailsTree.result.tags)
            {
                CurrentImage.ImageDetails.Add(item.tag.en, item.confidence);
            }

        }

    }
}
