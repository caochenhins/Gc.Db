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

        #region Public Methods

        /// <summary>
        /// 构造函数
        /// </summary>
        public OleDbSqlDb()
       {
           DbType = GcEnumDbType.OleDb;
           DbInsInit();
       }

       #endregion
     
    }
}
