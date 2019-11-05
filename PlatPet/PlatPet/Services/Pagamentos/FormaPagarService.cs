using PlatPet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.Services.Pagamentos
{
    public class FormaPagarService : IFormaPagarService
    {
        private readonly IRequest _request;
        private const string ApiUrlBase = "http://universesoftware2019.somee.com/api/Pagamentos";

        public FormaPagarService()
        {
            _request = new Request();
        }

        public async Task<FormaPagamento> DeleteFormaPagarAsync(int pagId)
        {
            string urlComplementar = string.Format("/{0}", pagId);
            await _request.DeleteAsync(ApiUrlBase + urlComplementar);
            return new FormaPagamento() { IdPagemento = pagId };
        }

        public async Task<ObservableCollection<FormaPagamento>> GetFormaPagarAsync()
        {
            ObservableCollection<FormaPagamento> pag = await
                _request.GetAsync<ObservableCollection<FormaPagamento>>(ApiUrlBase);

            return pag;
        }

        public async Task<FormaPagamento> PostFormaPagarAsync(FormaPagamento p)
        {
            if (p.IdPagemento == 0)
            {
                return await _request.PostAsync(ApiUrlBase, p);

            }
            else
                return await _request.PutAsync(ApiUrlBase, p);
        }

        public async Task<FormaPagamento> PutFormaPagarAsync(FormaPagamento p)
        {
            string urlComplementar = string.Format("/{0}", p);
            var result = await _request.PutAsync(ApiUrlBase, p);
            return result;
        }
    }
}
