using System;
using System.Collections.Generic;


namespace TestGcDb.model2
{
    /// <summary>
    /// ҽԺ����
    /// </summary>
    public partial class HospitalDepartment : AuditableEntity
    {
        /// <summary>
        /// ���ұ��
        /// </summary>
        public string HospitalDepartmentID { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ҽԺ���
        /// </summary>
        public string HospitalID { get; set; }


    }
}
