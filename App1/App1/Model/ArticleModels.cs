using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class ArticleModels
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public ArticleModel[] results {get;set;}
    }
}
