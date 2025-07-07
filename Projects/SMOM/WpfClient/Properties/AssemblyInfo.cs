using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("SIE.MOM")]
[assembly: AssemblyDescription(SIE.SMOM.AssemblyInformation.Description)]
[assembly: AssemblyCompany(SIE.SMOM.AssemblyInformation.AssemblyCompany)]
[assembly: AssemblyCopyright(SIE.SMOM.AssemblyInformation.AssemblyCopyright)]
[assembly: AssemblyTrademark(SIE.SMOM.AssemblyInformation.AssemblyTrademark)]
[assembly: AssemblyVersion(SIE.SMOM.AssemblyInformation.Version)]
[assembly: AssemblyFileVersion(SIE.SMOM.AssemblyInformation.FileVersion)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("SIE.MOM")]
[assembly: AssemblyCulture("")]

//将 ComVisible 设置为 false 将使此程序集中的类型
//对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("DD74BF9E-1E1D-4773-9F2D-870169969C28")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
//可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”: :
// [assembly: AssemblyVersion("1.0.*")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace SIE.SMOM
{
    /// <summary>
    /// 
    /// </summary>
    public class AssemblyInformation
    {
#if DEBUG
        public const string AssemblyConfiguration = "Debug - ";
#else
            public const string AssemblyConfiguration = "Release - ";
#endif

        /// <summary>
        /// 程序集版权信息
        /// </summary>
        public const string AssemblyCopyright = "Copyright © 2024 广州赛意信息科技股份有限公司";
        /// <summary>
        /// 自定义标识
        /// </summary>
        public const string AssemblyTrademark = "SIE.Core.";
        /// <summary>
        /// 公司名称
        /// </summary>
        public const string AssemblyCompany = "广州赛意信息科技股份有限公司";
        /// <summary>
        /// 程序集版本
        /// </summary>
        public const string Version = "10.1.1";
        /// <summary>
        /// 文件版本
        /// </summary>
        public const string FileVersion = "10.1.1";
        /// <summary>
        /// 程序文本说明
        /// </summary>
        public const string Description = "警告：本计算机程序受著作权法和国际条约保护。如未经授权而擅自复制或传播本程序（或其中任何部分），将受到严厉的民事和刑事制裁，并将在法律许可的最大限制内受到起诉。";
    }
}