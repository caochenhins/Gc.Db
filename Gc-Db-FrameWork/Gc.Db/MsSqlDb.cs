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
        #region Constants and Fields

        /// <summary>
        /// 数据库类型
        /// </summary>
        public override GcEnumDbType dbType { get; set; }

        /// <summary>
        /// 数据库对应参数关键字
        /// </summary>
        public override string dbPramStr { get; set; }

        #endregion

        #region Public Methods


        /// <summary>
       /// 构造函数
       /// </summary>
       public MsSqlDb()
       {
           dbType = GcEnumDbType.MsSql;
           dbPramStr = new DbOperator(dbType).CreateDbParameterStr();
       }

        /// <summary>
        /// 执行分页数据查询操作,返回PageResponseData--create by joyet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connectionStr"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public override PageResponseData GetPageList<T>(string connectionStr, PageRequestData request) 
        {
            PageResponseData dataResult = new PageResponseData();
            try
            {
                #region 相关变量定义
                var dbBase = new DbBase(dbType);
                Type type = typeof(T);
                string tableName = type.Name;
                int startNum = request.PageSize * (request.PageIndex - 1) + 1;
                int endNum = request.PageSize * request.PageIndex;
                #endregion

                #region 查询总条数
                if (string.IsNullOrEmpty(request.OrderColumn) && string.IsNullOrEmpty(request.OrderSort))
                {
                    EntityColumn column = new EntityColumnUtility().GetIdColumn<T>(null);
                    if (column != null)
                    {
                        request.OrderColumn = column.ColumnName;
                        request.OrderSort = "asc";
                    }
                }
                StringBuilder commonFilter = new StringBuilder();
                commonFilter.AppendFormat(" from {0}  ", tableName);
                if (!string.IsNullOrEmpty(request.SqlWhere))
                {
                    commonFilter.AppendFormat(" where {0} ", request.SqlWhere);
                }
                StringBuilder countSql = new StringBuilder("select count(*)  ");
                countSql.AppendFormat(commonFilter.ToString());
                object totalNumObj = dbBase.ExecuteScalar(connectionStr, countSql.ToString(), CommandType.Text, null);
                if (totalNumObj != null)
                {
                    dataResult.TotalCount = Convert.ToInt32(totalNumObj);
                }
                #endregion

                #region 分页查询处理
                if (dataResult.TotalCount > 0)
                {
                    StringBuilder pageSql = new StringBuilder("select b.*  from ");
                    pageSql.Append("(");
                    pageSql.AppendFormat("select ROW_NUMBER() over(order by {0} {1}) num,{0} ", request.OrderColumn, request.OrderSort);
                    pageSql.AppendFormat(commonFilter.ToString());
                    pageSql.Append(") ");
                    pageSql.AppendFormat("a inner join {0} b on a.{1}=b.{1} and  a.num between {2} and {3} ", tableName, request.OrderColumn, startNum, endNum);
                    IDataReader dataReader;
                    if (request.SqlWhereParam != null)
                    {
                        dataReader = dbBase.ExecuteReaderWithParam(connectionStr, pageSql.ToString(), CommandType.Text, request.SqlWhereParam);
                    }
                    else
                    {
                        dataReader = dbBase.ExecuteReader(connectionStr, pageSql.ToString(), CommandType.Text, null);
                    }
                    if (dataReader != null)
                    {
                        List<T> list = new List<T>();
                        DataReaderUtility<T> readBuild = DataReaderUtility<T>.GetInstance(dataReader);
                        while (dataReader.Read())
                        {
                            list.Add(readBuild.Map(dataReader));
                        }
                        dataResult.Data = list;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataResult;
        }

        #endregion

    }
}
