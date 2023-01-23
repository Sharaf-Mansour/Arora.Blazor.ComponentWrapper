using Microsoft.AspNetCore.Components;
using System.Reflection;
namespace Arora.Blazor.ComponentWrapper;
public partial class AroraComponent
{
    [Parameter]
    public required string ElementName { get; set; }

    RenderFragment? RenderChild;
    protected override void OnInitialized()
    {
        RenderChild = new(builder =>
        {
            Type classType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.FullName!.ToLower().Contains(ElementName.ToLower())) ?? throw new NullReferenceException("Wrong Name");
            builder.OpenComponent(0, classType);
            builder.CloseComponent();
        });
    }
}