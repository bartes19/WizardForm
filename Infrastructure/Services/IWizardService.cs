using Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IWizardService
    {
        Task<MessageDto> GetAsync(int id);
        IEnumerable<MessageDto> GetAllAsync();
        int Add(MessageDto messageDto);
    }
}