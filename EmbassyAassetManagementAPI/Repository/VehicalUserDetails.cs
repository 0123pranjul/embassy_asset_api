using EmbassyAassetManagementAPI.Interface;
using EmbassyAassetManagementAPI.Models;
using EmbassyAassetManagementAPI.Models.DTO;
using EmbassyAassetManagementAPI.Service;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmbassyAassetManagementAPI.Models;

namespace EmbassyAassetManagementAPI.Repository
{
    public class VehicalUserDetails : IVehicalUserDetails
    {
        private readonly EmbassyAssetManagementContext _context;

        public VehicalUserDetails(EmbassyAssetManagementContext context)
        {
            this._context = context;
        }

      
      






 
    }
}
