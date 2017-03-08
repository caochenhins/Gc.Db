using Gc.Data;
using Gc.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGcDb.model
{
   public class blog
    {
        [EntityColumn("BlogId", IsPk = true)]
       public int BlogId { get; set; }

       public string BlogTitle { get; set; }

       public string BlogContent { get; set; }
    }
}
