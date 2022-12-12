using Features.Mouse.Scripts.Infrastructure;

namespace Features.Mouse.Scripts.Domain.Action
{
    public class InteractionService
    {
        private readonly InteractionRepository _repository;

        public InteractionService(InteractionRepository repository)
        {
            _repository = repository;
        }
    }
}