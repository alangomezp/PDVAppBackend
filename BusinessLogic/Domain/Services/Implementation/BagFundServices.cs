using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Domain.Core;
using BusinessLogic.Domain.Services.Definition;
using BusinessLogic.Persistence.Repository.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Services.Implementation
{
    public class BagFundServices : IBagFundServices
    {
        private readonly IPaymentsServices _paymentsServices;
        private readonly IRepositoryServices<BagFund> _repositoryServices;
        private readonly IBagFundRepository _bagFundRepository;
        private readonly IFundAccountsRepository _fundAccountsRepository;

        public BagFundServices(IPaymentsServices paymentsServices, IRepositoryServices<BagFund> repositoryServices, IBagFundRepository bagFundRepository, IFundAccountsRepository fundAccountsRepository)
        {
            _paymentsServices = paymentsServices;
            _repositoryServices = repositoryServices;
            _bagFundRepository = bagFundRepository;
            _fundAccountsRepository = fundAccountsRepository;
        }

        public Result Register(BagFundFactory bagFundFactory)
        {
            try
            {
                var bagFund = bagFundFactory.Create();
                _repositoryServices.Insert(bagFund);

                var paymentByHours = BagFundHoursToPayment(bagFund.Hours, bagFund.StudentId);
                _paymentsServices.Pay(paymentByHours);
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);
            }

            return Result.Succeed("Registro de horas creado");
        }

        public Result Update(Guid id, BagFundEdited bagFundEdited)
        {
            var bagFund = _repositoryServices.FindById(id);

            if (bagFund == null)
                return Result.Failed("Este registro no existe");

            try
            {
                bagFund.Modify(bagFundEdited);
                _repositoryServices.Save();
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);

            }

            return Result.Succeed("Registro de horas modificado");
        }

        public Result Delete(Guid id)
        {
            var bagFund = _repositoryServices.FindById(id);

            if (bagFund == null)
                return Result.Failed("Registro no existe");

            try
            {
                bagFund.Delete();
                _repositoryServices.Save();
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);
            }

            return Result.Succeed("Borrado correctamente");
        }

        public PaymentFactory BagFundHoursToPayment(int hoursQty, Guid studentId)
        {
            decimal hoursValue = _bagFundRepository.GetHoursValue();
            var fundAccount = _fundAccountsRepository.FindByDescription("Bolsa");
            decimal amount = hoursValue * hoursQty;

            return new PaymentFactory(studentId, fundAccount.Id, amount, "Sistema");
        }
        
    }
}
