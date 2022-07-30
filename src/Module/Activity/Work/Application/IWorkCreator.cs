using System.Threading.Tasks;

namespace Vineyard.Activity.Work.Application
{
    public interface IWorkCreator
    {
        void WorkCreate(string id, string name, string creatorId);
    }
}