using System;
using System.Collections.Generic;


namespace TestGcDb.model2
{  
    
    public partial class Hospitals : AuditableEntity
    {
        public string HospitalID { get; set; }

        /// <summary>
        /// ҽԺ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ҽԺ����
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ���֤���
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// LOGO��ַ
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// ҽԺ��ַ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// �ʱ�
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// �绰����
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// ҽԺͼƬ
        /// </summary>
        public string Image { get; set; }    

        public string HospitalGroupID { get; set; }

        public string UserID { get; set; }

    }
}
