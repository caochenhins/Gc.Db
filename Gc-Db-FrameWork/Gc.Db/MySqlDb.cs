using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Gc.Data;

namespace Gc.Db
{
    public class MySqlDb : SqlDb, ISqlDb
    {
        #region Public Methods

        /// <summary>
       /// 构造函数
       /// </summary>
        public MySqlDb()
       {
           DbType = GcEnumDbType.MySql;
           DbInsInit();
       }

        /// <summary>
        /// 执行分页数据查询操作,返回PageResponseData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connectionStr"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public override PageResponseData GetPageList<T>(string connectionStr, PageRequestData pageRequest)
        {
            PageResponseData responsResult = new PageResponseData();
            try
            {
                #region 相关变量定义
                Type type = typeof(T);
                string tableName = type.Name;
                int startNum = pageRequest.PageSize * (pageRequest.PageIndex - 1);
                var searchEntity = pageRequest.SearchEntityObj;
                #endregion

                #region 分页查询处理
                 EntityColumn idColumn = new EntityColumnUtility().GetIdColumn<T>(null);
                 if (idColumn != null)
                 {
                     //查询记录结果数
                     responsResult.TotalCount = GetCount<T>(connectionStr, searchEntity);
                     if (responsResult.TotalCount > 0)
                     {
                         StringBuilder cmdText = new StringBuilder();
                         if (string.IsNullOrEmpty(searchEntity.ColumnSql))
                         {
                             searchEntity.ColumnSql = "*";
                         }
                         if (string.IsNullOrEmpty(searchEntity.SortColumn))
                         {
                             searchEntity.SortColumn = idColumn.ColumnName;
                         }
                         cmdText.AppendFormat("select {0} from {1} ", searchEntity.ColumnSql, tableName);
                         if (string.IsNullOrEmpty(searchEntity.WhereSql))
                         {
                             cmdText.AppendFormat("where {0} ", searchEntity.WhereSql);
                         }
                         cmdText.AppendFormat("order by {0} {1} ", searchEntity.SortColumn, searchEntity.SortMethod);
                         cmdText.AppendFormat("limit {0},{1} ", startNum, pageRequest.PageSize);
                         IDataReader dataReader;
                         if (searchEntity.WhereParam != null)
                         {
                             dataReader = SqlDbBase.ExecuteReaderWithParam(connectionStr, cmdText.ToString(), CommandType.Text, searchEntity.WhereParam);
                         }
                         else
                         {
                             dataReader = SqlDbBase.ExecuteReader(connectionStr, cmdText.ToString(), CommandType.Text, null);
                         }
                         responsResult.Data = Map<T>(dataReader);
                     }
                 }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return responsResult;
        }

        #endregion
    }
}
