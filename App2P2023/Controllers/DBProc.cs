using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App2P2023.Models;
using System.Threading.Tasks;

namespace App2P2023.Controllers
{
    public class DBProc
    {
        readonly SQLiteAsyncConnection _connection;
        public DBProc() { }
        public DBProc(string dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            /* Crear todos mis objetos de base de datos : tablas */
            _connection.CreateTableAsync<Empleados>().Wait();
        }

        /* Crear el CRUD de BD */

        // Create
        public Task<int> AddEmple(Empleados empleados)
        {
            if (empleados.Id == 0)
            {
                return _connection.InsertAsync(empleados);
            }
            else
            {
                return _connection.UpdateAsync(empleados);
            }
        }

        // Read
        public Task<List<Empleados>> GetAll()
        {
            return _connection.Table<Empleados>().ToListAsync();
        }

        public Task<Empleados> GetById(int id)
        {
            return _connection.Table<Empleados>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        // Delete 
        public Task<int> DeleteEmple(Empleados empleados)
        {
            return _connection.DeleteAsync(empleados);
        }

    }
}
