using System;
using System.Collections.Generic;


namespace TestGcDb.model
{
    /// <summary>
    /// 医院科室
    /// </summary>
    public partial class Departments : AuditableEntity
    {
        /// <summary>
        /// 科室编号
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 科室描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public long HospitalID { get; set; }


    }
}
