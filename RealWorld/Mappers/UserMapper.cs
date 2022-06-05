using RealWorld.Contract;
using RealWorld.Model;

namespace RealWorld.Mappers;

public static class UserMapper
{
    public static UserResponse ToUserResponse(this User user) =>
        new()
        {
            Id = user.Id,
            FullName = user.FullName
        };
}
