using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sca_Backend_v2.Models
{
    public class DecryptAndVerifyDetail
    {
        public int[] LineItemId { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
    }
}
