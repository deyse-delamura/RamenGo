using RamenGoApi.Application.DTOs;
using RamenGoApi.Domain.Entities;
using RamenGoApi.Domain.Repositories;
using RamenGoApi.Infrastructure.ExternalServices;

namespace RamenGoApi.Application.Services
{
    public class PedidoService
    {
        private readonly OrderIdGeneratorService _orderIdGeneratorService;
        private readonly ICaldoRepository _caldoRepository;
        private readonly IProteinaRepository _proteinaRepository;

        public PedidoService(ICaldoRepository caldoRepository, IProteinaRepository proteinaRepository, OrderIdGeneratorService orderIdGeneratorService) 
        {
            _orderIdGeneratorService = orderIdGeneratorService;
            _caldoRepository = caldoRepository; 
            _proteinaRepository = proteinaRepository;
        }

        public async Task<Pedido> ProcessarPedidoAsync(PedidoRequest request)
        {
            var caldo = GetCaldo(request.CaldoId);
            var proteina = GetProteina(request.ProteinaId);

            var orderId = await _orderIdGeneratorService.GenerateOrderIdAsync();

            return new Pedido(caldo, proteina, orderId);
        }

        private Caldo GetCaldo(string caldoId)
        { 
            return _caldoRepository.GetById(caldoId)
                ?? throw new KeyNotFoundException($"Caldo com ID {caldoId} não encontrado.");
        }

        private Proteina GetProteina(string proteinaId)
        {
            return _proteinaRepository.GetById(proteinaId) 
                ?? throw new KeyNotFoundException($"Proteína com ID {proteinaId} não encontrado.");
        }   
    }
}