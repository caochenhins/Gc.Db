# Gc.Db
  Gc.Db是一套基于ADO.Net数据库快速开发框架和轻量级半ORM框架。特点如下：  
  1.支持数据库有MSSql、MySql、Oracle、Access。      
  2.对各数据库操作完全是基于接口设计,能够与各种IOC框架很好集成，便于程序解耦。       
  3.对单表提供了ORM功能,同时又封装ado.net常用SQL语句、参数化SQL语句、存储过程方法，为MSSql、MySql单表提供了分页功能，提供了开发效率。   4.支持分布式事务操作。
  
   (1)Gc.Db配置相关简单，只需在主键、是否需要获取自动增长、是否获取自动增长值，目前对SqlSver和MySQL支持配置自动增长和获取自动增长值特性。Gc.Db配置和示例代码如下。


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

（2）创建一个对数据库操作示例类，添加了些对数据访问常用方法。

using Gc.Db;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using Gc.Db;

using System.Data;

using Gc.Data;

namespace TestGcDb
{
   public class UserInfoDao
    {
    
        //因为此演示代码是用的sqlserver,如果是mysql:MySqlDb,oracle:OracleSqlDb,同时各数据连接串
        private ISqlDb msDb = new MsSqlDb();

        //数据库连接，请根据各自数据库进行配置数据库连接串
        private string msDbConnStr = "Data Source=.;Initial Catalog=testdb;User ID=sa;Password=123456;";

        /// <summary>
        /// 添加数据
        /// </summary>
       public void Add()
        {
            UserInfo model = new UserInfo()
            {
                UserId = 1,
                UserName = "abc",
                Age = 15,
                CreateTime = DateTime.Now
            };
            msDb.Insert<UserInfo>(msDbConnStr, model);
        }

        /// <summary>
       /// 根据主键删除数据
        /// </summary>
       public void Delete()
        {
            int uid = 1;
            msDb.Delete<UserInfo>(msDbConnStr, uid);
        }

        /// <summary>
       /// 修改数据
        /// </summary>
       public void Update()
        {
            UserInfo model = GetModel();
            if (model != null)
            {
                model.CreateTime = DateTime.Now;
                msDb.Update<UserInfo>(msDbConnStr, model);
            }
        }

        /// <summary>
       /// 获取单条数据
        /// </summary>
        /// <returns></returns>
       public UserInfo GetModel()
        {
            int uid = 1;
            UserInfo model = msDb.QueryFirst<UserInfo>(msDbConnStr, uid);
            return model;
        }

       //// <summary>
       /// 查询object to in
       /// </summary>
       /// <returns></returns>
       public int  GetObject()
       {
           int num = 0;
           string sqlStr="select count(*) from UserInfo";
           object data = msDb.ExecuteScalar(msDbConnStr, sqlStr, CommandType.Text, null);
           if (data != null)
           {
               num = Convert.ToInt32(data);
           }
           return num;
       }

        /// <summary>
        /// 数据查询
        /// </summary>
       public void GetList()
        {
            //查询列表
            List<UserInfo> list2 = msDb.Query<UserInfo>(msDbConnStr, new SearchEntity() { WhereSql="UserId=0"});
            List<UserInfo> list4 = msDb.Query<UserInfo>(msDbConnStr, new SearchEntity() { WhereSql = "UserId=@UserId", WhereParam = new { UserId = 0 } });

            //查询分页列表
           PageResponseData result = new MySqlDb().GetPageList<UserInfo>(msDbConnStr, new PageRequestData());
           List<UserInfo> list6 = result.Data as List<UserInfo>;
           int toatl = result.TotalCount;
        }

       /// <summary>
       /// 事务用法
       /// </summary>
       /// <param name="uid"></param>
       public void TransOperator1()
       {
           msDb.StartTrans();
           for (int i = 1; i <= 5; i++)
           {
               UserInfo model = new UserInfo()
               {
                   UserId = i,
                   UserName = "abc" + i.ToString(),
                   Age = 15,
                   CreateTime = DateTime.Now
               };
               msDb.Insert<UserInfo>(msDbConnStr, model);
           }
           msDb.CloseTrans();
       }

       /// <summary>
       /// 事务用法2
       /// </summary>
       /// <param name="uid"></param>
       public void TransOperator2()
       {
           msDb.StartTrans();
           msDb.Delete<UserInfo>(msDbConnStr, 1);
           msDb.ExecuteWithParam(msDbConnStr, "delete from UserInfo where Userid=2", CommandType.Text, null);
           msDb.ExecuteWithParam(msDbConnStr, "delete from UserInfo where Userid=@UserID", CommandType.Text, new { UserID = 3 });
           msDb.CloseTrans();
       }
       
    }
    
}

