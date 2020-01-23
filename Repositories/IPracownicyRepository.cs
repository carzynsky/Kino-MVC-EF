using KinoDotNetCore.ViewModels;

namespace KinoDotNetCore.Repositories
{
    interface IPracownicyRepository
    {
        bool CheckIfLoginDetailsCorrect(LoginDetails employeeLoginDetails);
        bool CheckIfAdmin(LoginDetails employeeLoginDetails);
    }
}
