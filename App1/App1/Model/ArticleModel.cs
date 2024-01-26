using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class ArticleModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string news_site { get; set; }
        public string summary { get; set; }
        public DateTime published_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool featured { get; set; }
        public object[] launches { get; set; }
        public object[] events { get; set; }

        public override string ToString()
        {
            return $"{id + " - "+ title}";
        }
    }
}
