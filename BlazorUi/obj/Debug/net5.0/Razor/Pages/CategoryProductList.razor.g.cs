#pragma checksum "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b8868e2bd07faeb2557cce890768237996be06d"
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
#line 3 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
using Core.Dtos.CategoryDto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/categoryProductList/{categoryId:int}")]
    public partial class CategoryProductList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h3");
            __builder.AddContent(1, "Product List For ");
#nullable restore
#line 11 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
__builder.AddContent(2, category.Name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 12 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
 if (category.Products == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(3, "<p><em>Loading...</em></p>");
#nullable restore
#line 15 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "type", "submit");
            __builder.AddAttribute(6, "class", "btn btn-success");
            __builder.AddAttribute(7, "value", "Urunlere git");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
                                                                                 (()=> CreateProduct())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(9, "Urun Olustur");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n    ");
            __builder.OpenElement(11, "table");
            __builder.AddAttribute(12, "class", "table");
            __builder.AddMarkupContent(13, "<thead><tr><th>Name</th>\r\n                <th>Price</th>\r\n                <th>Sold Status</th>\r\n                <th></th></tr></thead>\r\n        ");
            __builder.OpenElement(14, "tbody");
#nullable restore
#line 29 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
             foreach (var product in category.Products)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(15, "tr");
            __builder.OpenElement(16, "td");
#nullable restore
#line 32 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
__builder.AddContent(17, product.Name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                    ");
            __builder.OpenElement(19, "td");
#nullable restore
#line 33 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
__builder.AddContent(20, product.Price);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                    ");
            __builder.OpenElement(22, "td");
#nullable restore
#line 34 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
__builder.AddContent(23, product.IsSold);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                    ");
            __builder.OpenElement(25, "td");
            __builder.OpenElement(26, "button");
            __builder.AddAttribute(27, "class", "btn btn-primary");
            __builder.AddAttribute(28, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
                                                                  (()=>ShowProduct(product.Id))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(29, "Detay Gor");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 37 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 40 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "C:\Users\sentu\Source\Repos\WardrobeProject\BlazorUi\Pages\CategoryProductList.razor"
       
    [Parameter]
    public int categoryId { get; set; }
    public CategoryDto category = new();
   

    protected override async Task OnInitializedAsync()
    {
        var client = ClientFactory.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44320/api/category/ProductsByCategoryId/{categoryId}");
        var token = await Storage.GetAsync<string>("token");

        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Value);

        var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            category = System.Text.Json.JsonSerializer.Deserialize<CategoryDto>(json);           
        }
        
    }

    void ShowProduct(int id)
    {
        navigation.NavigateTo($"product/{id}");
    }
    void CreateProduct()
    {
        navigation.NavigateTo("createProduct");
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpClientFactory ClientFactory { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage Storage { get; set; }
    }
}
#pragma warning restore 1591
