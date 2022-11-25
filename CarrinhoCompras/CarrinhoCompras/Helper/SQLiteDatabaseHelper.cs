using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarrinhoCompras.Model;
using SQLite;

namespace CarrinhoCompras.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public SQLiteDatabaseHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _connection.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET descricao=?, quantidade=?, preco=? WHERE id=?";

            return _connection.QueryAsync<Produto>(sql, p.descricao, p.quantidade, p.preco, p.id);


        }

        public Task<List<Produto>> GetAll() //Listagem
        {
            return _connection.Table<Produto>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _connection.Table<Produto>().DeleteAsync(i => i.id == id); 
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";
            return _connection.QueryAsync<Produto>(sql);
        }
    }
}
