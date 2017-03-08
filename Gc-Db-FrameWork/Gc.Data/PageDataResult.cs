using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gc.Data
{
    /// <summary>
    /// 分页基模型
    /// </summary>
    public class BasePageModel
    {
        /// <summary>
        /// 当前第几页
        /// </summary>
        public virtual int PageIndex { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public virtual int PageSize { get; set; }

         /// <summary>
        /// 构造函数
        /// </summary>
        public BasePageModel()
        {
            PageIndex = 1;
            PageSize = 10;
        }
    }

    /// <summary>
    /// 分页请求结果模型
    /// </summary>
    public class PageRequestData : BasePageModel
    {
        /// <summary>
        /// 分页查询SQL Where条件
        /// </summary>
        public string SqlWhere { get; set; }

        /// <summary>
        /// 分页查询SQL Where参数
        /// </summary>
        public object SqlWhereParam { get; set; }

        /// <summary>
        /// 分页排序字段
        /// </summary>
        public string OrderColumn { get; set; }

        /// <summary>
        /// 字段排序方式
        /// </summary>
        public string OrderSort { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PageRequestData()
        {
            SqlWhere = string.Empty;
            SqlWhereParam = null;
            OrderColumn = string.Empty;
            OrderSort = string.Empty;
        }
    }

    /// <summary>
    /// 分页返回结果模型
    /// </summary>
    public class PageResponseData : BasePageModel
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalIndex { get; set; }

        /// <summary>
        /// 总记录结果数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PageResponseData()
        {
            TotalIndex = 0;
            TotalCount = 0;
            Data = null;
        }
    }
}
