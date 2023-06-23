using AutoMapper;
using be.DTOs;
using be.Models;
using DocumentFormat.OpenXml.VariantTypes;

namespace be.Helpers
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Issue, IssueDTO>();
                cfg.CreateMap<History, HistoryDTO>();
                cfg.CreateMap<HistoryDTO, HistoryCompareDTO>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }

    }
}
