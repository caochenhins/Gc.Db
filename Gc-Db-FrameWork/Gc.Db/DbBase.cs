using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Transactions;

namespace Gc.Db
{
    public class DbBase
    {
        #region prviate Fields and  public Fields

        /// <summary>
        ///是否开启事务
        /// </summary>
        private bool isStartTrans = false;

        /// <summary>
        /// 用于事务对象
        /// </summary>
        private TransactionScope transScope = null;
        
        /// <summary>
        /// 数据库类型
        /// </summary>
        public GcEnumDbType dbType { get; set; }

       #endregion

       #region Public Methods

        /// <summary>
        /// 执行增、删、改操作,返回影响行数--create by joyet
        /// </summary>
        /// <param name="connectionStr">数据库字符串连接</param>
        /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="dbParams">IDbDataParameter参数数组</param>
       /// <returns>int</returns>
        public int Execute(string connectionStr, string cmdText, CommandType cmdType, IDbDataParameter[] dbParams)
        {
            int num = 0;
            using (IDbConnection conn = new DbOperator(dbType).CreateConnection(connectionStr))
            {
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    PrepareCommand(cmdText, cmdType, conn, cmd, null, dbParams);
                    num = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            return num;
        }

       /// <summary>
       /// 执行增、删、改操作,返回影响行数--create by joyet
       /// </summary>
       /// <param name="connectionStr">数据库字符串连接</param>
       /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
       /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
       /// <param name="objParam">object参数对象</param>
        /// <returns>int</returns>
       public int ExecuteWithParam(string connectionStr, string cmdText, CommandType cmdType, object objParam)
        {
            int num = 0;
            if (!string.IsNullOrEmpty(cmdText))
            {
                if (objParam != null)
                {
                    IDbDataParameter[] cmdParams = new DbOperator(dbType).ObjPramToDbParams(objParam);
                    num = Execute(connectionStr, cmdText, cmdType, cmdParams);
                }
                else
                {
                    num =Execute(connectionStr, cmdText, cmdType, null);
                }
            }
            return num;
        }

       /// <summary>
       /// 执行查询操作,返回DataSet--create by joyet
       /// </summary>
       /// <param name="connectionStr">数据库字符串连接></param>
       /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
       /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
       /// <param name="dbParams">数据库参数数组</param>
       /// <returns>DataSet</returns>
       public DataSet ExecuteQuery(string connectionStr, string cmdText, CommandType cmdType, IDbDataParameter[] dbParams)
        {
            DataSet ds = new DataSet();
            var dbOperator = new DbOperator(dbType);
            using (IDbConnection conn = dbOperator.CreateConnection(connectionStr))
            {
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    PrepareCommand(cmdText, cmdType, conn, cmd, null, dbParams);
                    IDataAdapter da = dbOperator.CreateDataAdapter(cmd);
                    da.Fill(ds);
                    cmd.Parameters.Clear();
                    return ds;
                }
            }
        }

       /// <summary>
       /// 执行查询操作,返回DataSet--create by joyet
       /// </summary>
       /// <param name="connectionStr">数据库字符串连接</param>
       /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
       /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
       /// <param name="param">object参数对象</param>
       /// <returns>DataSet</returns>
       public DataSet ExecuteQueryWithParam(string connectionStr, string cmdText, CommandType cmdType, object objParam)
        {
            DataSet ds = new DataSet();
            if (!string.IsNullOrEmpty(cmdText))
            {
                if (objParam != null)
                {
                    IDbDataParameter[] dbParams = new DbOperator(dbType).ObjPramToDbParams(objParam);
                    ds = ExecuteQuery(connectionStr, cmdText, cmdType, dbParams);
                }
                else
                {
                    ds = ExecuteQuery(connectionStr, cmdText, cmdType, null);
                }
            }
            return ds;
        }

       /// <summary>
       /// 执行查询操作,返回IDataReader--create by joyet
       /// </summary>
       /// <param name="connectionStr">数据库字符串连接></param>
       /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
       /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
       /// <param name="dbParams">数据库参数数组</param>
       /// <returns>IDataReader</returns>
       public IDataReader ExecuteReader(string connectionStr, string cmdText, CommandType cmdType, IDbDataParameter[] dbParams)
        {
            IDbConnection conn = new DbOperator(dbType).CreateConnection(connectionStr);
            IDbCommand cmd = conn.CreateCommand();
            PrepareCommand(cmdText, cmdType, conn, cmd, null, dbParams);
            IDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return myReader;
        }

       /// <summary>
       /// 执行查询操作,返回IDataReader--create by joyet
       /// </summary>
       /// <param name="connectionStr">数据库字符串连接</param>
       /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
       /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
       /// <param name="objParam">object参数对象</param>
       /// <returns>IDataReader</returns>
       public IDataReader ExecuteReaderWithParam(string connectionStr, string cmdText, CommandType cmdType, object objParam)
        {
            IDataReader sqlDataReader = null;
            if (!string.IsNullOrEmpty(cmdText))
            {
                if (objParam != null)
                {
                    IDbDataParameter[] dbParams = new DbOperator(dbType).ObjPramToDbParams(objParam);
                    sqlDataReader = ExecuteReader(connectionStr, cmdText, cmdType, dbParams);
                }
                else
                {
                    sqlDataReader = ExecuteReader(connectionStr, cmdText, cmdType, null);
                }
            }
            return sqlDataReader;
        }

       /// <summary>
       /// 执行查询操作,返回object--create by joyet
       /// </summary>
       /// <param name="connectionStr">数据库字符串连接</param>
       /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
       /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
       /// <param name="dbParams">数据库参数数组</param>
       /// <returns>object</returns>
       public object ExecuteScalar(string connectionStr, string cmdText, CommandType cmdType, IDbDataParameter[] dbParams)
        {
            using (IDbConnection conn = new DbOperator(dbType).CreateConnection(connectionStr))
            {
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    PrepareCommand(cmdText, cmdType, conn, cmd, null, dbParams);
                    object objValue = cmd.ExecuteScalar();
                    if ((Object.Equals(objValue, null)) || (Object.Equals(objValue, System.DBNull.Value)))
                    {
                        objValue = null;
                    }
                    cmd.Parameters.Clear();
                    return objValue;
                }
            }
        }

       /// <summary>
       /// 执行查询操作,返回object--create by joyet
       /// </summary>
       /// <param name="connectionStr">数据库字符串连接</param>
       /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
       /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
       /// <param name="objParam">object参数对象</param>
       /// <returns>object</returns>
       public object ExecuteScalarWithParam(string connectionStr, string cmdText, CommandType cmdType, object objParam)
        {
            object objValue = null;
            if (!string.IsNullOrEmpty(cmdText))
            {
                if (objParam != null)
                {
                    IDbDataParameter[] dbParams = new DbOperator(dbType).ObjPramToDbParams(objParam);
                    objValue = ExecuteScalar(connectionStr, cmdText, cmdType, dbParams);
                }
                else
                {
                    objValue = ExecuteScalar(connectionStr, cmdText, cmdType, null);
                }
            }
            return objValue;
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        public void StartTrans()
        {
            if (!isStartTrans)
            {
                isStartTrans = true;
                transScope = new TransactionScope();
            }
        }

        /// <summary>
        /// 关闭事务
        /// </summary>
        public void CloseTrans()
        {
            isStartTrans = false;
            try
            {
                transScope.Complete();
                if (transScope != null)
                {
                    transScope.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 参数据底层公共操作--create by joyet
        /// </summary>
        /// <param name="cmdText">SQL语句/存储过程/参数化SQL语句</param>
        /// <param name="cmdType">命令类型:SQL语句/存储过程</param>
        /// <param name="conn">数据为连接对象</param>
        /// <param name="cmd">执行SQL命令对象</param>
        /// <param name="trans">数据库事务操作对象</param>
        /// <param name="dbParms">数据库参数数组</param>
        private void PrepareCommand(string cmdText, CommandType cmdType, IDbConnection conn, IDbCommand cmd, IDbTransaction trans, IDbDataParameter[] dbParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (dbParms != null)
            {
                foreach (IDbDataParameter parameter in dbParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gcDbType"></param>
        public DbBase(GcEnumDbType gcDbType)
        {
            this.dbType = gcDbType;
        }
       #endregion

    }
}
