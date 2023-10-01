using AutoMapper;
using CorePersistence.Paging;
using CorePersistence.Responses;
using CorePersistence.Tools;
using PasswordManager.Domain.EntityResources;
using PasswordManager.Domain.Repositories.UserAccountsRespositories;
using PasswordManager.Models;
using PasswordManager.Tools;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services.UserAccountServices
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _repository;
        
        public UserAccountService(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<CoreResponse<UserAccountEntity>> Add(UserAccounts userAccount)
        {
            try
            {
                string enPasss = string.Empty;
                var encrypted = EncryptionHelper.EncryptStringToBytes(Encoding.UTF8.GetBytes(userAccount.Password), Consts.SecurityKey,
                    Consts.Salt, Consts.IV);
                userAccount.Password = Convert.ToBase64String(encrypted);

                var result = Mapper.Map<UserAccountEntity>(await _repository.AddAsync(userAccount));
                return new CoreResponse<UserAccountEntity>(result, Messages.Successfull);
            }
            catch (Exception e)
            {
                return new CoreResponse<UserAccountEntity>(Messages.ErrorMessage + $":{e.Message}");
            }
        }

        public async Task<CoreResponse<UserAccountEntity>> Get(Expression<Func<UserAccounts, bool>> predicate)
        {
            try
            {
                var result = Mapper.Map<UserAccountEntity>(await _repository.GetAsync(predicate));
                byte[] cipher = Convert.FromBase64String(result.Password);
                var decrypted = EncryptionHelper.Decrypt(cipher, Consts.SecurityKey, Consts.Salt, Consts.IV);
                result.Password = Encoding.UTF8.GetString(decrypted);
                return new CoreResponse<UserAccountEntity>(result, Messages.Successfull);
            }
            catch (Exception e)
            {
                return new CoreResponse<UserAccountEntity>(Messages.ErrorMessage + $":{e.Message}");
            }
        }

        public async Task<CoreResponse<Paginate<UserAccountEntity>>> GetList(int? page, int? size, Expression<Func<UserAccounts, bool>> predicate, Func<IQueryable<UserAccounts>, IOrderedQueryable<UserAccounts>> orderBy = null)
        {
            try
            {
                
                var result = Mapper.Map<Paginate<UserAccountEntity>>(await _repository.GetListAsync(predicate, orderBy: orderBy, index: page, size: size));
                foreach (var item in result.Items)
                {
                    byte[] cipher = Convert.FromBase64String(item.Password);
                    var decrypted = EncryptionHelper.Decrypt(cipher, Consts.SecurityKey, Consts.Salt, Consts.IV);
                    item.Password = Encoding.UTF8.GetString(decrypted);
                }
                return new CoreResponse<Paginate<UserAccountEntity>>(result, Messages.Successfull);
            }
            catch (Exception e)
            {
                return new CoreResponse<Paginate<UserAccountEntity>>(Messages.ErrorMessage + $":{e.Message}");
            }
        }

        public async Task<CoreResponse<UserAccountEntity>> Remove(UserAccounts userAccount)
        {
            try
            {
                var model = await _repository.GetAsync(i => i.Id == userAccount.Id);
                var result = Mapper.Map<UserAccountEntity>(await _repository.DeleteAsync(model));
                return new CoreResponse<UserAccountEntity>(result, Messages.Successfull);
            }
            catch (Exception e)
            {
                return new CoreResponse<UserAccountEntity>(Messages.ErrorMessage + $":{e.Message}");
            }
        }

        public async Task<CoreResponse<UserAccountEntity>> Update(UserAccounts userAccount)
        {
            try
            {
                var model = await _repository.GetAsync(i => i.Id == userAccount.Id);
                var encrypted = EncryptionHelper.EncryptStringToBytes(Encoding.UTF8.GetBytes(userAccount.Password), Consts.SecurityKey,
                   Consts.Salt, Consts.IV);
                userAccount.Password = Convert.ToBase64String(encrypted);

                model.Password = Convert.ToBase64String(encrypted);
                model.AccountTitle = userAccount.AccountTitle;
                model.AccountUrl = userAccount.AccountUrl;
                model.CategoryId = userAccount.CategoryId;
                model.Username = userAccount.Username;
                var result = Mapper.Map<UserAccountEntity>(await _repository.UpdateAsync(model));
                return new CoreResponse<UserAccountEntity>(result, Messages.Successfull);
            }
            catch (Exception e)
            {
                return new CoreResponse<UserAccountEntity>(Messages.ErrorMessage + $":{e.Message}");
            }
        }
    }
}