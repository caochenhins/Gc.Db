using Gc.Data;
using Gc.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGcDb
{
   public class UserInfo
    {
        [EntityColumn("UserId", true)]
       public int UserId { get; set; }

       public string UserName { get; set; }

       public int Age { get; set; }

       public DateTime CreateTime { get; set; }
    }
}
