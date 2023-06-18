using be.DTOs;

namespace be.Commons
{
    /// <summary>
    /// Class common hard data / Enum common data
    /// </summary>
    public class EnumCommon
    {
        public List<ObjDTO> Severitys = new List<ObjDTO>()
        {
            new ObjDTO() { Id = 0, Value = "None"},
            new ObjDTO() { Id = 1, Value = "Cosmetic"},
            new ObjDTO() { Id = 2, Value = "Medium"},
            new ObjDTO() { Id = 3, Value = "Serious"},
            new ObjDTO() { Id = 4, Value = "Fatal"}
        };

        public List<ObjDTO> Complexities = new List<ObjDTO>()
        {
            new ObjDTO() { Id = 0, Value = "None"},
            new ObjDTO() { Id = 1, Value = "1"},
            new ObjDTO() { Id = 2, Value = "2"},
            new ObjDTO() { Id = 3, Value = "3"},
            new ObjDTO() { Id = 4, Value = "4"},
            new ObjDTO() { Id = 5, Value = "5"}
        };

        public List<ObjDTO> Labels = new List<ObjDTO>()
        {
            new ObjDTO() { Id = 0, Value = "None"},
            new ObjDTO() { Id = 1, Value = "Allowance"},
            new ObjDTO() { Id = 2, Value = "ALLOWANCE"},
            new ObjDTO() { Id = 3, Value = "NO_Allowance"},
            new ObjDTO() { Id = 4, Value = "NO_ALLOWANCE"},
        };

        public List<ObjDTO> Sprints = new List<ObjDTO>()
        {
            new ObjDTO() { Id = 0, Value = "None"},
            new ObjDTO() { Id = 1, Value = "[SKU] Bảng kế hoạch (Active sprint in SKU_Delivery)"},
            new ObjDTO() { Id = 2, Value = "[SKU] Ticket triển khai (Active sprint in SKU_Consultant)"},
            new ObjDTO() { Id = 3, Value = "HN21_FR_Sprint 3 (Active sprint in HN21_FR_TEST_01)"},
            new ObjDTO() { Id = 4, Value = "HN21_FRF_FJW_03_Sprin 1 (Active sprint in HN21_FRF_FJW_03)"},
        };

        public List<ObjDTO> FunctionCategories = new List<ObjDTO>()
        {
            new ObjDTO() { Id = 0, Value = "None"},
            new ObjDTO() { Id = 1, Value = "Create_New_Class"},
            new ObjDTO() { Id = 2, Value = "Login"},
            new ObjDTO() { Id = 3, Value = "Submit_class"},
            new ObjDTO() { Id = 4, Value = "Cancel_class"},
            new ObjDTO() { Id = 5, Value = "Search_class"},
        };

        public List<ObjDTO> LinkedIssues = new List<ObjDTO>()
        {
            new ObjDTO() { Id = 0, Value = "None"},
            new ObjDTO() { Id = 1, Value = "blocks"},
            new ObjDTO() { Id = 2, Value = "is blocked by"},
            new ObjDTO() { Id = 3, Value = "clones"},
            new ObjDTO() { Id = 4, Value = "is child task of"},
            new ObjDTO() { Id = 5, Value = "is parent task of"},
        };

        public List<ObjDTO> EpicLinks = new List<ObjDTO>()
        {
            new ObjDTO() { Id = 0, Value = "None"},
            new ObjDTO() { Id = 1, Value = "Group02_Movie_Theater_Sprint1 - (FSOFTACADEMY-9349)"},
            new ObjDTO() { Id = 2, Value = "Group1_Java04_Movie_Theater - (FSOFTACADEMY-9346)"},
            new ObjDTO() { Id = 3, Value = "Group1_Movie_Booking_Sprint01 - (FSOFTACADEMY-9340)"},
            new ObjDTO() { Id = 4, Value = "SRUMS_Groups4_Sprint_3 - (FSOFTACADEMY-3179)"},
            new ObjDTO() { Id = 5, Value = "SRUMS_Groups4_Sprint_3 - (FSOFTACADEMY-3179)"},
        };

        public List<ObjDTO> SecurityLevels = new List<ObjDTO>()
        {
            new ObjDTO() { Id = 0, Value = "None"},
            new ObjDTO() { Id = 1, Value = "EXTERNAL"},
            new ObjDTO() { Id = 2, Value = "INTERNAL"},
            new ObjDTO() { Id = 3, Value = "CONFIDENTIAL"}
        };

    }

    public enum RoleUsers
    {
        admin = 1,
        user = 2
    }

}
