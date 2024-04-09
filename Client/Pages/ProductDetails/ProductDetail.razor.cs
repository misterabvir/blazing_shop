using Microsoft.AspNetCore.Components;
using Contracts.Products;
namespace Client.Pages.ProductDetails
{
    public partial class ProductDetail
    {
        [Parameter]
        public string Id { get; set; } = string.Empty;
        private bool isLoading = false;
        private ProductResponse? _product;
        private bool _isExist => _product is not null;
        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(Id, out Guid value))
            {
                isLoading = true;
                var result = await _productService.GetProductById(value);
                if (result.IsSuccess)
                {
                    _product = result.Value!;
                }
                isLoading = false;
            }
        }
    }
}