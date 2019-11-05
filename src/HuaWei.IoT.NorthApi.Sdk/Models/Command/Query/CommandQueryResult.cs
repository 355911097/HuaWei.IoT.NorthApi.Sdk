using System.Collections.Generic;

namespace HuaWei.IoT.NorthApi.Sdk.Models.Command.Query
{
    /// <summary>
    /// 命令查询结果
    /// </summary>
    public class CommandQueryResult
    {
        /// <summary>
        /// 页面信息。
        /// </summary>
        public NorthApiPagination Pagination { get; set; }

        /// <summary>
        /// 设备命令列表
        /// </summary>
        public List<CommandModel> Data { get; set; }
    }
}
