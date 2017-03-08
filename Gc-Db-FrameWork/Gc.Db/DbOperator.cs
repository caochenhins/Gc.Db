using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Collections;
using Gc.Data;

namespace Gc.Db
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum GcEnumDbType
    {
        MsSql = 1,
        Oracle = 2,
        MySql = 3,
        OleDb = 4
    }

    public class DbOperator
    {

        #region Constants and Fields

        /// <summary>
        /// 数据库类型
        /// </summary>
        public GcEnumDbType dbType { get; set; }

        #endregion


        #region public method

        /// <summary>
        /// 创建数据库连接对象--create by joyet
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public  IDbConnection CreateConnection(string connectionString)
        {
            int dbTypeValue = (int)dbType;
            IDbConnection conn = null;
            switch (dbTypeValue)
            {
                case 1:
                    conn = new SqlConnection(connectionString);
                    break;

                case 2:
                    conn = new OracleConnection(connectionString);
                    break;

                case 3:
                    conn = new MySqlConnection(connectionString);
                    break;

                case 4:
                    conn = new OleDbConnection(connectionString);
                    break;
            }
            return conn;
        }

        /// <summary>
        /// 创建DbCommand对象--create by joyet
        /// </summary>
        /// <returns></returns>
        public  IDbCommand CreateCommand()
        {
            int dbTypeValue = (int)dbType;
            IDbCommand cmd = null;
            switch (dbTypeValue)
            {
                case 1:
                    cmd = new SqlCommand();
                    break;

                case 2:
                    cmd = new OracleCommand();
                    break;

                case 3:
                    cmd = new MySqlCommand();
                    break;

                case 4:
                    cmd = new OleDbCommand();
                    break;
            }
            return cmd;
        }

        /// <summary>
        /// 创建适配器对象--create by joyet
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public  IDataAdapter CreateDataAdapter(IDbCommand cmd)
        {
            int dbTypeValue = (int)dbType;
            IDataAdapter dataAdater = null;
            switch (dbTypeValue)
            {
                case 1:
                    dataAdater = new SqlDataAdapter((SqlCommand)cmd);
                    break;

                case 2:
                    dataAdater = new OracleDataAdapter((OracleCommand)cmd);
                    break;

                case 3:
                    dataAdater = new MySqlDataAdapter((MySqlCommand)cmd);
                    break;

                case 4:
                    dataAdater = new OleDbDataAdapter((OleDbCommand)cmd);
                    break;
            }
            return dataAdater;
        }

       /// <summary>
       ///创建单个IDbDataParameter对象--create by joyet
       /// </summary>
       /// <param name="pramName"></param>
       /// <param name="pramValue"></param>
       /// <returns></returns>
        public IDbDataParameter CreateDbParameter(string pramName, object pramValue)
        {
            int dbTypeValue = (int)dbType;
            IDbDataParameter cmdParam = null;
            pramName = CreateDbParameterStr() + pramName;
            switch (dbTypeValue)
            {
                case 1:
                    cmdParam = new SqlParameter(pramName, pramValue);
                    break;

                case 2:
                    cmdParam = new OracleParameter(pramName, pramValue);
                    break;

                case 3:
                    cmdParam = new MySqlParameter(pramName, pramValue);
                    break;

                case 4:
                    cmdParam = new OleDbParameter(pramName, pramValue);
                    break;
            }
            return cmdParam;
        }

        /// <summary>
        /// 创建数据库参数特殊字符--create by joyet
        /// </summary>
        /// <param name="gcType"></param>
        /// <returns></returns>
        public string CreateDbParameterStr()
        {
            int dbTypeValue = (int)dbType;
            string prameStr = "@";
            switch (dbTypeValue)
            {
                case 1:
                    prameStr = "@";
                    break;

                case 2:
                    prameStr = ":";
                    break;

                case 3:
                    prameStr = "?";
                    break;

                case 4:
                    prameStr = "@";
                    break;
            }
            return prameStr;
        }

       /// <summary>
        /// 根据object参数及值返回IDbDataParameter数组--create by joyet
       /// </summary>
       /// <param name="param"></param>
       /// <returns></returns>
        public  IDbDataParameter[]  ObjPramToDbParams(object param)
        {
            int dbTypeValue = (int)dbType;
            IDbDataParameter[] cmdParams = null;
            if (param != null)
            {
                List<EntityColumn> columnList = new EntityColumnUtility().GetParamColumnList(param);
                if (columnList != null && columnList.Count > 0)
                {
                    List<IDbDataParameter> dbParamList = new List<IDbDataParameter>();
                    foreach (EntityColumn column in columnList)
                    {
                        var dbParam = CreateDbParameter(column.ColumnName, column.ColumnValue);
                        dbParamList.Add(dbParam);
                    }
                    cmdParams = dbParamList.ToArray();
                }
            }
            return cmdParams;
        }

        /// <summary>
        /// 创建实现数据访问类接口对象实例
        /// </summary>
        /// <returns></returns>
        public  ISqlDb CreateSqlDb()
        {
            int dbTypeValue = (int)dbType;
            ISqlDb gcDbHelper = null;
            switch (dbTypeValue)
            {
                case 1:
                    gcDbHelper = new MsSqlDb();
                    break;

                case 2:
                    gcDbHelper = new OracleSqlDb();
                    break;

                case 3:
                    gcDbHelper = new MySqlDb();
                    break;

                case 4:
                    gcDbHelper = new OleDbSqlDb();
                    break;
            }
            return gcDbHelper;
        }

         /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gcDbType"></param>
        public DbOperator(GcEnumDbType gcDbType)
        {
            this.dbType = gcDbType;
        }
        #endregion
    }
}
