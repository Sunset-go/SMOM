using SIE.Common.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIE.ZYF.ProductManages.Configs
{
    [System.ComponentModel.DisplayName("编码规则")]
    [System.ComponentModel.Description("产品编码配置")]
    public class CodeConfig : ModuleConfig<CodeConfigValue>
    {
        private readonly CodeConfigValue defaultValue = new CodeConfigValue() { CodeRule = null };
        public override CodeConfigValue DefaultValue
        {
            get { return defaultValue; }
        }
    }
}
