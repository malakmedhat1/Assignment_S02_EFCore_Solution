using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_S02_EFCore.Models.Hospital
{
    [PrimaryKey(nameof(Brand), nameof(DrugCode))]
    internal class DrugBrand
    {
        
        public string? Brand { get; set; }
        [ForeignKey(nameof(Drugs))]
        public string DrugCode { get; set; }
       public Drugs Drugs { get; set; }= null!;
    }
}
