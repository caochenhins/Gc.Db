using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Gc.Data
{
    public class EntityColumnUtility
    {
        /// <summary>
        /// 根据实体类中自定义属性主键标识名称、值信息--create by guochao
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public  EntityColumn GetIdColumn<T>(object Id)
        {
            EntityColumn column = null;
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            if (props.Length > 0)
            {
                foreach (PropertyInfo proInfo in props)
                {
                    object[] selftDefineAttrs = proInfo.GetCustomAttributes(typeof(EntityColumnAttribute), true);
                    if (selftDefineAttrs.Length > 0)
                    {
                        EntityColumnAttribute selftDefineAttr = (EntityColumnAttribute)selftDefineAttrs[0];
                        if (selftDefineAttr.IsPk)
                        {
                            column = new EntityColumn();
                            if (Id == null)
                            {
                                Id = DBNull.Value;
                            }
                            column.ColumnName = selftDefineAttr.FieldName;
                            column.ColumnValue = Id;
                            column.IsPk = selftDefineAttr.IsPk;
                            column.IsIdentity = selftDefineAttr.IsIdentity;
                            column.IsGetIdentityValue = selftDefineAttr.IsGetIdentityValue;
                            break;
                        }
                    }
                }
            }
            return column;
        }

        /// <summary>
        /// 根据实体类中系统和自定义属性名称、值信息--create by guochao
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public  List<EntityColumn> GetColumnList<T>(T t)
        {
            List<EntityColumn> list = null;
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            if (props.Length > 0)
            {
                list = new List<EntityColumn>();
                foreach (PropertyInfo proInfo in props)
                {
                    EntityColumn systemColumn = GetSystemProperInfo<T>(type,t,proInfo);
                    if (systemColumn != null)
                    {
                        EntityColumn selftDefineColumn = GetSelftDefineProperInfo<T>(type, t,proInfo);
                        if (selftDefineColumn != null)
                        {
                            list.Add(selftDefineColumn);
                        }
                        else
                        {
                            list.Add(systemColumn);
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取单个属性默认定义列名和值信息--create by guochao
        /// </summary>
        /// <param name="proInfo"></param>
        /// <returns></returns>
        private  EntityColumn GetSystemProperInfo<T>(Type type ,T t,PropertyInfo proInfo)
        {
            EntityColumn column = null;
            if (proInfo != null)
            {
                column = new EntityColumn();
                string attrName = proInfo.Name;
                object attrValue = proInfo.GetValue(t, null);
                if (attrValue == null)
                {
                    attrValue = DBNull.Value;
                }
                column.ColumnName = proInfo.Name;
                column.ColumnValue = attrValue;
            }
            return column;
        }

       /// <summary>
        /// 获取单个自定义列名和值信息--create by guochao
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="type"></param>
       /// <param name="t"></param>
       /// <param name="proInfo"></param>
       /// <returns></returns>
        private  EntityColumn GetSelftDefineProperInfo<T>(Type type, T t, PropertyInfo proInfo)
        {
            EntityColumn column = null;
            if (proInfo != null)
            {
                object[] selftDefineAttrs = proInfo.GetCustomAttributes(typeof(EntityColumnAttribute), true);
                if (selftDefineAttrs.Length > 0)
                {
                    column = new EntityColumn();
                    EntityColumnAttribute selftDefineAttr = (EntityColumnAttribute)selftDefineAttrs[0];
                    object selftDefineAttrVal = type.GetProperty(selftDefineAttr.FieldName).GetValue(t, null);
                    if (selftDefineAttrVal == null)
                    {
                        selftDefineAttrVal = DBNull.Value;
                    }
                    column.ColumnName = selftDefineAttr.FieldName;
                    column.ColumnValue = selftDefineAttrVal;
                    column.IsPk = selftDefineAttr.IsPk;
                    column.IsIdentity = selftDefineAttr.IsIdentity;
                    column.IsGetIdentityValue = selftDefineAttr.IsGetIdentityValue;
                }
            }
            return column;
        }

       /// <summary>
        /// 获取param中键和值--create by guochao
       /// </summary>
       /// <param name="param"></param>
        /// <returns></returns>GetParamColumnList
        public  List<EntityColumn> GetParamColumnList(object param)
        {
            List<EntityColumn> columnList = null;
            Type type = param.GetType();
            PropertyInfo[] props = type.GetProperties();
            if (props.Length > 0)
            {
                columnList = new List<EntityColumn>();
                foreach (PropertyInfo proInfo in props)
                {
                    string attrName = proInfo.Name;
                    object attrValue = proInfo.GetValue(param, null);
                    if (attrValue == null)
                    {
                        attrValue = DBNull.Value;
                    }
                    columnList.Add(new EntityColumn()
                    {
                        ColumnName=attrName,
                        ColumnValue=attrValue
                    });
                }
            }
            return columnList;
        }

    }
}
