using be.Models;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.ComponentRepository
{

    public class ComponentRepository : IComponentRepository
    {
        private readonly DbJiraCloneContext _context;

        public ComponentRepository()
        {
            _context = new DbJiraCloneContext();
        }

        public object AddComponent(Component component)
        {
            try
            {
                _context.Components.Add(component);
                _context.SaveChanges();
                return component;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void ChangeStatus(Component component)
        {
            try
            {
                var updateStatusComponent = _context.Components.SingleOrDefault(x => x.ComponentId == component.ComponentId);
                updateStatusComponent.Status = component.Status;
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public IList<Component> GetAllComponent()
        {
            return _context.Components.ToList();
        }

        public IList<string> GetAllComponentName()
        {
            var componentNames = (from component in _context.Components
                                  select component.ComponentName).ToList();
            return componentNames;
        }

        public Component GetComponentInformation(int componentId)
        {
            try
            {
                var componentDetail = _context.Components.SingleOrDefault(x => x.ComponentId == componentId);
                return componentDetail;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Component UpdateComponent(Component component)
        {
            try
            {
                var updateComponent = _context.Components.SingleOrDefault(x => x.ComponentId == component.ComponentId);
                updateComponent.ComponentName = component.ComponentName;
                _context.SaveChanges();
                return updateComponent;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
