using Newtonsoft.Json;
using SIE.Domain;
using SIE.Web.Command;
using SIE.ZYF.ProductManages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using JsonException = Newtonsoft.Json.JsonException;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SIE.Web.ZYF.ProductManages.Commands
{
    /// <summary>
    /// 审核产品
    /// </summary>
    public class ReviewProductManageCommand : ViewCommand
    {
        /// <summary>
        /// 反序列化参数
        /// </summary>
        /// <param name="args"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        protected override object Excute(ViewArgs args, string scope)
        {
            var argument = args.Data.ToJsonObject<ReviewProductManageCommandArgument>();
            return IsReview(argument);
        }
        /// <summary>
        /// 审核产品
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private bool IsReview(ReviewProductManageCommandArgument args)
        {
            foreach(var Id in args.SelectIds)
            {
                var query = DB.Update<ProductManage>().Where(p => p.Id == Id);
                query.Set(d => d.Remark, args.Remark);
                query.Set(d => d.Status, ProductStatus.Audited);
                query.Execute();
            }
            return true;
        }
    }
    /// <summary>
    /// 审核产品参数
    /// </summary>
    internal class ReviewProductManageCommandArgument
    {
        public int[] SelectIds { get; set; }
        public string Remark { get; set; }
    }
}
