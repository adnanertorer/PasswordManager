using AutoMapper;
using CorePersistence.Paging;
using CorePersistence.Responses;
using CorePersistence.Tools;
using PasswordManager.Domain.EntityResources;
using PasswordManager.Domain.Repositories.UserNotesRepositories;
using PasswordManager.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services.UserNotesServices
{
    public class UserNoteService : IUserNoteService
    {
        private readonly IUserNoteRepository _repository;

        public UserNoteService(IUserNoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CoreResponse<UserNotesEntity>> Add(UserNotes userNote)
        {
            try
            {
                var result = Mapper.Map<UserNotesEntity>(await _repository.AddAsync(userNote));
                return new CoreResponse<UserNotesEntity>(result, Messages.Successfull);
            }
            catch (Exception e)
            {
                return new CoreResponse<UserNotesEntity>(Messages.ErrorMessage + $":{e.Message}");
            }
        }

        public async Task<CoreResponse<UserNotesEntity>> Get(Expression<Func<UserNotes, bool>> predicate)
        {
            try
            {
                var result = Mapper.Map<UserNotesEntity>(await _repository.GetAsync(predicate));
                return new CoreResponse<UserNotesEntity>(result, Messages.Successfull);
            }
            catch (Exception e)
            {
                return new CoreResponse<UserNotesEntity>(Messages.ErrorMessage + $":{e.Message}");
            }
        }

        public async Task<CoreResponse<Paginate<UserNotesEntity>>> GetList(int? page, int? size, Expression<Func<UserNotes, bool>> predicate, Func<IQueryable<UserNotes>, IOrderedQueryable<UserNotes>> orderBy = null)
        {
            try
            {
                var result = Mapper.Map<Paginate<UserNotesEntity>>(await _repository.GetListAsync(predicate, orderBy: orderBy, index: page, size: size));
                return new CoreResponse<Paginate<UserNotesEntity>>(result, Messages.Successfull);
            }
            catch (Exception e)
            {
                return new CoreResponse<Paginate<UserNotesEntity>>(Messages.ErrorMessage + $":{e.Message}");
            }
        }

        public async Task<CoreResponse<UserNotesEntity>> Remove(UserNotes userNote)
        {
            try
            {
                var model = await _repository.GetAsync(i => i.Id == userNote.Id);
                var result = Mapper.Map<UserNotesEntity>(await _repository.DeleteAsync(model));
                return new CoreResponse<UserNotesEntity>(result, Messages.Successfull);
            }
            catch (Exception e)
            {
                return new CoreResponse<UserNotesEntity>(Messages.ErrorMessage + $":{e.Message}");
            }
        }

        public async Task<CoreResponse<UserNotesEntity>> Update(UserNotes userNote)
        {
            try
            {
                var model = await _repository.GetAsync(i => i.Id == userNote.Id);
                model.NoteTitle = userNote.NoteTitle;
                model.NoteText = userNote.NoteText;
                var result = Mapper.Map<UserNotesEntity>(await _repository.UpdateAsync(model));
                return new CoreResponse<UserNotesEntity>(result, Messages.Successfull);
            }
            catch (Exception e)
            {
                return new CoreResponse<UserNotesEntity>(Messages.ErrorMessage + $":{e.Message}");
            }
        }
    }
}