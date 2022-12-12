using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain.Action
{
    public class GetRaycastAgent : IGetRaycastAgent
    {
        private readonly MouseRayService _service;

        public GetRaycastAgent(MouseRayService service)
        {
            _service = service;
        }
        
        public IAgentView Execute()
        {
            return _service.GetRaycastAgent();
        }
    }
}