using EmbassyAassetManagementAPI.Models;
using EmbassyAassetManagementAPI.Service;
using EmbassyAassetManagementAPI.Models;

namespace EmbassyAassetManagementAPI.Interface
{
    public interface Idata
    {
        public Task<ReturnData<List<TblUserMaster>>> GetAllUserDetails();
    }
}
