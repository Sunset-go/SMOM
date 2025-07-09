using SIE.Domain;
using SIE.Domain.Validation;
using SIE.ManagedProperty;
using SIE.MetaModel;
using System;
using System.Text.RegularExpressions;

namespace SIE.ZYF.Suppliers
{
    /// <summary>
    /// 供应商手机号码格式验证规则
    /// </summary>
    [System.ComponentModel.DisplayName("供应商手机号码格式验证")]
    [System.ComponentModel.Description("供应商手机号码正则表达式规则")]
    public class PhoneMatchRule : EntityRule<Supplier>
    {
        public PhoneMatchRule()
        {
            Property = Supplier.ContactPhoneNumberProperty;
            ConnectToDataSource = false;
        }

        protected override void Validate(IEntity entity, RuleArgs e)
        {
            var phone = entity as Supplier;
            if (!phone.ContactPhoneNumber.IsNullOrWhiteSpace())
            {
                string phoneRegexRule = @"^(?:(?:\+|00)86)?1(?:3\d|4[5-9]|5[0-35-9]|6[2567]|7[0-8]|8\d|9[0-35-9])\d{8}$"; // 手机号码正则表达式
                Regex phoneRegex = new Regex(phoneRegexRule);
                var matches = phoneRegex.IsMatch(phone.ContactPhoneNumber);
                if (!matches)
                {
                    e.BrokenDescription = "手机号码格式不正确。";
                }
            }
        }
    }


    /// <summary>
    /// 供应商邮箱格式验证规则
    /// </summary>
    [System.ComponentModel.DisplayName("供应商邮箱格式验证")]
    [System.ComponentModel.Description("供应商邮箱正则表达式规则")]
    public class EmailMatchRule : EntityRule<Supplier>
    {
        public EmailMatchRule()
        {
            Property = Supplier.EmailProperty;
            ConnectToDataSource = false;
        }
        protected override void Validate(IEntity entity, RuleArgs e)
        {
            var email = entity as Supplier;
            if (!email.Email.IsNullOrWhiteSpace())
            {
                string emailRegexRule = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; // 邮箱正则表达式
                Regex emailRegex = new Regex(emailRegexRule);
                var matches = emailRegex.IsMatch(email.Email);
                if (!matches)
                {
                    e.BrokenDescription = "邮箱格式不正确。";
                }
            }
        }
    }
}
