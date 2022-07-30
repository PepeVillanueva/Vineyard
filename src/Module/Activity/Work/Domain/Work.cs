using System;

namespace Vineyard.Activity.Work.Domain
{
    public sealed class Work
    {
        private string Id { get;}
        private string Name { get;}
        private string CreatorId { get; }

        private Work(string id, string name, string creatorId)
        {
            this.Id = id;
            this.Name = name;
            this.CreatorId = creatorId;
        }

        public static Work Create(string id, string name, string creatorId)
        {
            return new Work(id, name, creatorId);
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            var item = obj as Work;
            if (item == null) return false;

            return Id.Equals(item.Id) && Name.Equals(item.Name) && CreatorId.Equals(item.CreatorId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, CreatorId);
        }
    }
}
