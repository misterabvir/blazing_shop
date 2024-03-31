using Contracts.Products;
using Microsoft.AspNetCore.Components;
using Shared.Pagination;

namespace Client.Pages.ProductLists
{
    public partial class ProductList
    {

        [Parameter]
        public Pagination<ProductContract> Pagination { get; set; } = null!;
        [Parameter]
        public string CategoryUrl { get; set; } = string.Empty;

        [Parameter]
        public EventCallback<int> OnPageSizeChangedEvent { get; set; }

        private async Task OnPageSizeChanged(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value?.ToString(), out int pageSize))
            {
                await OnPageSizeChangedEvent.InvokeAsync(pageSize);
            }
        }
    }
}