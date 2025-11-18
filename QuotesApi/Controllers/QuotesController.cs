using Microsoft.AspNetCore.Mvc;
using System;

namespace QuotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly string[] quotes = new[]
        {
            "من جدّ وجد ومن زرع حصد",
            "العلم نور والجهل ظلام",
            "الصبر مفتاح الفرج",
            "من طلب العلا سهر الليالي",
            "القناعة كنز لا يفنى",
            "التجربة خير برهان",
            "لا تؤجل عمل اليوم إلى الغد",
            "الوقت كالسيف إن لم تقطعه قطعك",
            "من حفر حفرة لأخيه وقع فيها",
            "الكلمة الطيبة صدقة",
            "درهم وقاية خير من قنطار علاج",
            "العقل زينة",
            "العين لا تعلو على الحاجب",
            "من لا يشكر الناس لا يشكر الله",
            "أطلب العلم من المهد إلى اللحد",
            "الرفق في كل شيء",
            "اعمل لدنياك كأنك تعيش أبداً واعمل لآخرتك كأنك تموت غداً",
            "خير الأمور أوسطها",
            "من حسن إسلام المرء تركه ما لا يعنيه",
            "الجار قبل الدار"
        };

        [HttpGet]
        public IActionResult GetRandomQuote()
        {
            var random = new Random();
            var quote = quotes[random.Next(quotes.Length)];
            return Ok(new { quote });
        }
    }
}
