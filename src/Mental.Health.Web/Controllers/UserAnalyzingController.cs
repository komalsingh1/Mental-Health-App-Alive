using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mental.Health.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mental.Health.Web.Controllers
{
    [Route("api/Analyze")]
    [ApiController]
    public class UserAnalyzingController : ControllerBase
    {
        private readonly IUserAnalyzingService _userAnalyzingService;
        public UserAnalyzingController(IUserAnalyzingService userAnalyzingService)
        {
            _userAnalyzingService = userAnalyzingService;
        }
        [HttpGet("question")]
        public async Task<ActionResult> GetQuestion([FromBody] Service.Analyzer.QuestionRequest request)
        {
            var result = await _userAnalyzingService.GetQuestion(request);
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }
        [HttpPost("answer")]
        public async Task<ActionResult> SaveAnswer([FromBody] Service.Analyzer.AnswerRequest request)
        {
            var result = await _userAnalyzingService.SaveAnswer(request);
            return result == null ? (ActionResult)BadRequest() : Ok(result);
        }
    }
}