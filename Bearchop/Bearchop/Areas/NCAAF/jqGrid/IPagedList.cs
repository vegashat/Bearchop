using System.Collections.Generic;

<<<<<<< HEAD
namespace Bearchop.NCAAF.jqGrid
=======
namespace Bearchop.Areas.NCAAF.Web.jqGrid
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
{
	public interface IPagedList<T> : IList<T>
	{
		int PageCount { get; }
		int TotalItemCount { get; }
		int PageIndex { get; }
		int PageNumber { get; }
		int PageSize { get; }
		bool HasPreviousPage { get; }
		bool HasNextPage { get; }
		bool IsFirstPage { get; }
		bool IsLastPage { get; }
	}
}