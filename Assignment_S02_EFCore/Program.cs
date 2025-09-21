using Assignment_S02_EFCore.Contexts;
using Assignment_S02_EFCore.Models.ITI;
namespace Assignment_S02_EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ITI_EFCore_DbContext context = new ITI_EFCore_DbContext();
            using Sales_EFCore_DbContext salesContext = new Sales_EFCore_DbContext();
            using Musician_EFCore_DbContext musicianContext = new Musician_EFCore_DbContext();

        }
    }
}
