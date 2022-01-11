using System;
using Mapster;
using Noteboard.DataAccess.Azure.Storage.Models;
using Noteboard.Domain.Models;

namespace Noteboard.Business.Maps
{
    public class NoteMaps : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Note, NoteTableEntity>()
                .Map(dest => dest.RowKey, src => Guid.NewGuid())
                .Map(dest => dest.PartitionKey, src => BusinessConstants.NoteBoardId);
        }
    }
}
