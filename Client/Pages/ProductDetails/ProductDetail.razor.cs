using Microsoft.AspNetCore.Components;
using Contracts;
namespace Client.Pages.ProductDetails
{
    public partial class ProductDetail
    {
        [Parameter]
        public string Id { get; set; } = string.Empty;
        private bool isLoading = false;
        private ProductContract? _product;
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
                else
                {
                    _toastMessageService.AddErrorMessage(result.Errors.First());
                }
                isLoading = false;
            }
        }
    }
}