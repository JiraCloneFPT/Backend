using be.Models;

namespace be.Repositories.ComponentRepository
{
    public interface IComponentRepository
    {
        object AddComponent(Component component);
        IList<Component> GetAllComponent();
        void ChangeStatus(Component component);
        Component UpdateComponent(Component component);
        Component GetComponentInformation(int componentId);

        IList<string> GetAllComponentName();
    }
}
