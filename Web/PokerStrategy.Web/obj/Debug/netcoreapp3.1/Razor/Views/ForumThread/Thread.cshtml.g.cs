#pragma checksum "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a633a26ee30240730f6e6e235a1a4e2466d44bd2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ForumThread_Thread), @"mvc.1.0.view", @"/Views/ForumThread/Thread.cshtml")]
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
#line 1 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\_ViewImports.cshtml"
using PokerStrategy.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\_ViewImports.cshtml"
using PokerStrategy.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a633a26ee30240730f6e6e235a1a4e2466d44bd2", @"/Views/ForumThread/Thread.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc4b19ae484db31eb17f59d204b2bd7a4273d594", @"/Views/_ViewImports.cshtml")]
    public class Views_ForumThread_Thread : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PokerStrategy.Web.ViewModels.Forum.ThreadModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Forum", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Category", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-back"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ForumReply", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-newReply"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a633a26ee30240730f6e6e235a1a4e2466d44bd27050", async() => {
                WriteLiteral("\r\n\t\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a633a26ee30240730f6e6e235a1a4e2466d44bd27312", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<header>\r\n\t<span class=\"postIndexTitle\">\r\n\t\t");
#nullable restore
#line 7 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t</span>\r\n</header>\r\n<div class=\"container body-content\">\r\n\t<div class=\"row postHeader\">\r\n\t\t<div class=\"postHeading\">\r\n\t\t\t<span id=\"headingBtn\">\r\n\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a633a26ee30240730f6e6e235a1a4e2466d44bd29747", async() => {
                WriteLiteral("\r\n\t\t\t\t\t<b>Back to ");
#nullable restore
#line 15 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                          Write(Model.CategoryTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b>\r\n\t\t\t\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                                                                  WriteLiteral(Model.CategoryId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t</span>\r\n\t\t</div>\r\n\t</div>\r\n\t<!--\r\n\t<div class=\"row\" id=\"postIndexContent\">\r\n\t\t<div class=\"col-md-3 postAuthorContainer\">\r\n\t\t\t<div class=\"postAuthorImage\" style=\"background-image: url(");
#nullable restore
#line 23 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                                                                 Write(Model.PostedByAvatarUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("); background-size: 100%;\"></div>\r\n\t\t\t<a asp-controller=\"Profile\" asp-action=\"Detail\" asp-route-id=\"");
#nullable restore
#line 24 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                                                                     Write(Model.PostedById);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n\t\t\t\t<strong>");
#nullable restore
#line 25 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                   Write(Model.PostedByName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n\t\t\t</a> (<span class=\"postAuthorRating\">");
#nullable restore
#line 26 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                                            Write(Model.UserPoints);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>) <br />\r\n\t\t\t<span class=\"postDate\">");
#nullable restore
#line 27 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                              Write(Model.CreatedOn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\r\n\t\t</div>\r\n\r\n\t<div class=\"col-md-9 postContentContainer\">\r\n\t\t<div class=\"postContent\">\r\n\t\t\t");
#nullable restore
#line 33 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
       Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</div>\r\n\t</div>\r\n\t\t-->\r\n</div>\r\n\r\n\t<div class=\"row\" id=\"replyDivider\"></div>\r\n");
#nullable restore
#line 40 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
     if (Context.User.Identity.IsAuthenticated)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div class=\"row\" id=\"replyRow\">\r\n\t\t<span>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a633a26ee30240730f6e6e235a1a4e2466d44bd215143", async() => {
                WriteLiteral("Reply");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                                                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n\t</div>\r\n");
#nullable restore
#line 45 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 47 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
         foreach (var reply in Model.Replies)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<div class=\"row replyContent\">\r\n\t\t\t<div class=\"col-md-3 replyAuthorContainer\">\r\n\t\t\t\t<div class=\"postAuthorImage\"");
            BeginWriteAttribute("style", " style=\"", 1578, "\"", 1657, 6);
            WriteAttributeValue("", 1586, "background-image:", 1586, 17, true);
            WriteAttributeValue(" ", 1603, "url(", 1604, 5, true);
#nullable restore
#line 51 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
WriteAttributeValue("", 1608, reply.PostedByAvatarUrl, 1608, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1632, ");", 1632, 2, true);
            WriteAttributeValue(" ", 1634, "background-size:", 1635, 17, true);
            WriteAttributeValue(" ", 1651, "100%;", 1652, 6, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a633a26ee30240730f6e6e235a1a4e2466d44bd219010", async() => {
                WriteLiteral("\r\n\t\t\t\t\t<strong>");
#nullable restore
#line 53 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                       Write(reply.PostedByName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n\t\t\t\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                                                                  WriteLiteral(reply.PostedById);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" (<span class=\"postAuthorRating\">");
#nullable restore
#line 54 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                                                Write(reply.PostedByPoints);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>) <br />\r\n\t\t\t\t<span class=\"postDate\">");
#nullable restore
#line 55 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                                  Write(reply.RepliedOn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t</div>\r\n\t\t\t<div class=\"col-md-9 replyContentContainer\">\r\n\t\t\t\t<div class=\"postContent\">\r\n\t\t\t\t\t");
#nullable restore
#line 59 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
                Write(reply.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div> \r\n");
#nullable restore
#line 63 "D:\Users\Kolio\Desktop\PokerStrategy\Web\PokerStrategy.Web\Views\ForumThread\Thread.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PokerStrategy.Web.ViewModels.Forum.ThreadModel> Html { get; private set; }
    }
}
#pragma warning restore 1591