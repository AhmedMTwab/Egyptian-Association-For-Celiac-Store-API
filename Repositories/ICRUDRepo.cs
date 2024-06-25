using System.Collections.Generic;
using System.Linq.Expressions;

namespace Egyptian_association_of_cieliac_patients_api.Repositories
{
    public interface ICRUDRepo<T> where T : class
    {
            T FindById(int id);
            T FindById(int id, params string[] agers);

			T SelectOne(Expression<Func<T, bool>> match);

            IEnumerable<T> FindAll();

            IEnumerable<T> FindAll(params string[] agers);

            Task<T> FindByIdAsync(int id);

            Task<IEnumerable<T>> FindAllAsync();

            Task<IEnumerable<T>> FindAllAsync(params string[] agers);

            void AddOne(T myItem);

            void UpdateOne(T myItem);

            void DeleteOne(T myItem);

            void AddList(IEnumerable<T> myList);

            void UpdateList(IEnumerable<T> myList);

            void DeleteList(IEnumerable<T> myList);
        }
    }
