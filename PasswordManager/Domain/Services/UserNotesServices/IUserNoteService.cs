#nullable enable
using CorePersistence.Paging;
using CorePersistence.Responses;
using PasswordManager.Domain.EntityResources;
using PasswordManager.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services.UserNotesServices
{
    public interface IUserNoteService
    {
        Task<CoreResponse<UserNotesEntity>> Add(UserNotes userNote);
        Task<CoreResponse<UserNotesEntity>> Update(UserNotes userNote);
        Task<CoreResponse<UserNotesEntity>> Remove(UserNotes userNote);
        Task<CoreResponse<UserNotesEntity>> Get(Expression<Func<UserNotes, bool>>? predicate);
        Task<CoreResponse<Paginate<UserNotesEntity>>> GetList(int? page, int? size, Expression<Func<UserNotes, bool>>? predicate,
            Func<IQueryable<UserNotes>, IOrderedQueryable<UserNotes>>? orderBy = null);
    }
}
