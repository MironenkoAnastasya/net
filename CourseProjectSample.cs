using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Services
{
   
    public class ProjectManagementService<T> where T : class
    {
        private readonly List<T> _items = new List<T>();

 
        public Task<bool> AddItemAsync(T item)
        {
            if (item == null) return Task.FromResult(false);
            
            _items.Add(item);
            return Task.FromResult(true);
        }

     
        public Task<IEnumerable<T>> GetAllItemsAsync()
        {
            return Task.FromResult<IEnumerable<T>>(_items);
        }

        public Task<T> FindItemAsync(Func<T, bool> predicate)
        {
            var item = _items.FirstOrDefault(predicate);
            return Task.FromResult(item);
        }
    }
}