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
            UserInfo model = msDb.Find<UserInfo>(msDbConnStr, uid);
            return model;
        }

       /// <summary>
       /// 查询object to in
       /// </summary>
       /// <param name="uid"></param>
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
            List<UserInfo> list1 = msDb.Select<UserInfo>(msDbConnStr, "", "", null);
            List<UserInfo> list2 = msDb.Select<UserInfo>(msDbConnStr, "UserId>0", "", null);
            List<UserInfo> list3 = msDb.Select<UserInfo>(msDbConnStr, "", "CreateTime desc", null);
            List<UserInfo> list4 = msDb.Select<UserInfo>(msDbConnStr, "UserId>@UserId", "CreateTime desc", new { UserId = 0 });

            //查询分页列表
           PageResponseData result = msDb.GetPageList<UserInfo>(msDbConnStr, new PageRequestData());
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
