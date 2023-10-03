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
    public class PaymentServices : IPaymentsServices
    {
        //private readonly IPaymentsRepository _paymentsRepository;
        private readonly IRepositoryServices<Payments> _repositoryServices;

        public PaymentServices(IRepositoryServices<Payments> repositoryServices)
        {
            //_paymentsRepository = paymentsRepository;
            _repositoryServices = repositoryServices;

        }

        public Result Pay(PaymentFactory paymentFactory)
        {
            try
            {
                var payment = paymentFactory.Create();
                _repositoryServices.Insert(payment);
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);
            }

            return Result.Succeed("Usuario creado");
        }

        public Result Update(Guid id, PaymentEdited paymentEdited)
        {
            var payment = _repositoryServices.FindById(id);

            if (payment == null)
                return Result.Failed("Este pago no existe");

            try
            {
                payment.Modify(paymentEdited);
                _repositoryServices.Save();
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);

            }

            return Result.Succeed("Pago modificado");
        }

        public Result Delete(Guid id)
        {
            var payment = _repositoryServices.FindById(id);

            if (payment == null)
                return Result.Failed("No existe");

            try
            {
                payment.Delete();
                _repositoryServices.Save();
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);
            }

            return Result.Succeed("Borrado correctamente");
        }

        
    }
}
