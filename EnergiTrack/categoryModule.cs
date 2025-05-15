using System;
using System.Collections.Generic;
using System.Linq;

namespace LabReservationSystem.Domain
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

namespace LabReservationSystem.Services
{
	public interface ICrudService<T>
	{
		void Add(T item);
		void Edit(int id, T item);
		void Delete(int id);
		List<T> GetAll();
		T GetById(int id);
	}

	public class CrudService<T> : ICrudService<T> where T : class
	{
		private readonly List<T> _items;
		private int _nextId;

		public CrudService()
		{
			_items = new List<T>();
			_nextId = 1;
		}

		public void Add(T item)
		{
			var prop = item.GetType().GetProperty("Id");
			if (prop != null)
			{
				prop.SetValue(item, _nextId);
				_nextId++;
			}
			_items.Add(item);
		}

		public void Edit(int id, T item)
		{
			var existingItem = GetById(id);
			if (existingItem != null)
			{
				var index = _items.IndexOf(existingItem);
				_items[index] = item;
			}
		}

		public void Delete(int id)
		{
			var item = GetById(id);
			if (item != null)
			{
				_items.Remove(item);
			}
		}

		public List<T> GetAll()
		{
			return _items;
		}

		public T GetById(int id)
		{
			return _items.FirstOrDefault(item => (int)item.GetType().GetProperty("Id")?.GetValue(item) == id);
		}
	}
}
