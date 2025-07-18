using SIE.Common.Configs;
using SIE.Domain;
using SIE.ObjectModel;
using System;

namespace SIE.ZYF.ProductManages.Configs
{
    /// <summary>
    /// 采购数量配置实体类
    /// </summary>
    [RootEntity, Serializable]
    [Label("采购数量配置实体类")]
    public class QuantityConfigValue : ConfigValue
    {
        #region 采购数量 Quantity
        /// <summary>
        /// 采购数量
        /// </summary>
        [Label("采购数量")]
        public static readonly Property<int> QuantityProperty = P<QuantityConfigValue>.Register(e => e.Quantity);

        /// <summary>
        /// 采购数量
        /// </summary>
        public int Quantity
        {
            get { return GetProperty(QuantityProperty); }
            set { SetProperty(QuantityProperty, value); }
        }
        #endregion

        public override string Display()
        {
            return Quantity.ToString();
        }
    }
}
