using Egyptian_association_of_cieliac_patients_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Egyptian_association_of_cieliac_patients_api.Repositories
{
    public class MainRepository<T> : ICRUDRepo<T> where T : class
    {
        public MainRepository(EgyptianAssociationOfCieliacPatientsContext context)
        {
            this.context = context;
        }

        protected EgyptianAssociationOfCieliacPatientsContext context;

		

		public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }
		public T FindById(int id,params string[] agers)
		{
			IQueryable<T> query = context.Set<T>();

			if (agers.Length > 0)
			{
				foreach (var ager in agers)
				{
					query = query.Include(ager);
				}
			}

			// Get the primary key property name
			var primaryKeyProperty = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();

			if (primaryKeyProperty == null)
			{
				throw new InvalidOperationException($"Entity type '{typeof(T).Name}' does not have a primary key property.");
			}

			string primaryKeyPropertyName = primaryKeyProperty.Name;

			// Use EF.Property to access the primary key property dynamically
			return query.FirstOrDefault(entity => EF.Property<int>(entity, primaryKeyPropertyName) == id);
		}

		public T SelectOne(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return await query.ToListAsync();
        }

        //=========================================================================//

        public void AddOne(T myItem)
        {
            context.Set<T>().Add(myItem);
            context.SaveChanges();
        }

        public void UpdateOne(T myItem)
        {
            context.Set<T>().Update(myItem);
            context.SaveChanges();
        }

        public void DeleteOne(T myItem)
        {
            context.Set<T>().Remove(myItem);
            context.SaveChanges();
        }

        public void AddList(IEnumerable<T> myList)
        {
            context.Set<T>().AddRange(myList);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> myList)
        {
            context.Set<T>().UpdateRange(myList);
            context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> myList)
        {
            context.Set<T>().RemoveRange(myList);
            context.SaveChanges();
        }

        
    }
}