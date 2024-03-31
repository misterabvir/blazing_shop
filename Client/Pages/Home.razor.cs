using Contracts.Categories;
using Contracts.Products;
using Microsoft.AspNetCore.Components;
using Shared.Pagination;

namespace Client.Pages
{
    public partial class Home
    {
        [Parameter]
        public string? Url { get; set; }
        [Parameter]
        public string? Page { get; set; }

        private int _pageSize { get; set; } = 5; //TODO  will be refactored
        private int _pageNumber => int.TryParse(Page, out int page) ? page : 1;
        private string _categoryUrl = string.Empty;
        private bool _isLoading = false;
        private Pagination<ProductContract> Pagination { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await Load();
        }

        protected override async Task OnParametersSetAsync()
        {
            await Load();
        }

        private async Task OnPageSizeChanged(int pageSize)
        {
            _pageSize = pageSize;
            await Load();
        }

        public async Task Load()
        {
            _isLoading = true;
            if (Url is not null)
            {
                var result = await _categoryService.GetCategoryByUrl(Url.ToLower());

                if (result.IsSuccess)
                {
                    await LoadByCategory(result.Value!);
                }
                else
                {
                    _categoryUrl = string.Empty;
                    _toastMessageService.AddErrorMessage(result.Errors.First());
                    await LoadAll();
                }
            }
            else
            {
                await LoadAll();
            }
            _isLoading = false;
        }

        private async Task LoadByCategory(CategoryContract category)
        {
            var result = await _productService.GetProductsByCategory(category.Id, _pageNumber, _pageSize);
            if (result.IsSuccess)
            {
                Pagination = result.Value!;
                _categoryUrl = category.Url;
            }
            else
            {
                _toastMessageService.AddErrorMessage(result.Errors.First());
            }
        }

        private async Task LoadAll()
        {
            _categoryUrl = string.Empty;
            var result = await _productService.GetProducts(_pageNumber, _pageSize);
            if (result.IsSuccess)
            {
                Pagination = result.Value!;
            }
            else
            {
                _toastMessageService.AddErrorMessage(result.Errors.First());
            }
        }
    }
}