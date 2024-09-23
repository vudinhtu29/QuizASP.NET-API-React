using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAppBE.Models;
using System.Reflection.Metadata.Ecma335;

namespace QuizAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuizDbContext context;
        public QuestionController(QuizDbContext context)
        {
            this.context = context;
        }
        //GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestion()
        {
            var random5Qns = await (context.Questions.Select(x => new
            {
                QnId = x.QnId,
                QnInWords = x.QnInWords,
                ImageName = x.ImageName,
                Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
            }
                )
                .OrderBy(y => Guid.NewGuid())
                .Take(5)).ToListAsync();

            return Ok(random5Qns);
        }


        [HttpPost]
        [Route("GetAnswers")]
        public async Task<ActionResult<Question>> RetrieveAnswers(int[] qnIds)
        {
            var answers = await (context.Questions
                 .Where(x => qnIds.Contains(x.QnId))
                 .Select(y => new
                 {
                     QnId = y.QnId,
                     QnInWords = y.QnInWords,
                     ImageName = y.ImageName,
                     Options = new string[] { y.Option1, y.Option2, y.Option3, y.Option4 },
                     Answer = y.Answer
                 })).ToListAsync();
            return Ok(answers);

        }

    }

    

}
