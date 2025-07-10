using SIE.Common.Configs;
using SIE.Common.NumberRules;
using SIE.Domain;
using SIE.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIE.ZYF.ProductManages.Configs
{
    [RootEntity, Serializable]
    [Label("编码规则配置类")]
    public class CodeConfigValue : ConfigValue
    {
        #region 编码规则 CodeRule
        /// <summary>
        /// 编码规则Id
        /// </summary>
        [Label("属性名")]
        public static readonly IRefIdProperty CodeRuleIdProperty =
            P<CodeConfigValue>.RegisterRefId(e => e.CodeRuleId, ReferenceType.Normal);

        /// <summary>
        /// 编码规则Id
        /// </summary>
        public double CodeRuleId
        {
            get { return (double)this.GetRefId(CodeRuleIdProperty); }
            set { this.SetRefId(CodeRuleIdProperty, value); }
        }

        /// <summary>
        /// 编码规则
        /// </summary>
        public static readonly RefEntityProperty<NumberRule> CodeRuleProperty =
            P<CodeConfigValue>.RegisterRef(e => e.CodeRule, CodeRuleIdProperty);

        /// <summary>
        /// 编码规则
        /// </summary>
        public NumberRule CodeRule
        {
            get { return this.GetRefEntity(CodeRuleProperty); }
            set { this.SetRefEntity(CodeRuleProperty, value); }
        }
        #endregion

        public override string Display()
        {
            if(CodeRule == null)
            {
                return "NIL";
            }
            return CodeRule.Name;
        }
    }
}
