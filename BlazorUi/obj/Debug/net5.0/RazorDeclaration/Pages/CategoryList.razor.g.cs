// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorUi.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using BlazorUi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using BlazorUi.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using Core.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using Core.Dtos.UserDto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/_Imports.razor"
using Core.Dtos.ProductDto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/Pages/CategoryList.razor"
using Core.Dtos.CategoryDto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/Pages/CategoryList.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/categoryList")]
    public partial class CategoryList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 34 "/Users/gozdecengiz/Desktop/Wardrobe-main/BlazorUi/Pages/CategoryList.razor"
       
    public List<CategoryDto> categoryList;

    protected override async Task OnInitializedAsync()
    {
        var client = ClientFactory.CreateClient();
        categoryList = await client.GetFromJsonAsync<List<CategoryDto>>("https://localhost:5001/api/category/getall");

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpClientFactory ClientFactory { get; set; }
    }
}
#pragma warning restore 1591
