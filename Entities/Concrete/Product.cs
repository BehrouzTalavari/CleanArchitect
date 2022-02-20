using Core.Entities;

namespace Entities.Concrete
{
    public class Product: IEntity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short UnitId { get; set; }

    }
}
