using Microsoft.AspNetCore.Components;
using System.Reflection;
namespace Arora.Blazor.ComponentWrapper;
public partial class AroraComponent
{
 [Parameter]
    public required string ElementName { get; set; }
    [Parameter]
    public required Assembly Assembly { get; set; }
    RenderFragment? RenderChild;
    protected override void OnInitialized()
    {
        RenderChild = new(builder =>
        {
            Type classType = Assembly.GetTypes().FirstOrDefault(t => t.FullName!.Contains(ElementName)) ?? throw new NullReferenceException("Wrong Name");
            builder.OpenComponent(0, classType);
            builder.CloseComponent();
        });
    }
}