using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.ViewComponents
{
	public class CommentList: ViewComponent
	{
		private readonly ICommentService _commentService;

		public CommentList(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public IViewComponentResult Invoke()
		{

			var values = _commentService.TGetById(1);
			return View(values);
		}

	}
}
