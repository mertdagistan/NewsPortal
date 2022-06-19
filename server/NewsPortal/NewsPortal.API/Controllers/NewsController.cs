using Microsoft.AspNetCore.Mvc;
using NewsPortal.Business.Abstract;
using NewsPortal.Models.VM.News;

namespace NewsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _service;

        public NewsController(INewsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all news
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetNewsList();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        /// <summary>
        /// Get news by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetNews(id);
            return Ok(result);
        }

        /// <summary>
        /// Create news
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(NewsEditVM news)
        {
            var result = _service.CreateNews(news);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        /// <summary>
        /// Update news
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(NewsEditVM news)
        {
            var result = _service.UpdateNews(news);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        /// <summary>
        /// Delete news
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.DeleteNews(id);
            if (result)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
