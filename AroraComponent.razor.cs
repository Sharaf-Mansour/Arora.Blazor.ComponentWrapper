using Microsoft.AspNetCore.Components;
namespace Arora.Blazor.ComponentWrapper;
public partial class AroraComponent
{
    [Parameter]
    public required Type ElementType { get; set; }
    private RenderFragment? RenderChild;
    protected override void OnInitialized()
    {
        RenderChild = (builder =>
        {
            builder.OpenComponent(0, ElementType);
            builder.CloseComponent();
        });
    }
}