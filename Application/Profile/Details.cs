using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Profile
{
    public class Details
    {
        public class Query : IRequest<Profile>
        {
            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Query, Profile>
        {
            private readonly IProfileReader _profileReader;
            public Handler(IProfileReader profileReader)
            {
                this._profileReader = profileReader;
            }

            public async Task<Profile> Handle(Query request, CancellationToken cancellationToken)
            {
                // handler logic goes here
                return await _profileReader.ReadProfile(request.Username);
            }
        }
    }
}