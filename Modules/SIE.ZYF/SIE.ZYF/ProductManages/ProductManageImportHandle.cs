﻿using SIE.Common.ImportHelper;
using SIE.Domain;
using SIE.Domain.Validation;
using SIE.Utils;
using SIE.ZYF.Materials;
using SIE.ZYF.ProductManages;
using SIE.ZYF.Suppliers;
using System;
using System.ArrayExtensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SIE.Web.ZYF.ProductManages
{
    [Services.Service(FallbackType = typeof(ProductManageImportHandle), ServiceLifeStyle = Services.ServiceLifeStyle.Transient)]
    public class ProductManageImportHandle : IDisposable, IBusinessImport
    {
        /// <summary>
        /// 状态字典（名称,状态）
        /// </summary>
        private Dictionary<string, ProductStatus> dicState = null;
        /// <summary>
        /// 供应商字典
        /// </summary>
        private Dictionary<string, double> dicSupplier = null;
        /// <summary>
        /// 物料字典
        /// </summary>
        private Dictionary<string, double> dicMaterial = null;
        /// <summary>
        /// 产品管理字典
        /// </summary>
        private Dictionary<string, ProductManage> dicProductManage = new Dictionary<string, ProductManage>();
        private const string ColCode = "产品编码";
        private const string ColName = "产品名称";
        private const string ColDescription = "产品描述";
        private const string ColState = "状态";
        private const string ColPurchaseQty = "采购数量";
        private const string ColPurchasePrice = "采购价";
        private const string ColSalePrice = "销售价";
        private const string ColSupplier = "供应商";
        private const string ColMaterial = "物料";

        public List<string> ColumnNameList { get; set; } = new List<string>()
        {
            ColCode,ColName,ColDescription,
            ColState,ColPurchaseQty,ColPurchasePrice,
            ColSalePrice,ColSupplier,ColMaterial
        };
        /// <summary>
        /// 列的标准验证
        /// </summary>
        public Dictionary<string, ValidColumn> ColumnValidList { get; set; }
        /// <summary>
        /// 创建列验证
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IBusinessImport CreaetColumnValid()
        {
            ColumnValidList = new Dictionary<string, ValidColumn>()
            {
                { ColCode, new ValidColumn(ImportDataType._String, true, true) }, // 产品编码，非空，去除前后空行
                { ColName, new ValidColumn(ImportDataType._String, true, true) }, // 产品名称，非空，去除前后空行
                { ColDescription, new ValidColumn(ImportDataType._String, false, true) }, // 产品描述，可空，去除前后空行
                { ColState, new ValidColumn(ImportDataType._String, false,StateValidation, true) },// 状态，可空，去除前后空行
                { ColPurchaseQty, new ValidColumn(ImportDataType._String, true, IntValidation, false) }, // 采购数量，非空，不去除前后空行
                { ColPurchasePrice, new ValidColumn(ImportDataType._String, true, DoubleValidation, false) }, // 采购价，非空，不去除前后空行
                { ColSalePrice, new ValidColumn(ImportDataType._String, true, DoubleValidation, false) }, // 销售价，非空，不去除前后空行
                { ColSupplier, new ValidColumn(ImportDataType._String, true,SupplierValidation, true) }, // 供应商，非空，去除前后空行
                { ColMaterial, new ValidColumn(ImportDataType._String, true, true) } // 物料，非空，去除前后空行
            };
            return this;
        }
        /// <summary>
        /// 供应商列的验证
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="MessageTip"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool SupplierValidation(object obj, out string MessageTip, DataRow dr)
        {
            bool isValid = true;
            MessageTip = string.Empty;
            var supplierCode = obj.ToString();
            var query = DB.Query<Supplier>().Where(p => p.State == State.Enable); // 获取启用状态的供应商列表
            if (dicSupplier == null)
            {   // 初始化供应商字典
                dicSupplier = new Dictionary<string, double>();
            }
            if (!dicSupplier.ContainsKey(supplierCode)) // 如果字典中不存在该供应商编码，则添加供应商编码和供应商ID到字典
            {
                var supplier = query.Where(s => s.Code == supplierCode).FirstOrDefault(); // 根据编码获取供应商
                if (supplier != null)
                {
                    dicSupplier[supplierCode] = supplier.Id;
                }
                else
                {
                    isValid = false;
                    MessageTip = "供应商[{0}]不存在或未启用".L10nFormat(supplierCode);
                    AppendErrorMsg(dr, ImportDataHandle.MessageColumnName, MessageTip);
                }
            }
            return isValid;
        }

        /// <summary>
        /// 产品状态列的验证
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="MessageTip"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool StateValidation(object obj, out string MessageTip, DataRow dr)
        {
            bool isValid = true;
            MessageTip = string.Empty;
            if (dicState == null)
            {
                // 初始化状态字典
                dicState = new Dictionary<string, ProductStatus>();
                // 获取状态枚举
                var enumViewModels = EnumViewModel.GetByEnumType(typeof(ProductStatus));
                // 将枚举值添加到字典中
                enumViewModels.ForEach(e => dicState.Add(e.Label, (ProductStatus)e.EnumValue));
            }
            string state = obj.ToString();
            if (!dicState.ContainsKey(state))
            {
                isValid = false;
                MessageTip = "格式错误，未查找到对应的枚举值";
                AppendErrorMsg(dr, ImportDataHandle.MessageColumnName, MessageTip);
            }
            return isValid;
        }

        /// <summary>
        /// 验证列值是否能转换成int类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="MessageTip"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool IntValidation(object obj, out string MessageTip, DataRow dr)
        {
            bool isValid = true;
            MessageTip = string.Empty;

            var str = obj.ToString();
            if (str.IsNullOrEmpty() || !int.TryParse(str, out int qty))
            {
                isValid = false;
                MessageTip = "格式错误，无法转换成整数";
                AppendErrorMsg(dr, ImportDataHandle.MessageColumnName, MessageTip);
            }
            else if (qty <= 0)
            {
                isValid = false;
                MessageTip = "格式错误，数量必须大于0";
                AppendErrorMsg(dr, ImportDataHandle.MessageColumnName, MessageTip);
            }
            return isValid;
        }

        /// <summary>
        /// 验证列值是否能转换成double类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="MessageTip"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool DoubleValidation(object obj, out string MessageTip, DataRow dr)
        {
            bool isValid = true;
            MessageTip = string.Empty;
            var str = obj.ToString();
            if (!decimal.TryParse(str, out decimal price))
            {
                isValid = false;
                MessageTip = "格式错误，无法转换成小数";
                AppendErrorMsg(dr, ImportDataHandle.MessageColumnName, MessageTip);
            }
            else if (price <= 0)
            {
                isValid = false;
                MessageTip = "格式错误，价格必须大于0";
                AppendErrorMsg(dr, ImportDataHandle.MessageColumnName, MessageTip);
            }
            return isValid;
        }

        public void Dispose()
        {
            dicState = null;
            dicSupplier = null;
            dicMaterial = null;
        }
        /// <summary>
        /// 获取列的索引
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int ColIndex(string columnName)
        {
            return ColumnNameList.IndexOf(columnName);
        }
        /// <summary>
        /// 添加错误信息
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <param name="errorMsg"></param>
        private void AppendErrorMsg(DataRow row, string columnName, string errorMsg)
        {
            row[columnName] += errorMsg;
        }

        /// <summary>
        /// 处理业务数据
        /// </summary>
        /// <param name="drs"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void ProcessBusinessDataHandle(DataRow[] drs)
        {
            var productManage = new List<string>();
            if (drs.Count() > 0)
            {
                drs.ForEach(p =>
                {
                    // 检验供应商,物料是否存在且合法
                    var supplierCode = p[ColIndex(ColSupplier)].ToString(); // 供应商编码
                    var materialCode = p[ColIndex(ColMaterial)].ToString(); // 物料编码
                    try
                    {
                        if (supplierCode.IsNullOrEmpty() || materialCode.IsNullOrEmpty()) // 供应商和物料不能为空
                        {
                            throw new ValidationException("供应商和物料不能为空".L10N());
                        }
                        var query = DB.Query<SupplierMaterials>()
                        .Join<Material>((sm, m) => m.Code == materialCode && sm.SupplierId == dicSupplier[supplierCode]);
                        if (query.Count() == 0)
                        {
                            throw new ValidationException("供应商[{0}]不存在物料[{1}]".L10nFormat(supplierCode, materialCode));
                        }
                        var materialId = query.FirstOrDefault().MaterialId;
                        // 检验销售价格是否大于采购价格
                        var pPrice = p[ColIndex(ColPurchasePrice)].ToString();
                        var sPrice = p[ColIndex(ColSalePrice)].ToString();
                        double.TryParse(pPrice, out double purchasePrice); // 采购价
                        double.TryParse(sPrice, out double salePrice); // 销售价
                        if (purchasePrice > salePrice)
                        {
                            throw new ValidationException("销售价不能小于采购价".L10N());
                        }
                        // 判断该编码是否存在，不如果存在则更新，否则新增
                        var productCode = p[ColIndex(ColCode)].ToString(); // 产品管理编码
                        var productName = p[ColIndex(ColName)].ToString(); // 产品名称
                        var productDesc = p[ColIndex(ColDescription)].ToString(); // 产品描述
                        var productState = p[ColIndex(ColState)].ToString(); // 状态
                        var pruductQty = p[ColIndex(ColPurchaseQty)].ToString(); // 数量
                        var queryProductManage = DB.Query<ProductManage>().Where(c => c.Code == productCode);
                        if (queryProductManage.Count() == 0)
                        {
                            // 新增数据
                            try
                            {
                                var product = new ProductManage
                                {
                                    Code = productCode, // 产品编码
                                    Name = productName, // 产品名称
                                    Description = productDesc, // 产品描述
                                    PurchaseQuantity = int.Parse(pruductQty), // 数量
                                    PurchasePrice = purchasePrice,
                                    Price = salePrice,
                                    Status = productState.IsNullOrEmpty() ? dicState[productState] : ProductStatus.UnAudit,
                                    SupplierId = dicSupplier[supplierCode],
                                    ProductMaterialId = materialId
                                };
                                RF.Save(product);
                            }
                            catch (Exception ex)
                            {
                                p[ImportDataHandle.MessageColumnName] = ex.Message;
                            }
                        }
                        else
                        {
                            // 更新数据
                            try
                            {
                                DB.Update<ProductManage>()
                                .Where(u => u.Code == productCode)
                                .Set(u => u.Name, productName)
                                .Set(u => u.Description, productDesc)
                                .Set(u => u.PurchasePrice, purchasePrice)
                                .Set(u => u.Price, salePrice)
                                .Set(u => u.SupplierId, dicSupplier[supplierCode])
                                .Set(u => u.ProductMaterialId, materialId)
                                .Execute();
                            }
                            catch (Exception ex)
                            {
                                p[ImportDataHandle.MessageColumnName] = ex.Message;
                            }
                        }
                    }
                    catch (ValidationException ex)
                    {
                        p[ImportDataHandle.MessageColumnName] = ex.Message;
                    }
                });
            }
        }
    }
}
