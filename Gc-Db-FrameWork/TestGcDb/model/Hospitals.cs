using System;
using System.Collections.Generic;
using Gc.Db;
using Gc.Data;


namespace TestGcDb.model
{  
    
    public partial class Hospitals : AuditableEntity
    {
        [EntityColumn("ID", true)]
        public long ID { get; set; }

        public int GroupID { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 医院描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 许可证编号
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// LOGO地址
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 医院地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 医院图片
        /// </summary>
        public string Image { get; set; }    

        public long UserID { get; set; }

    }
}
