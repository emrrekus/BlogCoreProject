using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreProject.ViewComponents.Blog
{
	public class WriterOtherArticle : ViewComponent
	{
		private readonly IArticleService _articleService;

		public WriterOtherArticle(IArticleService articleService)
		{
			_articleService = articleService;
		}

		public IViewComponentResult Invoke(int id)
		{
			var values = _articleService.GetArticleListByWriter(id).OrderByDescending(x=>x.CreateDate).Take(3).ToList();
			return View(values);

		}
	}
}
