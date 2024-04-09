using Contracts.Categories;
using Contracts.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Results;

namespace Client.Pages.Admin.Products;

public partial class EditProductPage
{

    [Parameter]
    public string Id { get; set; } = string.Empty;
    private bool isLoading = false;
    private ProductResponse _product = new();
    private bool _isExist => _product is not null;
    private ProductUpdateRequest Model { get; set; } = new();
    private DataAnnotationsValidator DataAnnotationsValidator { get; set; } = new();
    private List<CategoryContract> _categories { get; set; } = [];

    private bool IsSelectedCategory(Guid id) => Model.CategoryId == id;

    private void ChangeVariantPrice(ChangeEventArgs e, Guid id)
    {
        var variant = Model.Variants.FirstOrDefault(v => v.PublishVariantId == id);

        if (variant is not null && decimal.TryParse(e.Value?.ToString(), out decimal price))
        {
            variant.Price = price;
            StateHasChanged();
        }
    }
    private void ChangeVariantDiscount(ChangeEventArgs e, Guid id)
    {
        var variant = Model.Variants.FirstOrDefault(v => v.PublishVariantId == id);

        if (variant is not null && double.TryParse(e.Value?.ToString(), out double discount))
        {
            variant.Discount = discount;
            StateHasChanged();
        }
    }
    private bool IsContains(Guid id) => Model.Variants.FirstOrDefault(v => v.PublishVariantId == id) != null;

    private float GetPrice(Guid publishVariantId) => (float)(Model.Variants.FirstOrDefault(v => v.PublishVariantId == publishVariantId)?.Price ?? 0);

    private float GetDiscount(Guid publishVariantId) => (float)(Model.Variants.FirstOrDefault(v => v.PublishVariantId == publishVariantId)?.Discount ?? 0);

    private void CategoryChanged() => Model.Variants.Clear();

    private void ChangeVariants(bool flag, Guid id)
    {
        if (flag)
            Model.Variants.Add(new ProductVariantUpdateRequest() { PublishVariantId = id, Price = 0, Discount = 0 });
        else
        {
            Model.Variants.RemoveAll(v => v.PublishVariantId == id);
        }

    }
    protected override async Task OnInitializedAsync()
    {
        if (Guid.TryParse(Id, out Guid value))
        {

            isLoading = true;
            var result = await _productService.GetProductById(value);
            if (result.IsSuccess)
            {
                _product = result.Value!;
                ToModel();
            }
            else
            {
                _toastMessageService.AddErrorMessage(result.Errors.First());
            }
            var categoriesResult = await _categoryService.GetCategories();
            if (categoriesResult.IsSuccess)
            {
                _categories = categoriesResult.Value!.ToList();
                ToModel();
            }
            else
            {
                _toastMessageService.AddErrorMessage(result.Errors.First());
            }
            isLoading = false;
        }
    }

    private void ToModel()
    {
        Model.Id = _product.Id;
        Model.CategoryId = _product.CategoryId;
        Model.Description = _product.Description;
        Model.Title = _product.Title;
        Model.Image = _product.Image;
        Model.Variants = _product.Variants.Select(s => new ProductVariantUpdateRequest()
        {
            PublishVariantId = s.PublishVariantId,
            Price = s.Price,
            Discount = s.Discount
        }).ToList();
    }

    private async Task UpdateProductHandler(EditContext editContext)
    {
        if (!editContext.Validate())
        {
            _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
            return;
        }


        var result = await _productService.UpdateProduct(Model);

        if (result.IsSuccess)
        {
            _toastMessageService.AddSuccessMessage("Product updated successful");
            _product = result.Value!;
            StateHasChanged();
        }
    }

}