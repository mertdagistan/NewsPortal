using NewsPortal.Business.Abstract;
using NewsPortal.DataAccess.Abstract;
using NewsPortal.DataAccess.Entities;
using NewsPortal.DataAccess.Enum;
using NewsPortal.DataAccess.Models;
using NewsPortal.Models.VM.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Concrete
{
    public class NewsManager : INewsService
    {
        private INewsDataAccess _newsDataAccess;

        public NewsManager(INewsDataAccess newsDataAccess)
        {
            _newsDataAccess = newsDataAccess;
        }

        public GetOneResult<NewsInfoVM> CreateNews(NewsEditVM news)
        {
            var newsEntity = new News
            {
                Title = news.Title,
                Content = news.Content,
                AuthorID = news.AuthorID,
                Description = news.Description,
                Image = news.Image,
                PublishAt = news.PublishAt
            };

            var result = _newsDataAccess.InsertOne(newsEntity);
            if (result.Success)
            {
                return new GetOneResult<NewsInfoVM>
                {
                    Success = true,
                    Message = "News created successfully",
                    Entity = new NewsInfoVM
                    {
                        ID=newsEntity.ID,
                        Title = news.Title,
                        Content = news.Content,
                        Author = "",
                        Description = news.Description,
                        Image = news.Image,
                        PublishAt = DateTime.Now
                    }
                };
            }
            else
            {
                return new GetOneResult<NewsInfoVM>
                {
                    Success = false,
                    Message = "News creation failed",
                    Entity = null
                };
            }
        }

        public bool DeleteNews(int id) => _newsDataAccess.DeleteById(id);

        /// <summary>
        /// Get news by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GetOneResult<NewsInfoVM> GetNews(int id)
        {
            var result = new GetOneResult<NewsInfoVM>();

            try
            {
                // Get news from db by id
                var news = _newsDataAccess.GetById(id);

                // If news is not found
                if (news == null)
                {
                    result.Message = "News not found";
                    result.Success = false;
                    return result;
                }

                // If news is found
                result.Entity = new NewsInfoVM
                {
                    ID = news.Entity.ID,
                    Author=news.Entity.Users.FullName,
                    Content=news.Entity.Content,
                    Description = news.Entity.Description,
                    Image = news.Entity.Image,
                    PublishAt = news.Entity.PublishAt,
                    Title = news.Entity.Title
                };
            }
            // If something went wrong
            catch (Exception ex)
            {
                result.Entity = null;
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Get all newss
        /// </summary>
        /// <returns></returns>
        public GetManyResult<NewsInfoVM> GetNewsList()
        {
            var result = new GetManyResult<NewsInfoVM>();

            try
            {
                // Get news list from db
                var newss = _newsDataAccess.GetAll();

                // If news list is not found
                if (newss == null)
                {
                    result.Message = "News list not found";
                    result.Success = false;
                    return result;
                }

                // If news list is found
                result.Result = newss.Result.Select(x => new NewsInfoVM
                {
                    ID = x.ID,
                    Author = x.Users.FullName,
                    Content = x.Content,
                    Description = x.Description,
                    Image = x.Image,
                    PublishAt = x.PublishAt,
                    Title = x.Title
                });

            }
            // If something went wrong
            catch (Exception ex)
            {
                result.Result = null;
                result.Success = false;
            }

            return result;
        }

        public GetOneResult<NewsInfoVM> UpdateNews(NewsEditVM news)
        {
            var newsEntity = new News
            {
                ID = news.ID,
                AuthorID = news.AuthorID,
                Content = news.Content,
                Description = news.Description,
                Image = news.Image,
                PublishAt = news.PublishAt,
                Title = news.Title,
            };

            var result = _newsDataAccess.UpdateOne(newsEntity);
            if (result.Success)
            {
                return new GetOneResult<NewsInfoVM>
                {
                    Success = true,
                    Message = "News created successfully",
                    Entity = new NewsInfoVM
                    {
                        ID = newsEntity.ID,
                        Author ="",
                        Content = newsEntity.Content,
                        Description = newsEntity.Description,
                        Image = newsEntity.Image,
                        PublishAt = newsEntity.PublishAt,
                        Title = newsEntity.Title
                    }
                };
            }
            else
            {
                return new GetOneResult<NewsInfoVM>
                {
                    Success = false,
                    Message = "News update failed",
                    Entity = null
                };
            }
        }
    }
}
