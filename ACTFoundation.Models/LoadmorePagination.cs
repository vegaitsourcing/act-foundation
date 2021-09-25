using System;
using System.Collections.Generic;
using System.Linq;

namespace ACTFoundation.Core.Models
{
	public class LoadmorePagination<TViewModel>
	{
		public LoadmorePagination(Guid parentId, int page, int itemsPerPage, IEnumerable<TViewModel> items)
		{
			if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
			if (itemsPerPage <= 0) throw new ArgumentOutOfRangeException(nameof(itemsPerPage));

			ParentId = parentId;
			Page = page;
			TotalResults = items.Count();
			TotalPages = (int)Math.Ceiling((double)TotalResults / itemsPerPage);
			ItemsPerPage = itemsPerPage;
			Items = items
				.Skip((page - 1) * itemsPerPage)
				.Take(itemsPerPage)
				.ToList();
		}

		public Guid ParentId { get; }
		public int Page { get; }
		public int TotalPages { get; }
		public int ItemsPerPage { get; }
		public long TotalResults { get; }
		public IReadOnlyList<TViewModel> Items { get; }

		public bool HasMore()
		{
			return Page < TotalPages;
		}
	}
}