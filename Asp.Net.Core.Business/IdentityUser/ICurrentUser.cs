using System;

namespace Asp.Net.Core.IdentityUser
{
    public interface ICurrentUser
    {
        Guid UserId { get; }
    }
}
