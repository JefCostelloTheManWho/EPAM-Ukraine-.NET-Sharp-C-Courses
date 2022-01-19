using AutoMapper;

namespace Business
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Book, BookModel>()
                .ForMember(p => p.CardsIds, c => c.MapFrom(card => card.Cards.Select(x => x.CardId)))
                .ReverseMap();

            //TODO: Create mapping for card and card model

            //TODO: Create mapping that combines Reader and ReaderProfile into ReaderModel
            //Before doing reader mapping, learn more about projection in AutoMapper.
            //https://docs.automapper.org/en/stable/Projection.html
            //https://www.infoworld.com/article/3192900/how-to-work-with-automapper-in-csharp.html
        }
    }
}