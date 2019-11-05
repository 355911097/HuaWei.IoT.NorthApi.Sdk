namespace HuaWei.IoT.NorthApi.Sdk.Models
{
    /// <summary>
    /// 查询结果
    /// </summary>
    public class NorthApiQueryResult
    {
        /// <summary>
        /// 查询的记录数量。
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 查询的页码。
        /// </summary>
        public long PageNo { get; set; }

        /// <summary>
        /// 查询每页信息的数量。
        /// </summary>
        public long PageSize { get; set; }
    }
}
