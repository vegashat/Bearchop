using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

<<<<<<< HEAD
namespace Bearchop.NCAAF.jqGrid
=======
namespace Bearchop.Areas.NCAAF.Web.jqGrid
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
{
	public static class PagingLinqExtensions
	{
		#region IQueryable<T> extensions

		public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize)
		{
			return new PagedList<T>(source, pageIndex, pageSize);
		}

		public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize, int totalCount)
		{
			return new PagedList<T>(source, pageIndex, pageSize, totalCount);
		}

		#endregion

		#region IEnumerable<T> extensions

		public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
		{
			return new PagedList<T>(source, pageIndex, pageSize);
		}

		public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
		{
			return new PagedList<T>(source, pageIndex, pageSize, totalCount);
		}

		#endregion
	}
}