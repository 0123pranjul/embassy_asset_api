namespace EmbassyAassetManagementAPI.Models.DTO
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
        public int? Orderby { get; set; }
        public List<MenuDto> Children { get; set; } = new List<MenuDto>();
    }
}
