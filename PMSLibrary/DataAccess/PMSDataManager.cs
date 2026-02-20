using Microsoft.EntityFrameworkCore;
using PMSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSLibrary.DataAccess
{
    public class PMSDataManager
    {
        private readonly PMSContext _context;

        public PMSDataManager()
        {
            _context = new PMSContext();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<SalesTransaction>> GetTransactionsByEmployeeIdAsync(string employeeId)
        {
            return await _context.SalesTransactions
                .Include(st => st.Product)
                .Where(st => st.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task AddTransactionAsync(SalesTransaction transaction)
        {
            _context.SalesTransactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
