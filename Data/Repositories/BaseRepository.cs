
using Estoque_App.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Estoque_App.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DataContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, int pageNumber = 1,
    int pageSize = 10, params Expression<Func<TEntity, object>>[]? includes)
        {
            var query = _dbSet.AsNoTracking()
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(PropertyPath(include));
                }
            }

            var result = expression == null
                ? await query.ToListAsync()
                : await query.Where(expression).ToListAsync();

            return result;
        }

        public static string PropertyPath<TSource, TProperty>(Expression<Func<TSource, TProperty>> expression)
        {
            return GetMemberName(expression.Body);
        }

        private static string GetMemberName(Expression expression)
        {
            return expression switch
            {
                MemberExpression memberExpression => memberExpression.Member.Name,
                UnaryExpression unaryExpression => GetMemberName(unaryExpression.Operand),
                MethodCallExpression methodCallExpression => ExtractSelectMemberPath(methodCallExpression),
                _ => throw new ArgumentException("A expressão não é um acesso a membro válido", nameof(expression)),
            };
        }

        public static string ExtractSelectMemberPath(MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression.Method.Name == "Select" && methodCallExpression.Arguments.Count == 2)
            {
                var lambdaExpression = ExtractLambdaExpression(methodCallExpression.Arguments[1]);
                if (lambdaExpression != null)
                {
                    var selectPart = GetMemberName(lambdaExpression.Body);
                    var pathBeforeSelect = GetMemberName(methodCallExpression.Arguments[0]);

                    //includes de tabelas meios
                    return $"{pathBeforeSelect}.{selectPart}";
                }
            }

            return GetMemberName(methodCallExpression.Arguments[0]);
        }

        private static LambdaExpression? ExtractLambdaExpression(Expression expression)
        {
            if (expression is LambdaExpression lambdaExpression)
            {
                return lambdaExpression;
            }

            if (expression is UnaryExpression unaryExpression && unaryExpression.Operand is LambdaExpression innerLambdaExpression)
            {
                return innerLambdaExpression;
            }

            return null;

        }

        public Task<TEntity?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
           _db?.Update(entity);
           _db?.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _db?.Dispose();
        }

    }
}
