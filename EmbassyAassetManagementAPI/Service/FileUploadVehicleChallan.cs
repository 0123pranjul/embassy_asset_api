using EmbassyAassetManagementAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmbassyAassetManagementAPI.Service
{
    public class FileUploadVehicleChallan
    {
        public IFormFile? photofiles { get; set; }
        public IFormFile? videofiles { get; set; }
        public IFormFile? audiofiles { get; set; }
    }

    public class Base64FileDto
    {
        public string FileName { get; set; } = "";
        public string ContentType { get; set; } = "";
        public string Base64Data { get; set; } = "";
    }

    public class TaxRequestDto
    {
  
        public List<Base64FileDto> Files { get; set; }
    }
  
}
