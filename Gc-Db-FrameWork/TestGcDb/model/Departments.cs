using System;
using System.Collections.Generic;


namespace TestGcDb.model
{
    /// <summary>
    /// ҽԺ����
    /// </summary>
    public partial class Departments : AuditableEntity
    {
        /// <summary>
        /// ���ұ��
        /// </summary>
        public long ID { get; set; }

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
        public long HospitalID { get; set; }


    }
}
