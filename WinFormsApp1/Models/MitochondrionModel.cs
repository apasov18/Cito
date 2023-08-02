using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cito.Models
{
    public class MitochondrionModel
    {

        [JsonPropertyName("style")]
        public StyleModel? Style { get; set; }
      
    }
}
