using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VPProject.Data.Repository
{
    //base entity model
    public abstract class BaseEntity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState
        {
            get; set;
        }

        public DateTime? DateCreated { get; set; }
        public bool SoftDelete { get; set; }        
    }

    public enum ObjectState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }
}
