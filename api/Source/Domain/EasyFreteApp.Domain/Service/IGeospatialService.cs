using EasyFreteApp.Presentation.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyFreteApp.Domain.Service
{
    public interface IGeospatialService
    {
        Task<GeospatialDomain> Geocode(string searchtext);
    }
}
