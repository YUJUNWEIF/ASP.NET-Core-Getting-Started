using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.models;

namespace CoreDemo.Services
{
    public class CinemaMemoryService : ICinemaService
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();

        public CinemaMemoryService()
        {
            _cinemas.Add(new Cinema
            {
                Id = 1,
                Name = "一号电影院",
                Location = "一号大道",
                Capacity = 379
            });
            _cinemas.Add(new Cinema
            {
                Id = 2,
                Name = "二号电影院",
                Location = "二号大道",
                Capacity = 996
            });
        }

        public Task<IEnumerable<Cinema>> GetllAllAsync()
        {
            return Task.Run((() => _cinemas.AsEnumerable()));
        }

        public Task<Cinema> GetByIdAsync(int id)
        {
            return Task.Run((() => _cinemas.FirstOrDefault((t => t.Id == id))));
        }

        public Task<Sales> GetSalesAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Cinema model)
        {
            var maxId = _cinemas.Max(x => x.Id);
            model.Id = maxId + 1;
            _cinemas.Add(model);

            return Task.CompletedTask;
        }
    }
}
