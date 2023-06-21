using be.Models;

namespace be.DTOs
{
    public class ListItemsOfIssueDTO
    {
        public List<Project>? Projects { get; set; }

        public List<IssueType>? IssueTypes { get; set; }

        public List<Component>? Components { get; set; }

        public List<Product>? Products { get; set; }

        public List<DefectOrigin>? DefectOrigins { get; set; }

        public List<Priority>? Priorities { get; set; }

        public List<ObjDTO>? Severities { get; set; }

        public List<Qcactivity>? QCActivities { get; set; }

        public List<TechnicalCause>? TechnicalCauses { get; set; }

        public List<User>? Assignees { get; set; }

        public List<RoleUser>? Roles { get; set; }

        public List<User>? Reporters { get; set; }

        public List<ObjDTO>? Complexities { get; set; }

        public List<ObjDTO>? Labels { get; set; }

        public List<ObjDTO>? Sprints { get; set; }

        public List<ObjDTO>? FunctionCategories { get; set; }

        public List<ObjDTO>? LinkedIssues { get; set; }

        public List<IssueDTO>? Issues { get; set; }

        public List<ObjDTO>? EpicLinks { get; set; }

        public List<ObjDTO>? SecurityLevels { get; set; }

        public List<DefectType>? DefectTypes { get; set; }

        public List<CauseCategory>? CauseCategories { get; set; }

        public List<LeakCause>? LeakCauses { get; set; }

        // Resolve
        public List<ObjDTO>? ResolutionResolve { get; set; }
        // Cancel
        public List<ObjDTO>? ResolutionCancel { get; set; }
    }
}
