using NewsPortal.DataAccess.Entities;
using NewsPortal.DataAccess.Models;
using NewsPortal.Models.VM.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Abstract
{
    public interface INewsService
    {
        /// <summary>
        ///  Get all news
        /// </summary>
        /// <returns></returns>
        GetManyResult<NewsInfoVM> GetNewsList();

        /// <summary>
        ///  Get news by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetOneResult<NewsInfoVM> GetNews(int id);

        /// <summary>
        ///  Create news 
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        GetOneResult<NewsInfoVM> CreateNews(NewsEditVM news);

        /// <summary>
        ///  Update news 
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        GetOneResult<NewsInfoVM> UpdateNews(NewsEditVM news);

        /// <summary>
        ///  Delete news by id from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteNews(int id);
    }
}
