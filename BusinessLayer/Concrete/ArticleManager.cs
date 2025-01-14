﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

		public List<Article> GetArticleListByWriter(int id)
		{
			return _articleDal.GetbyFilter(x=> x.WriterId == id);
		}

		public List<Article> GetBlogListWithCategory()
        {
            return _articleDal.GetListWithCategory();
        }

        public List<Article> GetBlogListWithWriter()
        {
            return _articleDal.GetListWithoutWriter();
        }

        public List<Article> GetListWithCategoryWithoutWriter(int id)
        {
            return _articleDal.GetListWithCategoryWithoutWriter(id);
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetList();
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public List<Article> TGetListbyFilter(int id)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Article entity)
        {
            _articleDal.Insert(entity);
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }  
        
    }
}
