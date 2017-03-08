using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Gc.Data;

namespace Gc.Db
{
    public interface ISqlDb
    {
       #region abstact Methods

       /// <summary>
       /// 执行增、删、改操作,返回影响行数--create by joyet
       /// </summary>
       /// <param name="connectionStr">数据库字符串连接</param>
       /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
       /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
       /// <param name="dbParams">数据库参数数组</param>
        /// <returns>int</returns>
       int Execute(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, IDbDataParameter[] dbParams = null);

       /// <summary>
       /// 执行增、删、改操作,返回影响行数--create by joyet
       /// </summary>
       /// <param name="connectionStr">数据库字符串连接</param>
       /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
       /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
       /// <param name="objParam">object参数</param>
       /// <returns>int</returns>
       int ExecuteWithParam(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, object objParam = null);
      
        /// <summary>
        /// 执行查询操作,返回DataSet--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接></param>
        /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="dbParams">数据库参数数组</param>
       /// <returns>DataSet</returns>
       DataSet ExecuteQuery(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, IDbDataParameter[] dbParams = null);
       
        /// <summary>
        /// 执行查询操作,返回DataSet--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="param">object参数对象</param>
       /// <returns>DataSet</returns>
        DataSet ExecuteQueryWithParam(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, object objParam = null);
       
        /// <summary>
        /// 执行查询操作,返回IDataReader--create by joyet
        /// </summary>
        /// <param name="connectionStr"数据库字符串连接></param>
        /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="dbParams">数据库参数数组</param>
        /// <returns>IDataReader</returns>
        IDataReader ExecuteReader(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, IDbDataParameter[] dbParams = null);
       
        /// <summary>
        /// 执行查询操作,返回IDataReader--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="objParam">object参数</param>
        /// <returns>IDataReader</returns>
        IDataReader ExecuteReaderWithParam(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, object objParam = null);
       
        /// <summary>
        /// 执行查询操作,返回object--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="dbParams">数据库参数数组</param>
        /// <returns>object</returns>
        object ExecuteScalar(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, IDbDataParameter[] dbParams = null);
       
        /// <summary>
        /// 执行查询操作,返回object--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="objParam">object参数</param>
        /// <returns>object</returns>
        object ExecuteScalarWithParam(string connectionStr, string cmdText, CommandType cmdType = CommandType.Text, object objParam = null);

        /// <summary>
        /// 执行添加操作,返回object(如果设置获取自动增长值,返回为自动增长值,否则返回值为影响行数)--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="t">实体模型实例化对象</param>
        /// <returns>object</returns>
        object Insert<T>(string connectionStr, T t);
       
        /// <summary>
        /// 执行删除数据操作,返回影响行数--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="Id">主键值</param>
        /// <returns>int</returns>
        int Delete<T>(string connectionStr, object Id);
       
        /// <summary>
        /// 执行编辑操作,返回影响行数--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="t">实体模型实例化对象</param>
        /// <returns>int</returns>
        int Update<T>(string connectionStr, T t);
       
        /// <summary>
        /// 根据实体主键值查询数据,返回单个实体对象--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="Id">主键值</param>
        /// <returns>T</returns>
        T Find<T>(string connectionStr, object Id);
       
        /// <summary>
        /// 执行查询数据操作,返回泛型列表--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="sqlWhere">参数化/非参数化查询条件</param>
        /// <param name="orderFilter">排序条件</param>
        /// <param name="objParam">object参数</param>
        /// <returns>List<T></returns>
        List<T> Select<T>(string connectionStr, string sqlWhere, string orderFilter,object objParam);

        /// <summary>
        /// 执行查询数据操作,返回泛型列表--create by joyet
        /// </summary>
        /// <typeparam name="T">实体模型名称</typeparam>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">参数化/非参数化SQL语句/存储过程</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="objParam">object参数</param>
        /// <returns>List<T></returns>
        List<T> Select<T>(string connectionStr, string cmdText, CommandType cmdType, object objParam);

        /// <summary>
        /// 执行分页数据查询操作,返回PageResponseData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connectionStr"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        PageResponseData GetPageList<T>(string connectionStr, PageRequestData request);

        /// <summary>
        /// 开启事务
        /// </summary>
        void StartTrans();
       
        /// <summary>
        /// 关闭事务
        /// </summary>
        void CloseTrans();
      
        #endregion
    }
}
