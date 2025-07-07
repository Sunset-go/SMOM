using SIE.Common.Attachments;
using SIE.Common.Messages;
using SIE.Domain;
using SIE.MetaModel;
using SIE.ObjectModel;
using System;

namespace SIE.ZYF.ProductManages
{
    /// <summary>
    /// 产品管理附件
    /// </summary>
    [ChildEntity,Serializable]
    [Label("产品管理-附件")]
    public class ProductManageAttachment : Attachment<ProductManage>
    {
    }
    /// <summary>
    /// 产品管理附件仓储
    /// </summary>
    [DataProvider(typeof(ZYFEntityDataProvider))]
    public class ProductManageAttachmentRepository : AttachmentRepository<ProductManageAttachment>
    {
    }

    internal class ProductManageAttachmentConfig: AttachmentEntityConfig<ProductManageAttachment>
    {
        protected override void AddValidations(IValidationDeclarer rules)
        {
            //base.AddValidations(rules);
            rules.AddRule(new Domain.Validation.NotDuplicateRule()
            {
                Properties =
                {
                    ProductManageAttachment.FileNameProperty,
                    ProductManageAttachment.FileExtesionProperty
                },
                MessageBuilder = (e) =>
                {
                    var attachment = e as ProductManageAttachment;
                    return "【{0}.{1}】文件已存在,不能重复上传！".L10nFormat(attachment.FileName,attachment.FileExtesion);
                }
            });
        }

        protected override void ConfigMeta()
        {
            base.ConfigMeta();
            Meta.EnableDiscriminator("ProductManageAttachment");
        }
    }
}
