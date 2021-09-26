using ACTFoundation.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Shared
{
    public class VolunteersViewModel
    {
        public VolunteersViewModel(Volunteers volunteers)
        {
                Volunteers = volunteers?.VolunteersContent?.Select(item => new VolunteersSharedViewModel(item as VolunteersShared)) ?? Array.Empty<VolunteersSharedViewModel>();
        }

        public IEnumerable<VolunteersSharedViewModel> Volunteers { get; }
    }
}
