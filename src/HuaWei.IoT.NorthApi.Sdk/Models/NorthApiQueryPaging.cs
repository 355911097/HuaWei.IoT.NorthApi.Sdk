using System;

namespace HuaWei.IoT.NorthApi.Sdk.Models
{
    /// <summary>
    /// 查询分页信息
    /// </summary>
    public class NorthApiQueryPaging
    {
        /// <summary>
        /// 分页查询参数，查询结果分页显示时指定要查看的页信息，默认0，查询第一页，取值范围为大于等于0的整数。
        /// <para>可选</para>
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// 分页查询参数，查询结果分页显示时每页显示的记录数，默认值为25，取值范围为1-250的整数。
        /// <para>可选</para>
        /// </summary>
        public int PageSize { get; set; } = 25;

        /// <summary>
        /// 查询注册设备信息时间在startTime之后的记录
        /// <para>可选</para>
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 查询注册设备信息时间在endTime之前的记录
        /// <para>可选</para>
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 指定返回记录的排序。缺省值：DESC。
        /// <para>ASC：按注册设备的时间升序排列</para>
        /// <para>DESC：按注册设备的时间降序排列</para>
        /// <para>可选</para>
        /// </summary>
        public string Sort { get; set; } = "DESC";
    }
}
