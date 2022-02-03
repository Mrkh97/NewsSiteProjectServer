using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NewsSiteServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsItemController : ControllerBase
    {
        private static List<NewsItem> Items = new List<NewsItem>
            {
                new NewsItem { Id=1,Title = "bomb",Text ="booom",ImgSrc="google"},
                new NewsItem { Id=2,Title ="bombom",Text="Boooom",ImgSrc="google"}
            };
        private readonly DataContext dataContext;

        public NewsItemController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<NewsItem>>> Get()
        {
            return Ok(await dataContext.NewsItems.ToListAsync());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<NewsItem>> Get(int Id)
        {
            var news =await dataContext.NewsItems.FindAsync(Id);
            if (news == null) { return BadRequest("news not found"); }
            else { return Ok(news); }
        }
        [HttpPost]
        public async Task<ActionResult<List<NewsItem>>> AddNews(NewsItem news)
        {
            dataContext.NewsItems.Add(news);
            await dataContext.SaveChangesAsync();
            return Ok(await dataContext.NewsItems.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<NewsItem>>> UpdateNews(NewsItem request)
        {
            var dbNews =await dataContext.NewsItems.FindAsync(request.Id);
            if (dbNews == null) { return BadRequest("news not found"); }
            else
            {
                dbNews.Title = request.Title;
                dbNews.Text = request.Text;
                dbNews.ImgSrc = request.ImgSrc;

                await dataContext.SaveChangesAsync();

                return Ok(await dataContext.NewsItems.ToListAsync());
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<NewsItem>>> Delete(int Id)
        {
            var news = await dataContext.NewsItems.FindAsync(Id);
            if (news == null) { return BadRequest("news not found"); }
            else 
            { 
                dataContext.NewsItems.Remove(news); 
                await dataContext.SaveChangesAsync(); 
                return Ok(await dataContext.NewsItems.ToListAsync()); 
            }
        }
    }
}