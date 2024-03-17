using gmis.Application.Contracts.Persistence.Industries;
using Microsoft.EntityFrameworkCore.Storage;

namespace gmis.Application.Contracts.Persistence.Base
{
    public interface IRepositoryManager
    {
        Task SaveAsync();
        IDbContextTransaction BeginTran();


        #region Line Of Business
        ILineOfBusinessRepository LineOfBusinessRepository { get; }
        #endregion

        IIndustriesRepository IndustriesRepository { get; }
        INotesRepository NotesRepository { get; }
    }
}
