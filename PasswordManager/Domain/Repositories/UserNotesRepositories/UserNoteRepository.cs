using CorePersistence.Repository;
using PasswordManager.Models;

namespace PasswordManager.Domain.Repositories.UserNotesRepositories
{
    public class UserNoteRepository : Repository<UserNotes, Entities>, IUserNoteRepository
    {
        public UserNoteRepository(Entities context) : base(context)
        {
        }
    }
}