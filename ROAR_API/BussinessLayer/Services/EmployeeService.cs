using BussinessLayer.Services.Contracts;
using DataLayer.Context;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private RoarContext _context;

        public EmployeeService(RoarContext context)
        {
            _context = context;
        }


        public async Task<bool> Create(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Update(Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Employees.Where(x=> x.IsDeleted!= true).SingleOrDefaultAsync(x=> x.Id.Equals(id));
            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.Entry(entity).State = EntityState.Modified;
             return   await _context.SaveChangesAsync() > 0 ? true : false;
            }
            return false;
        }

        public async Task<Employee> GetById(Guid id) => await _context.Employees
            .Where(x => x.IsDeleted != true)
            .SingleOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<IEnumerable<Employee>> GetAllEntities(int page, int quantityPerPage)=>
             await _context.Employees
                .Where(x=> x.IsDeleted != true)
                .OrderBy(x => x.CreationDate)
                .Skip((page - 1) * quantityPerPage)
                .Take(quantityPerPage)
                .ToListAsync();
        
    }
}
