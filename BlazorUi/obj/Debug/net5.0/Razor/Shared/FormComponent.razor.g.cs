#pragma checksum "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Shared\FormComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6be57cbff00ffbfee577d1a2bedee8becfeb9746"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorUi.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using BlazorUi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using BlazorUi.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Core.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Core.Dtos.UserDto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Core.Dtos.CategoryDto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Core.Dtos.ColorDto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Core.Dtos.OfferDto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Core.Dtos.BrandDto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Core.Dtos.UsageStatus;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Core.Dtos.ProductDto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using BlazorUi.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Shared\FormComponent.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
    public partial class FormComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 6 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Shared\FormComponent.razor"
                  user

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 6 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Shared\FormComponent.razor"
                                        Submit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(4);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(5, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(6);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(7, "\r\n    ");
                __builder2.OpenElement(8, "section");
                __builder2.AddAttribute(9, "class", "vh-100");
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "class", "container-fluid h-custom");
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", "row d-flex justify-content-center align-items-center h-100");
                __builder2.AddMarkupContent(14, "<h3>Login Component</h3>\r\n                ");
                __builder2.AddMarkupContent(15, "<div class=\"col-md-9 col-lg-6 col-xl-5\"><img src=\"https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp\" class=\"img-fluid\" alt=\"Sample image\"></div>\r\n                ");
                __builder2.OpenElement(16, "div");
                __builder2.AddAttribute(17, "class", "col-md-8 col-lg-6 col-xl-4 offset-xl-1");
                __builder2.OpenElement(18, "div");
                __builder2.AddAttribute(19, "class", "form-outline mb-4");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(20);
                __builder2.AddAttribute(21, "type", "email");
                __builder2.AddAttribute(22, "class", "form-control form-control-lg");
                __builder2.AddAttribute(23, "id", "email");
                __builder2.AddAttribute(24, "placeholder", "Enter a valid email address");
                __builder2.AddAttribute(25, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Shared\FormComponent.razor"
                                                                                                             user.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(26, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => user.Email = __value, user.Email))));
                __builder2.AddAttribute(27, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => user.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(28, "\r\n                        ");
                __builder2.AddMarkupContent(29, "<label class=\"form-label\" for=\"email\">Email address</label>");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n\r\n                    \r\n                    ");
                __builder2.OpenElement(31, "div");
                __builder2.AddAttribute(32, "class", "form-outline mb-3");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(33);
                __builder2.AddAttribute(34, "type", "password");
                __builder2.AddAttribute(35, "class", "form-control form-control-lg");
                __builder2.AddAttribute(36, "id", "password");
                __builder2.AddAttribute(37, "placeholder", "Enter password");
                __builder2.AddAttribute(38, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 30 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Shared\FormComponent.razor"
                                                                                                                   user.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(39, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => user.Password = __value, user.Password))));
                __builder2.AddAttribute(40, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => user.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(41, "\r\n                        ");
                __builder2.AddMarkupContent(42, "<label class=\"form-label\" for=\"password\">Password</label>");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(43, "\r\n\r\n                    ");
                __builder2.AddMarkupContent(44, "<div class=\"text-center text-lg-start mt-4 pt-2\"><button type=\"submit\" class=\"btn btn-primary btn-lg\" style=\"padding-left: 2.5rem; padding-right: 2.5rem;\">\r\n                            Login\r\n                        </button></div>");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 51 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Shared\FormComponent.razor"
 if (message != null)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(45, "p");
#nullable restore
#line 53 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Shared\FormComponent.razor"
__builder.AddContent(46, message);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 54 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Shared\FormComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 56 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Shared\FormComponent.razor"
       
    private UserLoginDto user = new();
    private CustomResponseDto<NoContentDto> response = new();
    private string message = null;

    private async Task Submit()
    {

        var client = ClientFactory.CreateClient();
        //var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/user/Login");

        //request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "token");

        var result = await client.PostAsJsonAsync($"https://localhost:5001/api/user/Login", user);
        if (result.IsSuccessStatusCode)
        {
            string token = await result.Content.ReadAsStringAsync();

            await Storage.SetAsync("token", token);
        }
        else
        {
            navigation.NavigateTo($"categoryList");
        }


    }
    private void ShowRegisterPage()
    {
        navigation.NavigateTo($"register");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage Storage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpClientFactory ClientFactory { get; set; }
    }
}
#pragma warning restore 1591
