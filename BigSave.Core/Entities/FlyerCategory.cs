using System.Collections.Generic;
using BigSave.Core.Entities.Base;

namespace BigSave.Core.Entities
{
    public class FlyerCategory : BaseEntity
    {
        public FlyerCategory()
        {
            Flyers = new List<Flyer>();
        }
        public string Name { get; set; }
        public List<Flyer> Flyers { get; set; }
    }
}