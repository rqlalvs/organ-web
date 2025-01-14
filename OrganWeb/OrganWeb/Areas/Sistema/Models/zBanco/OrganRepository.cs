﻿using OrganWeb.Areas.Sistema.Models;
using PagedList;
using PagedList.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OrganWeb.Areas.Sistema.Models.zBanco
{
    public class OrganRepository<T> : IDisposable where T : class
    {
        protected OrganContext _context;
        protected DbSet<T> DbSet { get; set; }

        public OrganRepository()
        {
            _context = new OrganContext();
            DbSet = _context.Set<T>();
        }

        public OrganRepository(OrganContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            if (_context.Entry(DbSet.Find(id)).State == EntityState.Detached)
            {
                DbSet.Attach(DbSet.Find(id));
            }
            DbSet.Remove(DbSet.Find(id));
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetByID(int? id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
            catch (Exception e)
            {

            }
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}