using Mapster;
using Noteboard.Domain.Models;
using Noteboard.UI.Models;

namespace Noteboard.UI.Maps
{
    public class NoteMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Note, NoteViewModel>()
                .Map(dest => dest.Note, src => src.Text);

            config.NewConfig<NoteViewModel, Note>()
                .Map(dest => dest.Text, src => src.Note);
        }
    }
}
