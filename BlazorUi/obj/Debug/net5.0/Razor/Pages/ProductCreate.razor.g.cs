#pragma checksum "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\ProductCreate.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dbd83feff0294aef25d37990778db88f3520b83"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorUi.Pages
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
#line 25 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
    public partial class ProductCreate : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Component1</h3>");
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\ProductCreate.razor"
       
    public PostProductDto PostProductDto { get; set; }
    protected override Task OnInitializedAsync()
    {
        var client = ClientFactory.CreateClient();
        var result = client.PostAsJsonAsync<PostProductDto>($"https://localhost:5001/api/product", PostProductDto);
        return result;

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpClientFactory ClientFactory { get; set; }
    }
}
#pragma warning restore 1591
