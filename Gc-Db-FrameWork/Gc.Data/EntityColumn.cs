﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gc.Data
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class EntityColumnAttribute : Attribute
    {
        #region public variable
        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPk { get; set; }

        /// <summary>
        /// 是否自动增长
        /// </summary>
        public bool IsIdentity { get; set; }
       
        /// <summary>
        /// 是否获取自动增长值
        /// </summary>
        public bool IsGetIdentityValue { get; set; }

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="isPk">是否主键</param>
        /// <param name="isIdentity">是否自动增长</param>
        /// <param name="isGetIdentityValue">是否获取自动增长</param>
        public EntityColumnAttribute(string fieldName, bool isPk = false, bool isIdentity = false, bool isGetIdentityValue = false)
        {
            FieldName = fieldName;
            IsPk = isPk;
            IsIdentity = isGetIdentityValue;
            IsGetIdentityValue = isGetIdentityValue;
        }
    }

    [Serializable]
    public class EntityColumn
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EntityColumn()
        {
            ColumnName = string.Empty;
            ColumnValue = null;
            IsPk = false;
            IsIdentity = false;
            IsGetIdentityValue = false;
        }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 字段值
        /// </summary>
        public object ColumnValue { get; set; }

        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPk { get; set; }

        /// <summary>
        /// 是否自动增长
        /// </summary>
        public bool IsIdentity { get; set; }

        /// <summary>
        /// 是否获取自动增长值
        /// </summary>
        public bool IsGetIdentityValue { get; set; }
    }

}
