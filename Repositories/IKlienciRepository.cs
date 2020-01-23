using KinoDotNetCore.ViewModels;
using System;

namespace KinoDotNetCore.Repositories
{
    interface IKlienciRepository
    {
        bool CheckIfLoginDetailsCorrect(LoginDetails customerLoginDetails);
        int GetCustomerIdBasedOnLogin(String login);
    }
}
