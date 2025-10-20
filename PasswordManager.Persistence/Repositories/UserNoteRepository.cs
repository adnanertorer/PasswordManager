using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Abstracts.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Persistence.Repositories;

public class UserNoteRepository(PasswordManagerDbContext dbContex) : IUserNoteRepository
{
    public async Task<UserNote> Add(UserNote userNote, CancellationToken cancellationToken)
    {
        await dbContex.UserNotes.AddAsync(userNote, cancellationToken);
        return userNote;
    }

    public async Task<UserNote?> GetById(Guid id, bool withAsNoTracking, CancellationToken cancellationToken)
    {
        var query = dbContex.UserNotes
            .AsQueryable();

        if (withAsNoTracking)
            query = query.AsNoTracking();

        return await dbContex.UserNotes.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<UserNote>> GetList(Guid userId, string? search, bool withAsNoTracking, CancellationToken cancellationToken)
    {
        var query = dbContex.UserNotes
           .AsQueryable();

        if (withAsNoTracking)
            query = query.AsNoTracking();

        query = query.Where(i => i.UserId == userId);

        if(!string.IsNullOrEmpty(search))
            query = query.Where(i => i.NoteText.Contains(search) || i.NoteTitle.Contains(search));

        return await query.OrderByDescending(i => i.CreatedDate).ToListAsync(cancellationToken);
    }

    public void Update(UserNote userNote)
    {
        dbContex.UserNotes.Update(userNote);
    }
}
