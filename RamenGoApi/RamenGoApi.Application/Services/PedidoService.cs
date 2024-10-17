using RamenGoApi.Application.Commands;
using RamenGoApi.Application.Interfaces;
using RamenGoApi.Domain.Entities;
using RamenGoApi.Domain.Repositories;

namespace RamenGoApi.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IOrderIdGeneratorExternalService _orderIdGeneratorService;
        private readonly ICaldoRepository _caldoRepository;
        private readonly IProteinaRepository _proteinaRepository;

        public PedidoService(ICaldoRepository caldoRepository, IProteinaRepository proteinaRepository, IOrderIdGeneratorExternalService orderIdGeneratorService) 
        {
            _orderIdGeneratorService = orderIdGeneratorService;
            _caldoRepository = caldoRepository; 
            _proteinaRepository = proteinaRepository;
        }

        public async Task<Pedido> ProcessarPedidoAsync(CriarPedidoCommand command)
        {
            var caldo = GetCaldo(command.CaldoId);
            var proteina = GetProteina(command.ProteinaId);

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