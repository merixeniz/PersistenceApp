using Application.Interfaces;
using Application.Interfaces.DataAccess;
using Entities;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task TestMethod()
        {
            var vdRepo = _unitOfWork.Repository<VirtualDevice>();
            var boardRepo = _unitOfWork.CustomRepository<IBoardsRepository>();

            return Task.CompletedTask;
        }
    }
}
