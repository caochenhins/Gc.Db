using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Gc.Data;

namespace Gc.Db
{
    public class MsSqlDb:SqlDb,ISqlDb
    {

        #region Public Methods

        /// <summary>
       /// 构造函数
       /// </summary>
       public MsSqlDb()
       {
           DbType = GcEnumDbType.MsSql;
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
                int startNum = pageRequest.PageSize * (pageRequest.PageIndex - 1) + 1;
                int endNum = pageRequest.PageSize * pageRequest.PageIndex;
                var searchEntity = pageRequest.SearchEntityObj;
                #endregion

                #region 分页查询处理
                EntityColumn idColumn = new EntityColumnUtility().GetIdColumn<T>(null);
                if (idColumn != null)
                {
                    responsResult.TotalCount = GetCount<T>(connectionStr, searchEntity);
                    if (responsResult.TotalCount > 0)
                    {
                        if (string.IsNullOrEmpty(searchEntity.ColumnSql))
                        {
                            searchEntity.ColumnSql = "b.*";
                        }
                        if (string.IsNullOrEmpty(searchEntity.SortColumn))
                        {
                            searchEntity.SortColumn = idColumn.ColumnName;
                            searchEntity.SortMethod = "asc";
                        }
                        StringBuilder cmdText = new StringBuilder();
                        cmdText.AppendFormat("select {0}  from ", searchEntity.ColumnSql);
                        cmdText.Append("(");
                        cmdText.AppendFormat("select ROW_NUMBER() over(order by {0} {1}) num,{2}  from {3} ", searchEntity.SortColumn, searchEntity.SortMethod,idColumn.ColumnName ,tableName);
                        if (!string.IsNullOrEmpty(searchEntity.WhereSql))
                        {
                            cmdText.AppendFormat("where {0} ", searchEntity.WhereSql);
                        }
                        cmdText.Append(") ");
                        cmdText.AppendFormat("a inner join {0} b on a.{1}=b.{1} and  a.num between {2} and {3} ", tableName,idColumn.ColumnName, startNum, endNum);
                        IDataReader dataReader;
                        if (searchEntity.WhereParam != null)
                        {
                          dataReader = SqlDbBase.ExecuteReaderWithParam(connectionStr, cmdText.ToString(), CommandType.Text, searchEntity.WhereParam);
                        }
                        else
                        {
                          dataReader = SqlDbBase.ExecuteReader(connectionStr, cmdText.ToString(), CommandType.Text, null);
                        }
                        responsResult.Data=Map<T>(dataReader);
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
