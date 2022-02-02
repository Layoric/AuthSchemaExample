using ServiceStack;
using authschema.ServiceModel;
using ServiceStack.Auth;

namespace authschema.ServiceInterface;

[Authenticate]
public class MyServices : Service
{
    public object Any(Hello request)
    {
        var authRepo = TryResolve<IAuthRepository>();
        var user = authRepo.GetUserAuthByUserName("admin@email.com");
        
        return new HelloResponse { Result = $"Hello, {user.DisplayName}!" };
    }
}