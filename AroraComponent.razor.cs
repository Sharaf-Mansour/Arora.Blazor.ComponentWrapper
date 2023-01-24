using Microsoft.AspNetCore.Components;
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
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var classType = assembly.GetTypes().FirstOrDefault(t => t.FullName!.ToLower().Contains(ElementName.ToLower()));
                if (classType is not null)
                {
                    builder.OpenComponent(0, classType);
                    builder.CloseComponent();
                    return;
                }
            }
        });
    }
}