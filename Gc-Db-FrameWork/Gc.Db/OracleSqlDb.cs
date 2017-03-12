using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace Gc.Db
{
    public class OracleSqlDb : SqlDb, ISqlDb
    {

        #region Public Methods

        /// <summary>
       /// 构造函数
       /// </summary>
        public OracleSqlDb()
       {
           DbType = GcEnumDbType.Oracle;
           DbInsInit();
       }

       #endregion
       
    }
}
