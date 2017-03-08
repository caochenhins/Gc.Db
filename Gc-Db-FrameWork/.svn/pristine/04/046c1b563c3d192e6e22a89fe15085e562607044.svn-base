using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGcDb.model2
{
   public class AuditableEntity
    {
        public AuditableEntity()
        {
            CreateUserID = string.Empty;
            CreateTime = DateTime.Now;
            ModifyUserID = string.Empty;
            ModifyTime = DateTime.Now;
            DeleteUserID = string.Empty;
            DeleteTime = DateTime.Now;
            IsDeleted = false;
        }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public string CreateUserID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        public string ModifyUserID { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 删除用户ID
        /// </summary>
        public string DeleteUserID { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeleteTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
