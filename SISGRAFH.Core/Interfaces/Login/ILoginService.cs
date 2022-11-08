using SISGRAFH.Core.DTOs.Login;
using SISGRAFH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Interfaces.Login
{
    public interface ILoginService
    {
        Task<AuthUserToken> GetAuthorization(AuthUserInfo authInfo);
    }
}