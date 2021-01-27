using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Data.Entities;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //automatic model state alidation and binding source parameter interference. Needed for post
    public class FundController : ControllerBase
    {
        //serialization should be done away from the controller
      
        //private readonly IShareRepository _shareRespository;
        private readonly IMapper _mapper;
        private readonly IShareRepository _shareRespository;
        private readonly IFundRepository _fundRespository;

        public FundController( IShareRepository shareRespository,IFundRepository fundRepository, IMapper mapper) //required for dependency injection
        {
            //_repository = respository;
            _shareRespository = shareRespository;
            _mapper = mapper;
            _fundRespository = fundRepository;


        }

        [HttpPost("createFund")]
        public async Task<ActionResult<FundModel>>
            CreateFund(FundModel model) //parameter is what's returned by the api
        {


            var fund = _mapper.Map<Fund>(model);

           
            _fundRespository.Add(fund);

            if (await _fundRespository.SaveChangesAsync())
            {
                return Created("", _mapper.Map<FundModel>(model));
            }

            return BadRequest();

        }

        [HttpGet("getFunds")] //extends API URL to Share/{shareId}, curly brackets seek a parameter value 
        public async Task<ActionResult<FundModel[]>> GetFunds() //share Id equal to the attribute parameter as names match?
        {
            try
            {
                var results = await _fundRespository.GetAllFunds(); //cmpany name

            if (!results.Any()) return NotFound();

            return _mapper.Map<FundModel[]>(results);
        }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
    }
}
         
        [HttpPut("createFundStrategy/{toUpdate}")]
        public async Task<ActionResult<ShareStrategyModel>>
            CreateFundStrategy(ShareStrategyModel model, bool toUpdate) //parameter is what's returned by the api
        {
            try
            {
                var result = _mapper.Map<ShareStrategy>(model);


            if (toUpdate)
            {
                _fundRespository.AddOrUpdateFundStrategy(result, true);
            }
            else
            {
                _fundRespository.AddOrUpdateFundStrategy(result, false);
            }

            if (await _fundRespository.SaveChangesAsync())
            {
                return Created("", _mapper.Map<ShareStrategyModel>(model));
            }

            return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

            return BadRequest();
        }


        [HttpGet("{fundId}")]
        public async Task<ActionResult<ShareStrategy>> RetrieveFundStrategy(int fundId) //parameter is what's returned by the api
        {
            try
            {
                var result = await _fundRespository.GetFundStrategy(fundId); //cmpany name

                if (result == null) return NotFound();

                return _mapper.Map<ShareStrategy>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

        }

    }
}
