using EmbassyAassetManagementAPI.Interface;
using EmbassyAassetManagementAPI.Models;
using EmbassyAassetManagementAPI.Service;
using Microsoft.EntityFrameworkCore;
using EmbassyAassetManagementAPI.Models;

namespace EmbassyAassetManagementAPI.Repository
{
    public class DataClass: Idata
    {
        private readonly EmbassyAssetManagementContext _context;

        public DataClass(EmbassyAssetManagementContext context )
        {
            this._context = context;
        }
        public async Task<ReturnData<List<TblUserMaster>>> GetAllUserDetails()
        {

            ReturnData<List<TblUserMaster>> rtd = new();
            try
            {
              
                var d = await _context.TblUserMasters.AsNoTracking().ToListAsync();

                rtd.IsSuccess = true;
                rtd.Data = d;
                rtd.Mesg = "All Data ";
            }

            catch (Exception ex)
            {
                rtd.IsSuccess = false;
                rtd.Mesg = ex.Message + ";" + ex.InnerException ?? ex.InnerException.Message;
                return rtd;
            }

            return rtd;
        }

    }
}
