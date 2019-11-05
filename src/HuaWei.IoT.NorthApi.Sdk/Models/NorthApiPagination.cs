namespace HuaWei.IoT.NorthApi.Sdk.Models
{
    /// <summary>
    /// 分页信息
    /// </summary>
    public class NorthApiPagination
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// 每页信息数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int TotalSize { get; set; }
    }
}
