using Microsoft.EntityFrameworkCore;
using RecruitmentSolution.Data;
using RecruitmentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSolution.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> FindAll();
        T FindByCode(string code);
        T Save(T entity);
        T Update(T entity);
        T Delete(string code);
    }
    public class GenericRepository<T> where T: BaseEntity
    {
        public RecruitmentContext Context { get; set; }
        public GenericRepository(RecruitmentContext context)
        {
            this.Context = context;
        }

        public IEnumerable<T> FindAll()
        {
            IQueryable<T> query = this.Context.Set<T>();
            return query.Select(e => e).ToList();
        }

        public T FindByCode(string code)
        {
            var entity = this.Context.Find<T>(code);
            if (entity != null)
            {
                return entity;
            }
            throw new Exception($"Entity with {code} doesn't exist.");
        }

        public T Save(T entity)
        {
            this.Context.Add<T>(entity);
            return entity;
        }

        public T Update(T entity)
        {
            this.Context.Attach<T>(entity);
            this.Context.Entry<T>(entity).State = EntityState.Modified;
            return entity;
        }

        public T Delete(string code)
        {
            var existingEntity = this.FindByCode(code);
            this.Context.Remove<T>(existingEntity);
            return existingEntity;
        }
    }
}
