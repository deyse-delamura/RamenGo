using RamenGoApi.Application.DTOs;
using RamenGoApi.Domain.Entities;
using RamenGoApi.Domain.Repositories;
using RamenGoApi.Infrastructure.ExternalServices;

namespace RamenGoApi.Application.Services
{
    public class PedidoService
    {
        private readonly ICaldoRepository _caldoRepository;
        private readonly IProteinaRepository _proteinaRepository;
        private readonly OrderIdGeneratorService _orderIdGeneratorService;

        public PedidoService(ICaldoRepository caldoRepository, IProteinaRepository proteinaRepository, OrderIdGeneratorService orderIdGeneratorService)
        {
            _caldoRepository = caldoRepository;
            _proteinaRepository = proteinaRepository;
            _orderIdGeneratorService = orderIdGeneratorService;
        }

        public async Task<Pedido> ProcessarPedidoAsync(PedidoRequest request)
        {
            var caldo = _caldoRepository.GetAll().FirstOrDefault(c => c.Id == request.CaldoId);
            var proteina = _proteinaRepository.GetAll().FirstOrDefault(p => p.Id == request.ProteinaId);

            if (caldo == null || proteina == null)
            {
                throw new ArgumentException("Invalid caldo or proteina selection.");
            }

            // Gerar o ID do pedido a partir do serviço externo
            var orderId = await _orderIdGeneratorService.GenerateOrderIdAsync();

            return Pedido(caldo, proteina, orderId);
        }
    }
}