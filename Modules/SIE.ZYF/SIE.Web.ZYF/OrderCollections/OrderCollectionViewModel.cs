using SIE.Domain;
using SIE.ObjectModel;
using System;

namespace SIE.Web.ZYF.OrderCollections
{
    /// <summary>
    /// 采购订单采集明细
    /// </summary>
    [RootEntity, Serializable]
    [Label("订单采集")]
    public class OrderCollectionViewModel : ViewModel
    {
        #region 提示信息 Tips
        /// <summary>
        /// 提示信息
        /// </summary>
        [Label("提示信息")]
        public static readonly Property<string> TipsProperty = P<OrderCollectionViewModel>.Register(e => e.Tips);

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Tips
        {
            get { return GetProperty(TipsProperty); }
            set { SetProperty(TipsProperty, value); }
        }
        #endregion

        #region 错误信息 Errors
        /// <summary>
        /// 错误信息
        /// </summary>
        [Label("错误信息")]
        public static readonly Property<string> ErrorsProperty = P<OrderCollectionViewModel>.Register(e => e.Errors);

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Errors
        {
            get { return GetProperty(ErrorsProperty); }
            set { SetProperty(ErrorsProperty, value); }
        }
        #endregion

        #region 订单号 OrderNumber
        /// <summary>
        /// 订单号
        /// </summary>
        [Label("订单号")]
        public static readonly Property<string> OrderNumberProperty = P<OrderCollectionViewModel>.Register(e => e.OrderNumber);

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber
        {
            get { return GetProperty(OrderNumberProperty); }
            set { SetProperty(OrderNumberProperty, value); }
        }
        #endregion

        #region 产品编码 Code
        /// <summary>
        /// 产品编码
        /// </summary>
        [Label("产品编码")]
        public static readonly Property<string> CodeProperty = P<OrderCollectionViewModel>.Register(e => e.Code);

        /// <summary>
        /// 产品编码
        /// </summary>
        public string Code
        {
            get { return GetProperty(CodeProperty); }
            set { SetProperty(CodeProperty, value); }
        }
        #endregion

        #region 输入 Input
        /// <summary>
        /// 输入
        /// </summary>
        [Label("输入")]
        public static readonly Property<string> InputProperty = P<OrderCollectionViewModel>.Register(e => e.Input);

        /// <summary>
        /// 输入
        /// </summary>
        public string Input
        {
            get { return GetProperty(InputProperty); }
            set { SetProperty(InputProperty, value); }
        }
        #endregion

    }
}
