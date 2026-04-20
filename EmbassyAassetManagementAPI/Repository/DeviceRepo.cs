using EmbassyAassetManagementAPI.Interface;
using EmbassyAassetManagementAPI.Models;
using EmbassyAassetManagementAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmbassyAassetManagementAPI.Models;

namespace EmbassyAassetManagementAPI.Repository
{
    public class DeviceRepo : IDevice
    {
        private readonly EmbassyAssetManagementContext _context;

        public DeviceRepo(EmbassyAssetManagementContext context)
        {
            this._context = context;
        }

       

    }
}
