namespace Vineyard.Activity.Work.Application
{
    public class WorkCreator : IWorkCreator
    {
        public WorkCreator()
        {
            
        }
        
        public void WorkCreate(string id, string name, string creatorId)
        {
            Domain.Work.Create(id, name, creatorId);
        }
    }
}