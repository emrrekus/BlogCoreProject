using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.ViewComponents.Comment
{
	public class CommentListByBlog : ViewComponent
	{
		private readonly ICommentService commentService;

		public CommentListByBlog(ICommentService commentService)
		{
			this.commentService = commentService;
		}

		public IViewComponentResult Invoke(int id)
		{
			var values = commentService.TGetListbyFilter(id);
			return View(values);
		}
	}
}
