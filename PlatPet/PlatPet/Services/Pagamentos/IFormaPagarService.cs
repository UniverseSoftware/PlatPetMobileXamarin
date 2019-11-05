using PlatPet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.Services.Pagamentos
{
    public interface IFormaPagarService
    {
        Task<ObservableCollection<FormaPagamento>> GetFormaPagarAsync();

        Task<FormaPagamento> PostFormaPagarAsync(FormaPagamento p);

        Task<FormaPagamento> PutFormaPagarAsync(FormaPagamento p);
        Task<FormaPagamento> DeleteFormaPagarAsync(int petId);
    }
}
