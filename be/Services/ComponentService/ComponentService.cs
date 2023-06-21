using be.Models;
using be.Repositories.ComponentRepository;

namespace be.Services.ComponentService
{
    public class ComponentService : IComponentService
    {
        public IComponentRepository _componentRepo;

        public ComponentService(IComponentRepository componentRepository)
        {
            _componentRepo = componentRepository;
        }
        public object AddComponent(Component component)
        {
            _componentRepo.AddComponent(component);
            return component;
        }

        public void ChangeStatus(Component component)
        {
            _componentRepo.ChangeStatus(component);
        }

        public IList<Component> GetAllComponent()
        {
            return _componentRepo.GetAllComponent().ToList();
        }

        public IList<string> GetAllComponentName()
        {
            return _componentRepo.GetAllComponentName().ToList();
        }

        public Component GetComponentInformation(int componentId)
        {
            return _componentRepo.GetComponentInformation(componentId);
        }

        public Component UpdateComponent(Component component)
        {
            _componentRepo.UpdateComponent(component);
            Component updateComponent = _componentRepo.GetComponentInformation(component.ComponentId);
            return updateComponent;
        }
    }
}
