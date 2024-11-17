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

		public IViewComponentResult Invoke()
		{
			var values = commentService.TGetListbyFilter(31);
			return View(values);
		}
	}
}
