using SIE; 
using SIE.MetaModel;
using SIE.ObjectModel;
using System;

namespace SIE.ZYF.Suppliers
{
	/// <summary>
	/// 数据来源
	/// </summary>
	public enum DataSourceEnum
	{
		/// <summary>
		/// 自建
		/// </summary>
		[Label("自建")]
		SelfBuilt = 1,
		/// <summary>
		/// 外部
		/// </summary>
		[Label("外部")]
		External = 0,
	}
}