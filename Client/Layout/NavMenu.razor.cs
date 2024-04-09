using Contracts.Categories;
using Shared.Results;

namespace Client.Layout
{
    public partial class NavMenu : IDisposable
    {
        public List<CategoryContract> Categories { get; private set; } = [];

        private bool _collapseNavMenu = true;

        private string? NavMenuCssClass => _collapseNavMenu ? "collapse" : null;

        public void Dispose()
        {
            if (_categoryService.OnCategoriesChangedEvent is not null)
            {
#pragma warning disable CS8601
                _categoryService.OnCategoriesChangedEvent -= CategoriesChanged;
#pragma warning restore CS8601
            }
        }

        protected override async Task OnInitializedAsync()
        {

            var result = await _categoryService.GetCategories();
            if (result.IsSuccess)
            {
                Categories = result.Value!.ToList()!;
                _categoryService.OnCategoriesChangedEvent += CategoriesChanged;
            }
        }

        private void CategoriesChanged(Result<CategoryContract> result)
        {
            if (result.IsSuccess)
            {
                Categories.Add(result.Value!);
                StateHasChanged();
                _toastService.AddSuccessMessage("Category added");
            }
        }

        private void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }
    }
}