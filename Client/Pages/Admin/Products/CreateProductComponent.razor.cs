using Contracts.Categories;
using Contracts.Products;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Client.Pages.Admin.Products;

public partial class CreateProductComponent
{
    private ProductCreateRequest Model { get; set; } = new();
    private DataAnnotationsValidator DataAnnotationsValidator { get; set; } = new();
    private List<CategoryContract> _categories = [];

    private bool IsContains(Guid id) => Model.Variants.FirstOrDefault(v => v.PublishVariantId == id) != null;

    private void ChangeVariantPrice(ChangeEventArgs e, Guid id)
    {
        var variant = Model.Variants.FirstOrDefault(v => v.PublishVariantId == id);

        if (variant is not null && decimal.TryParse(e.Value?.ToString(), out decimal price))
        {
            variant.Price = price;
        }
    }

    private async Task CreateProduct()
    {
        var result = await _productService.CreateProduct(Model);
        if (result.IsSuccess)
        {
            _toastMessageService.AddSuccessMessage("Product created");
            Model = new();
        }
    }


    private void CategoryChanged()
    {
        Model.Variants.Clear();
    }

    private void ChangeVariants(bool flag, Guid id)
    {

        if (flag)
            Model.Variants.Add(new ProductVariantCreateRequest() { PublishVariantId = id, Price = 0 });
        else
        {
            Model.Variants.RemoveAll(v => v.PublishVariantId == id);
        }
        Console.WriteLine(Model.Variants.Count);
    }

    protected override async Task OnInitializedAsync()
    {
        _categories = (await _categoryService.GetCategories()).Value!.ToList();
    }
}