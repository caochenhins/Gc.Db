using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace Gc.Db
{
    public class OleDbSqlDb : SqlDb, ISqlDb
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
        public OleDbSqlDb()
       {
           dbType = GcEnumDbType.OleDb;
           dbPramStr = new DbOperator(dbType).CreateDbParameterStr();
       }

       #endregion
     
    }
}
