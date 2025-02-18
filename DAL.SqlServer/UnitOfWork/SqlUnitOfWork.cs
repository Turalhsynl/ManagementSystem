using DAL.SqlServer.Context;
using DAL.SqlServer.Infastructure;
using Repository.Common;
using Repository.Repositories;

namespace DAL.SqlServer.UnitOfWork;

public class SqlUnitOfWork(string connectionString, AppDbContext context) : IUnitOfWork
{
    private readonly string _connectionString = connectionString;
    private readonly AppDbContext _context = context;

    public SqlCategoryRepository _categoryRepository;
    public SqlUserRepository _userRepository;

    public ICategoryRepository CategoryRepository => _categoryRepository ?? new SqlCategoryRepository(_connectionString, _context);
    public IUserRepository UserRepository => _userRepository ?? new SqlUserRepository(_context);
}
