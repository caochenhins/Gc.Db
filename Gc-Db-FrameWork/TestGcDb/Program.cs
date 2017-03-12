using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gc.Db;
using System.Data;

namespace TestGcDb
{
    class Program
    {
       
        static void Main(string[] args)
        {
            test1();
        }

       
        /// <summary>
        /// 基本操作
        /// </summary>
        private static  void  test1()
        {
            UserInfoDao userDao = new UserInfoDao();

            ////添加数据
            //userDao.Add();

            ////修改数据
            //userDao.Update();

            ////删除数据
            //userDao.Delete();

            //事务用法
            //userDao.TransOperator1();

            ////事务用法2
            //userDao.TransOperator2();

            //查询
            userDao.GetList();

            //查询object to in
            userDao.GetObject();
           
        }
    }
}
