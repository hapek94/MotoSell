using System.Threading.Tasks;

namespace MotoSell.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

    }
}