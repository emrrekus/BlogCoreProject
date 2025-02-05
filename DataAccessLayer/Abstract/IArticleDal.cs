﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {

        List<Article> GetListWithCategory();
        List<Article> GetListWithoutWriter();

        List<Article> GetListWithCategoryWithoutWriter(int id);
    }
}
