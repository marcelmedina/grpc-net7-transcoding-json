using Grpc.Core;
using GrpcNet7JSONTranscoding.Protos;

namespace GrpcNet7JSONTranscoding.Services
{
    public class UserService : Protos.UserService.UserServiceBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<UserResponse> GetUserDetails(UserRequest request, ServerCallContext context)
        {
            var userResponse = new UserResponse
            {
                UserId = 1,
                FirstName = "Bill",
                LastName = "Lumbergh",
                Address = new Address()
                {
                    Number = "1A",
                    StreetName = "Initech Street",
                    Suburb = "Initech Suburb",
                    City = "Austin, Texas",
                    Country = "USA"
                }
            };

            return Task.FromResult(userResponse);
        }
    }
}
