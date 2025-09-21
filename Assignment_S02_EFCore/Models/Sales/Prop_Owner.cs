using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_S02_EFCore.Models.Sales
{
    [PrimaryKey(nameof(OwnId),nameof(PropId))]
    internal class Prop_Owner
    {
        [ForeignKey(nameof(Owner))]
        public int OwnId { get; set; }
        [ForeignKey(nameof(Property))]
        public int PropId { get; set; }
        public decimal percent { get; set; }

        public Owner Owner { get; set; } = null!;
        public Property Property { get; set; } = null!;
    }
}
