#pragma checksum "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb1e6c93fefb59fc21f6886ea29199c8b05d8688"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Consumer_ConsumerBusinessDetail), @"mvc.1.0.view", @"/Views/Consumer/ConsumerBusinessDetail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\_ViewImports.cshtml"
using Insureity_Portal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\_ViewImports.cshtml"
using Insureity_Portal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb1e6c93fefb59fc21f6886ea29199c8b05d8688", @"/Views/Consumer/ConsumerBusinessDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de72c247640d4dc4510eebc6750f6e74a9a14a58", @"/Views/_ViewImports.cshtml")]
    public class Views_Consumer_ConsumerBusinessDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Insureity_Portal.Models.ConsumerBusinessDetails>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
  
    ViewData["Title"] = "Consumer Business";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h4>Consumer Business Details</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 12 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.ConsumerId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 15 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.ConsumerId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 18 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.ConsumerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 21 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.ConsumerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 24 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 27 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 30 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.Pan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 33 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.Pan));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 36 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.AgentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 39 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.AgentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 42 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.AgentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 45 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.AgentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 48 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.BusinessId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 51 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.BusinessId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 54 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.ValidityofConsumer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 57 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.ValidityofConsumer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 60 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.BusinessOverview));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 63 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.BusinessOverview));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 66 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.BusinessType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 69 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.BusinessType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 72 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.AnnualTurnOver));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 75 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.AnnualTurnOver));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 78 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalEmployees));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 81 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.TotalEmployees));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 84 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.CapitalInvested));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 87 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.CapitalInvested));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 90 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.BusinessValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 93 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
       Write(Html.DisplayFor(model => model.BusinessValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 98 "C:\Final Project\Insureity-Portal\Insureity-Portal\Views\Consumer\ConsumerBusinessDetail.cshtml"
Write(Html.ActionLink("UpdateConsumerBusiness", "UpdateConsumerBusiness", new { consumerId = Model.ConsumerId, BusinessId = Model.BusinessId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Insureity_Portal.Models.ConsumerBusinessDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
