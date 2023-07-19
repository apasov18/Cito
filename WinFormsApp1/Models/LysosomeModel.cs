using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cito.Models
{
    internal class LysosomeModel
    {

        [JsonPropertyName("style")]
        public StyleModel? Style { get; set; }
      
    }
}
