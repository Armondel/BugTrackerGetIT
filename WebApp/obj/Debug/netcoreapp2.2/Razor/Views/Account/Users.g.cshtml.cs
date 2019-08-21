#pragma checksum "C:\Users\dimae\source\repos\BugTrackerGetIT\WebApp\Views\Account\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b15f4a98b4c6d2975746c3445058cc5b97dfc51e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Users), @"mvc.1.0.view", @"/Views/Account/Users.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Users.cshtml", typeof(AspNetCore.Views_Account_Users))]
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
#line 1 "C:\Users\dimae\source\repos\BugTrackerGetIT\WebApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\dimae\source\repos\BugTrackerGetIT\WebApp\Views\_ViewImports.cshtml"
using BugTrackerGetIT;

#line default
#line hidden
#line 3 "C:\Users\dimae\source\repos\BugTrackerGetIT\WebApp\Views\_ViewImports.cshtml"
using BugTrackerGetIT.WebApp.Models;

#line default
#line hidden
#line 4 "C:\Users\dimae\source\repos\BugTrackerGetIT\WebApp\Views\_ViewImports.cshtml"
using BugTrackerGetIT.WebApp.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\dimae\source\repos\BugTrackerGetIT\WebApp\Views\_ViewImports.cshtml"
using BugTrackerGetIT.WebApp.Models.ManageViewModels;

#line default
#line hidden
#line 6 "C:\Users\dimae\source\repos\BugTrackerGetIT\WebApp\Views\_ViewImports.cshtml"
using BugTrackerGetIT.WebApp.Models.TrackerViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b15f4a98b4c6d2975746c3445058cc5b97dfc51e", @"/Views/Account/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2637a209795f1ed7e6435c35e68bf298a6980842", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\dimae\source\repos\BugTrackerGetIT\WebApp\Views\Account\Users.cshtml"
  
	ViewData["Title"] = "Users";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(84, 238, true);
            WriteLiteral("\r\n<h2>Users</h2>\r\n\r\n<table id=\"userTable\" class=\"table table-bordered table-hover\">\r\n\t<thead>\r\n\t\t<tr>\r\n\t\t\t<th>Id</th>\r\n\t\t\t<th>Username</th>\r\n\t\t\t<th>First Name</th>\r\n\t\t\t<th>Last Name</th>\r\n\t\t</tr>\r\n\t</thead>\r\n\t<tbody></tbody>\r\n</table>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(339, 627, true);
                WriteLiteral(@"
	<script src=""https://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.2.0.min.js""></script>
	<script src=""https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js""></script>
	<script src=""https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap4.min.js""></script>
	<script>
		$(document).ready(function () {
			$('#userTable').dataTable({
				ajax: {
					url: ""/api/getuserlist"",
					dataSrc: """"
				},
				columns: [
					{
						data: ""id""
					},
					{
						data: ""userName""
					},
					{
						data: ""firstName""
					},
					{
						data: ""lastName""
					}
				]

			});
		});
	</script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591