using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using test_previsul.Domain.Bases;
using test_previsul.Domain.Entities;

namespace test_previsul.Infra.Data.Repositories
{
    public class CustomerRepository : RepositoryBaseEF<Customer>
    {
        public async Task<int> Save(Customer model)
        {
            var objDb = ctx.Customers
                .Where(x => x.Id == model.Id)
                .Include(x => x.Addresses)
                .FirstOrDefault();

            ctx.Entry(objDb).CurrentValues.SetValues(model);

            objDb.Addresses.Clear();
            objDb.Addresses = model.Addresses;

            ctx.Entry(objDb).State = EntityState.Modified;
            return await ctx.SaveChangesAsync();
        }
    }
}
