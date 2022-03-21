using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Shared;
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
            PartnerLinks = partnerLogos.PartnerLinks.ToViewModel();
        }

        public IEnumerable<MediaWithCrops> PartnerLogos { get; }
        public IEnumerable<LinkViewModel> PartnerLinks { get; }

    }
}
