using Gc.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gc.Db
{
   public class SqlDb
    {
       #region Constants and Fields 

       /// <summary>
       /// 数据库类型
       /// </summary>
       public virtual GcEnumDbType dbType {get;set;}

       /// <summary>
       /// 数据库对应参数关键字
       /// </summary>
       public virtual string dbPramStr {get;set;}

       /// <summary>
       /// 数据为操作对象
       /// </summary>
       public DbBase dbBase { get; set; }

       #endregion

       #region Public Methods

       /// <summary>
       /// 构造函数
       /// </summary>
       public SqlDb()
       {
           dbType = GcEnumDbType.MsSql;
           dbPramStr = new DbOperator(dbType).CreateDbParameterStr();
           dbBase = new DbBase(dbType);
       }

       /// <summary>
       /// 执行增、删、改操作,返回影响行数--create by joyet
       /// </summary>
       /// <param name="connectionStr">数据库字符串连接</param>
       /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
       /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
       /// <param name="dbParams">数据库参数数组</param>
       /// <returns>int</returns>
       public virtual int Execute(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, IDbDataParameter[] dbParams = null)
       {
           int result = 0;
            try
            {
                result = dbBase.Execute(connectionStr, cmdText, cmdType, dbParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
       }

        /// <summary>
        /// 执行增、删、改操作,返回影响行数--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">SQL语句/参数化SQL语句/存储过程</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="objParam">object参数</param>
        /// <returns>int</returns>
       public virtual int ExecuteWithParam(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, object objParam = null)
       {
           int result = 0;
            try
            {
                result = dbBase.ExecuteWithParam(connectionStr, cmdText, cmdType, objParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
       }

        /// <summary>
        /// 执行查询操作,返回DataSet--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接></param>
        /// <param name="cmdText">SQL语句/参数化SQL语句/存储过程</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="dbParams">数据库参数数组</param>
        /// <returns>DataSet</returns>
        public virtual DataSet ExecuteQuery(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, IDbDataParameter[] dbParams = null)
        {
            DataSet result;
            try
            {
                result = dbBase.ExecuteQuery(connectionStr, cmdText, cmdType, dbParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行查询操作,返回DataSet--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">SQL语句/参数化SQL语句/存储过程</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="param">object参数</param>
        /// <returns>DataSet</returns>
        public virtual DataSet ExecuteQueryWithParam(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, object objParam = null)
        {
            DataSet result;
            try
            {
                result = dbBase.ExecuteQueryWithParam(connectionStr, cmdText, cmdType, objParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行查询操作,返回IDataReader--create by joyet
        /// </summary>
        /// <param name="connectionStr"数据库字符串连接></param>
        /// <param name="cmdText">SQL语句/参数化SQL语句/存储过程</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="dbParams">数据库参数数组</param>
        /// <returns>IDataReader</returns>
        public virtual IDataReader ExecuteReader(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, IDbDataParameter[] dbParams = null)
        {
            IDataReader result;
            try
            {
                result = dbBase.ExecuteReader(connectionStr, cmdText, cmdType, dbParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行查询操作,返回IDataReader--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">SQL语句/参数化SQL语句/存储过程</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="objParam">object参数</param>
        /// <returns>IDataReader</returns>
        public virtual IDataReader ExecuteReaderWithParam(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, object objParam = null)
        {
            IDataReader result;
            try
            {
                result = dbBase.ExecuteReaderWithParam(connectionStr, cmdText, cmdType, objParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行查询操作,返回object--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">SQL语句/参数化SQL语句/存储过程</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="dbParams">数据库参数数组</param>
        /// <returns>object</returns>
        public virtual object ExecuteScalar(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, IDbDataParameter[] dbParams = null)
        {
            object result;
            try
            {
                result = dbBase.ExecuteScalar(connectionStr, cmdText, cmdType, dbParams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行查询操作,返回object--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">SQL语句/参数化SQL语句/存储过程</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="objParam">object参数</param>
        /// <returns>object</returns>
        public virtual object ExecuteScalarWithParam(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, object objParam = null)
        {
            object result;
            try
            {
                result = dbBase.ExecuteScalarWithParam(connectionStr, cmdText, cmdType, objParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

       
        /// <summary>
        /// 执行添加操作,返回object(如果设置获取自动增长值,返回为自动增长值,否则返回值为影响行数)--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="t">实体模型实例化对象</param>
        /// <returns>object</returns>
        public virtual object Insert<T>(string connectionStr, T t)
        {
            object result = null;
            try
            {
                #region  初始相关变量定义
                var dbBase = new DbBase(dbType);
                bool isHaveColumn = false;
                bool isGetIdentityValue = false;
                List<EntityColumn> noneIdentityColumns = null;
                #endregion

                #region 获取字段名称、值
                List<EntityColumn> columnList = new EntityColumnUtility().GetColumnList<T>(t);
                if (columnList != null && columnList.Count > 0)
                {
                    var identityList = (from p in columnList where (p.IsIdentity==true&&p.IsGetIdentityValue==true) select p).ToList<EntityColumn>();
                    if (identityList != null && identityList.Count > 0)
                    {
                        isGetIdentityValue = true;
                    }
                    var noneIdentityColumnList = (from p in columnList where (p.IsIdentity == false) select p).ToList<EntityColumn>();
                    if (noneIdentityColumnList != null && noneIdentityColumnList.Count > 0)
                    {
                        isHaveColumn = true;
                        noneIdentityColumns = noneIdentityColumnList;
                    }
                }
                #endregion

                #region 拼接SQL及对数据库操作
                if (isHaveColumn)
                {
                    #region 模板及相关变量定义
                    Type type = typeof(T);
                    string tableName = type.Name;
                    string tmpColumnNames = "[[ColumnNames]]";
                    string tmpColumnValues = "[[ColumnValues]]";
                    List<IDbDataParameter> dbParamList = new List<IDbDataParameter>();
                    StringBuilder fieldStr = new StringBuilder();
                    StringBuilder paramStr = new StringBuilder();
                    StringBuilder sqlBuild = new StringBuilder();
                    sqlBuild.AppendFormat("insert into {0}({1}) values({2});", tableName, tmpColumnNames, tmpColumnValues);
                    #endregion

                    #region 对非自动增长字段操作
                    int i = 0;
                    foreach (EntityColumn column in noneIdentityColumns)
                    {
                        fieldStr.Append(column.ColumnName);
                        paramStr.Append(dbPramStr + column.ColumnName);
                        if (i != (noneIdentityColumns.Count - 1))
                        {
                            fieldStr.Append(",");
                            paramStr.Append(",");
                        }
                        var dbParam = new DbOperator(dbType).CreateDbParameter(column.ColumnName, column.ColumnValue);
                        dbParamList.Add(dbParam);
                        i++;
                    }
                    sqlBuild.Replace(tmpColumnNames, fieldStr.ToString());
                    sqlBuild.Replace(tmpColumnValues, paramStr.ToString());
                    #endregion

                    #region 对要获取自动增长字段操作
                    if (isGetIdentityValue)
                    {
                        if ((int)dbType == (int)GcEnumDbType.MsSql)
                        {
                            sqlBuild.Append("select @@identity;");
                        }
                        else if ((int)dbType == (int)GcEnumDbType.MsSql)
                        {
                            sqlBuild.Append("select @@identity;");
                        }
                        result = ExecuteScalar(connectionStr, sqlBuild.ToString(), CommandType.Text, dbParamList.ToArray());
                    }
                    else
                    {
                        result = Execute(connectionStr, sqlBuild.ToString(), CommandType.Text, dbParamList.ToArray());
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行删除数据操作,返回影响行数--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="Id">主键值</param>
        /// <returns>int</returns>
        public virtual int Delete<T>(string connectionStr, object Id)
        {
            int result = 0;
            try
            {
                EntityColumn column = new EntityColumnUtility().GetIdColumn<T>(Id);
                if (column != null)
                {
                    Type type = typeof(T);
                    string tableName = type.Name;
                    List<IDbDataParameter> dbParamList = new List<IDbDataParameter>();
                    StringBuilder cmdText = new StringBuilder();
                    cmdText.AppendFormat("delete from {0} where {1}={2}", tableName, column.ColumnName, dbPramStr + column.ColumnName);
                    IDbDataParameter[] dbParameters = {
                      new DbOperator(dbType).CreateDbParameter(column.ColumnName, column.ColumnValue)
                    };
                    result = Execute(connectionStr, cmdText.ToString(), CommandType.Text, dbParameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行编辑操作,返回影响行数--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="t">实体模型实例化对象</param>
        /// <returns>int</returns>
        public virtual int Update<T>(string connectionStr, T t)
        {
            int result = 0;
            try
            {
                #region 初始相关变量定义
                var dbOperator = new DbOperator(dbType);
                EntityColumn idColumn = null;
                List<EntityColumn> noneIdColumnList = null;
                bool isHaveColumn = false;
                bool isHaveId= false;
                #endregion

                #region 获取字段名称、值
                List<EntityColumn> columnList = new EntityColumnUtility().GetColumnList<T>(t);
                if (columnList != null && columnList.Count > 0)
                {
                    var idList = (from p in columnList where p.IsPk==true select p).ToList<EntityColumn>();
                    if (idList != null && idList.Count > 0)
                    {
                        isHaveId = true;
                        idColumn = idList[0];
                    }
                    var noneIdList = (from p in columnList where p.IsPk == false select p).ToList<EntityColumn>();
                    if (noneIdList != null && noneIdList.Count > 0)
                    {
                        isHaveColumn = true;
                        noneIdColumnList = noneIdList;
                    }
                }
                #endregion

                #region 拼接SQL及对数据库操作
                if (isHaveColumn&&isHaveId)
                {
                    Type type = typeof(T);
                    string tableName = type.Name;
                    StringBuilder cmdText = new StringBuilder();
                    cmdText.AppendFormat("update {0} set ", tableName);
                    List<IDbDataParameter> dbParamList = new List<IDbDataParameter>();
                    for (int i = 0; i < noneIdColumnList.Count; i++)
                    {
                        EntityColumn column = noneIdColumnList[i];
                        cmdText.AppendFormat("{0}={1}", column.ColumnName, dbPramStr + column.ColumnName);
                        if (i != (noneIdColumnList.Count - 1))
                        {
                            cmdText.Append(",");
                        }
                        var dbParam = dbOperator.CreateDbParameter(column.ColumnName, column.ColumnValue);
                        dbParamList.Add(dbParam);
                    }
                    cmdText.AppendFormat(" where {0}={1}", idColumn.ColumnName, dbPramStr + idColumn.ColumnName);
                    var idDbParam = dbOperator.CreateDbParameter(idColumn.ColumnName, idColumn.ColumnValue);
                    dbParamList.Add(idDbParam);
                    result = Execute(connectionStr, cmdText.ToString(), CommandType.Text, dbParamList.ToArray());
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 根据实体主键值查询数据,返回单个实体对象--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="Id">主键值</param>
        /// <returns>T</returns>
        public virtual T Find<T>(string connectionStr, object Id)
        {
            T result = default(T);
            try
            {
                EntityColumn column = new EntityColumnUtility().GetIdColumn<T>(Id);
                if (column != null)
                {
                    var dbBase = new DbBase(dbType);
                    Type type = typeof(T);
                    string tableName = type.Name;
                    StringBuilder cmdText = new StringBuilder();
                    cmdText.AppendFormat("select * from {0} where {1}={2}", tableName, column.ColumnName, dbPramStr + column.ColumnName);
                    IDbDataParameter[] dbParameters = {
                       new DbOperator(dbType).CreateDbParameter(column.ColumnName,column.ColumnValue)
                     };
                    IDataReader read = ExecuteReader(connectionStr, cmdText.ToString(), CommandType.Text, dbParameters);
                    if (read != null)
                    {
                        List<T> list = new List<T>();
                        DataReaderUtility<T> readBuild = DataReaderUtility<T>.GetInstance(read);
                        if(read.Read())
                        {
                            var entity = readBuild.Map(read);
                            list.Add(entity);
                        }
                        if (list.Count > 0)
                        {
                            result = list[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行查询数据操作,返回泛型列表--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="sqlWhere">参数化/非参数化查询条件</param>
        /// <param name="orderFilter">排序条件</param>
        /// <param name="objParam">object参数</param>
        /// <returns>List<T></returns>
        public virtual List<T> Select<T>(string connectionStr, string sqlWhere, string orderFilter, object objParam)
        {
            List<T> result = null;
            try
            {
                IDataReader read;
                Type type = typeof(T);
                string tableName = type.Name;
                StringBuilder cmdText = new StringBuilder();
                cmdText.AppendFormat("select * from [{0}] ", tableName);
                if (!string.IsNullOrEmpty(sqlWhere))
                {
                    cmdText.Append(" where " + sqlWhere);
                }
                if (!string.IsNullOrEmpty(orderFilter))
                {
                    cmdText.Append(" order by " + orderFilter);
                }
                if (objParam != null)
                {
                    read = ExecuteReaderWithParam(connectionStr, cmdText.ToString(), CommandType.Text, objParam);
                }
                else
                {
                    read = ExecuteReader(connectionStr, cmdText.ToString(), CommandType.Text, null);
                }
                if (read != null)
                {
                    result = new List<T>();
                    DataReaderUtility<T> readBuild = DataReaderUtility<T>.GetInstance(read);
                    while (read.Read())
                    {
                        result.Add(readBuild.Map(read));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行查询数据操作,返回泛型列表--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">参数化/非参数化SQL语句/存储过程</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="objParam">object参数</param>
        /// <returns>List<T></returns>
        public virtual List<T> Select<T>(string connectionStr, string cmdText, CommandType cmdType, object objParam)
        {
            List<T> result = null;
            try
            {
                IDataReader read;
                if (!string.IsNullOrEmpty(cmdText))
                {
                    if (objParam != null)
                    {
                        read = ExecuteReaderWithParam(connectionStr, cmdText, cmdType, objParam);
                    }
                    else
                    {
                        read = ExecuteReader(connectionStr, cmdText, cmdType, null);
                    }
                    if (read != null)
                    {
                        result = new List<T>();
                        DataReaderUtility<T> readBuild = DataReaderUtility<T>.GetInstance(read);
                        while (read.Read())
                        {
                            result.Add(readBuild.Map(read));
                        }
                    }
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 执行分页数据查询操作,返回PageResponseData--create by joyet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connectionStr"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual PageResponseData GetPageList<T>(string connectionStr, PageRequestData request)
        {
            PageResponseData dataResult = new PageResponseData();
            return dataResult;
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        public virtual void StartTrans()
        {
            try
            {
                dbBase.StartTrans();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 关闭事务
        /// </summary>
        public virtual void CloseTrans()
        {
            try
            {
                dbBase.CloseTrans();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       #endregion
    }
}
