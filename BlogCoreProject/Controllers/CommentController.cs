using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public IActionResult Index()
		{

			return View(_commentService.TGetAll());
		}

		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}

		public PartialViewResult CommentListByBlog(int id)
		{
			var values = _commentService.TGetListbyFilter(id);
			
			return PartialView(values);
		}
	}
}
