using be.Models;

namespace be.Services.ComponentService
{
    public interface IComponentService
    {
        object AddComponent(Component component);
        IList<Component> GetAllComponent();
        void ChangeStatus(Component component);
        Component UpdateComponent(Component component);
        Component GetComponentInformation(int componentId);

        IList<string> GetAllComponentName();
    }
}
