using Application.Interfaces;

namespace Application.Services
{
    public class TestService : ITestService
    {
        // docker pull redis
        // docker run --name my-redis -p 6379:6379 -d redis
    }
}
