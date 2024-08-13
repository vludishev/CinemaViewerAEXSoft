using CV.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.App.Services
{
    public interface INewsService
    {
        
    }

    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext _dbContext;

        public NewsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
