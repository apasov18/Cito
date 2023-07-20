using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cito.Models
{
    internal class CellModel
    {
        [JsonPropertyName("life")]
        public double Life{ get; set; }


        [JsonPropertyName("style")]
        public StyleModel Style { get; set; }


        [JsonPropertyName("mitochondrions")]
        public List<MitochondrionModel> Mitochondrion { get; set; }

        [JsonPropertyName("lysosomes")]
        public List<LysosomeModel> Lysosomes { get; set; }


    }
}
