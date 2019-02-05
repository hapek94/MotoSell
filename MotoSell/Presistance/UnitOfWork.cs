using MotoSell.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoSell.Presistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MotoSellDbContext context;

        public UnitOfWork(MotoSellDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }

    
}
