using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Data.Entities;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //automatic model state alidation and binding source parameter interference. Needed for post
    public class CompetitorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShareRepository _shareRespository;

        public CompetitorController(IShareRepository shareRespository,
            IMapper mapper) //required for dependency injection
        {
            //_repository = respository;
            _shareRespository = shareRespository;
            _mapper = mapper;
        }

        [HttpPost("createCompetitor")]
        public async Task<ActionResult<CompetitorModel>>
            CreateCompetitor(CompetitorModel competitor) //use share profile to get 
        {
            var result = _mapper.Map<Competitor>(competitor);


            _shareRespository.Add(result);

              if (await _shareRespository.SaveChangesAsync())
                 {
                    return Created("", _mapper.Map<CompetitorModel>(result));
                }

                return Ok();
            //}
            //catch (Exception)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            //}

            return BadRequest();


        }


        [HttpGet("getCompetitors/{shareId}")] //extends API URL to Share/{shareId}, curly brackets seek a parameter value 
        public async Task<ActionResult<ShareModel[]>> GetCompetitorsShareInfo(int shareId) //share Id equal to the attribute parameter as names match?
        {
            //try
            //{
            var results = await _shareRespository.GetCompetitors(shareId); //cmpany name

            if (!results.Any()) return NotFound();

            var shareResults = new List<Share>();

            foreach (var competitor in results)
            {
                shareResults.AddRange(await _shareRespository.GetShareCompetitorsInfo(competitor.CompetitorId));
            }



            return _mapper.Map<ShareModel[]>(shareResults);
            //}
            //catch (Exception)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            //}
        }

    }
}
