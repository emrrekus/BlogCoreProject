using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        List<Article> GetBlogListWithCategory();
        List<Article> GetBlogListWithWriter();
        List <Article> GetArticleListByWriter(int id);

        List <Article> GetListWithCategoryWithoutWriter(int id);

    }
}
