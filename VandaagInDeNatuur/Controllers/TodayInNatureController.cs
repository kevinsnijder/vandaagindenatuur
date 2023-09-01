using Microsoft.AspNetCore.Mvc;

namespace VandaagInDeNatuur.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class TodayInNatureController : ControllerBase
   {
      private readonly ILogger<TodayInNatureController> _logger;

      public TodayInNatureController(ILogger<TodayInNatureController> logger)
      {
         _logger = logger;
      }

      [HttpGet(Name = "Get")]
      public NatureMessage Get(int? day, int? month)
      {
         if (day == null)
            day = DateTime.Today.Day;

         if (month == null)
            month = DateTime.Today.Month;

         var message = NatureHashTable.messages.FirstOrDefault(msg => msg.date == ((day < 10 ? "0" : "") + day + "/" + (month < 10 ? "0" : "") + month));

         return message;
      }
   }
}