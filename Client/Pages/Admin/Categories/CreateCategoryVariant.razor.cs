using Client.Services.Icons;
using Contracts.Categories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Results;

namespace Client.Pages.Admin.Categories
{
    public partial class CreateCategoryVariant
    {
        private PublishVariantCreateRequest Model { get; set; } = new();
        private DataAnnotationsValidator DataAnnotationsValidator { get; set; } = new();
        private void IconChanged(Icon icon) => Model.Icon = icon.Value;

        [Parameter]
        public EventCallback<PublishVariantCreateRequest> OnCreated { get; set; }

        private async Task Create(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
                return;
            }

            await OnCreated.InvokeAsync(Model);
            Model = new();
        }
    }
}