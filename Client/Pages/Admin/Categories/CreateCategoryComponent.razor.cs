using Client.Services.Icons;
using Contracts;

namespace Client.Pages.Admin.Categories
{
    public partial class CreateCategoryComponent
    {
        private Icon Icon { get; set; } = Icon.Empty;
        private string Title { get; set; } = string.Empty;
        private string Url => Title.Trim().Replace(" ", "-").ToLower();
        private bool IsDisabled => Icon == Icon.Empty || string.IsNullOrEmpty(Title);
        void IconChanged(Icon icon)
        {
            Icon = icon;
        }

        private async Task CreateCategory()
        {
            var category = new CategoryContract()
            {
                Title = Title,
                Url = Url,
                Icon = Icon.Value
            };

            await _categoryService.Create(category);
        }
    }
}