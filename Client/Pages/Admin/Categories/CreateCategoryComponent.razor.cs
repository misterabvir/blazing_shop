using Client.Services.Icons;
using Contracts.Categories;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Results;

namespace Client.Pages.Admin.Categories
{
    public partial class CreateCategoryComponent
    {
        private CategoryCreateRequest Model { get; set; } = new();
        private bool CanAddVariants => !string.IsNullOrEmpty(Model.Title) && !string.IsNullOrEmpty(Model.Icon);


        private DataAnnotationsValidator DataAnnotationsValidator { get; set; } = new();
        void IconChanged(Icon icon)
        {
            Model.Icon = icon.Value;
        }


        private async Task Create(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
                return;
            }

            await _categoryService.Create(Model);
        }

        private async Task AddVariant(PublishVariantCreateRequest variant)
        {
            Model.PublishVariants.Add(variant);
            await Task.CompletedTask;
        }

        private void Remove(PublishVariantCreateRequest variant)
        {
            Model.PublishVariants.Remove(variant);
        }
    }
}