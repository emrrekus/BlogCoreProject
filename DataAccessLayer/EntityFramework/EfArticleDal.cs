﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        private readonly Context _context;
        public EfArticleDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<Article> GetListWithCategory()
        {
            return _context.Articles.Include(x => x.Category).ToList();
        }

        public List<Article> GetListWithCategoryWithoutWriter(int id)
        {
           return _context.Articles.Include(_x => _x.Category).Where(x=>x.WriterId==id).ToList();
        }

        public List<Article> GetListWithoutWriter()
        {
            return _context.Articles.Include(x => x.Writer).ToList();
        }
    }
}
