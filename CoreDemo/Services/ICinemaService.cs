using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.models;

namespace CoreDemo.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetllAllAsync();

        Task<Cinema> GetByIdAsync(int id);

        Task<Sales> GetSalesAsync();

        Task AddAsync(Cinema model);
    }
}
