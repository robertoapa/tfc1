using tfc1.ViewModels;

namespace tfc1.Models.Interfaces
{
    public interface ILoginService
    {
        Task<List<UsuariosVm>> GetUsuarios();
    }
}
