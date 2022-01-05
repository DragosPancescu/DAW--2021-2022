using DAW_Project.Data;
using DAW_Project.Models.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Repositories.GenericRepository
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DawProjectContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(DawProjectContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
