using BusinessLayer.Abstract;
using EntityLayer.Concrete;
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
        [HttpPost]
        public JsonResult PartialAddComment(Comment comment)
        {
            try
            {
                comment.CreateDate = DateTime.Now;
                comment.Status = true;
                comment.ArticleId = 31;

                _commentService.TInsert(comment);

                return Json(new { success = true, message = "Yorum başarıyla eklendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Yorum eklenirken bir hata oluştu: " + ex.Message });
            }
        }


        public PartialViewResult CommentListByBlog(int id)
        {
            var values = _commentService.TGetListbyFilter(id);

            return PartialView(values);
        }
    }
}
