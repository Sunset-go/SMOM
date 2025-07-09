using SIE.Domain;
using SIE.MetaModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIE.ZYF.Suppliers
{
    [SIE.ManagedProperty.CompiledPropertyDeclarer]
    public static class SupplierExtension
    {
        #region SupplierAddress SuAddress (供应商地址拓展属性)
        /// <summary>
        /// 供应商地址拓展属性 扩展属性。
        /// </summary>
        public static readonly Property<SupplierAddress> SuAddressProperty =
            P<Supplier>.RegisterExtension<SupplierAddress>("DetailAddress", typeof(SupplierExtension));

        /// <summary>
        /// 获取 供应商地址拓展属性 属性的值。
        /// </summary>
        /// <param name="me">要获取扩展属性值的对象。</param>
        public static SupplierAddress GetSuAddress(this Supplier me)
        {
            return me.GetProperty(SuAddressProperty);
        }

        /// <summary>
        /// 设置 供应商地址拓展属性 属性的值。
        /// </summary>
        /// <param name="me">要设置扩展属性值的对象。</param>
        /// <param name="value">设置的值。</param>
        public static void SetSuAddress(this Supplier me, SupplierAddress value)
        {
            me.SetProperty(SuAddressProperty, value);
        }
        #endregion

        #region EntityList<SupplierPhone> SuConcat (供应商联系人拓展属性)
        /// <summary>
        /// 供应商联系人拓展属性 扩展属性。
        /// </summary>
        public static readonly ListProperty<EntityList<SupplierPhone>> SuConcatProperty =
            P<Supplier>.RegisterExtensionList<EntityList<SupplierPhone>>("SuConcat", typeof(SupplierExtension));

        /// <summary>
        /// 获取 供应商联系人拓展属性 属性的值。
        /// </summary>
        /// <param name="me">要获取扩展属性值的对象。</param>
        public static EntityList<SupplierPhone> GetSuConcat(this Supplier me)
        {
            return me.GetLazyList(SuConcatProperty) as EntityList<SupplierPhone>;
        }
        #endregion

        internal class SupplierAddressExtensionConfig : EntityConfig<Supplier>
        {
            protected   override void ConfigMeta()
            {
                Meta.Property(SupplierExtension.SuAddressProperty).DontMapColumn();
                Meta.Property(SupplierExtension.SuConcatProperty).DontMapColumn();
            }
        }
    }
}
