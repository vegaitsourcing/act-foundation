using ACTFoundation.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ACTFoundation.Core.ViewModels.Partials.Layout
{
    public class PartnerLogosViewModel
    {
        public PartnerLogosViewModel(PartnerLogosItem partnerLogos)
        {
            this.PartnerLogos = partnerLogos.PartnerLogos;
        }

        public IEnumerable<MediaWithCrops> PartnerLogos { get; }

    }
}
