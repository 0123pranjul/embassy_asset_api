namespace EmbassyAassetManagementAPI.Service
{
    public class ReturnData<T>
    {
        public bool IsSuccess { get; set; }
        public bool InternalSuccess { get; set; }
        public string? Mesg { get; set; }
        public T? Data { get; set; }
    }
}
