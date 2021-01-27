using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreCodeCamp.Data;
using System.Linq;
using CoreCodeCamp.Data.Entities;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //automatic model state alidation and binding source parameter interference. Needed for post
    public class ShareStrategyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShareRepository _shareRespository;


        public ShareStrategyController(IShareRepository shareRespository,
            IMapper mapper) //required for dependency injection
        {
            //_repository = respository;
            _shareRespository = shareRespository;
            _mapper = mapper;

        }

        [HttpPut("createShareStrategy/{toUpdate}")]
        public async Task<ActionResult<ShareStrategyModel>>
            CreateShareStrategy(ShareStrategyModel model, bool toUpdate) //parameter is what's returned by the api
        {
            //try
            //{

            //var oldModel = await _shareRespository.GetShareStrategy(model.ShareId);
            

            var fundStrategy = new FundStrategy();
            var shareStrategy = new ShareStrategy();

            if (model.IsFund)
            {
                fundStrategy = _mapper.Map<FundStrategy>(model);
                fundStrategy.FundId = model.ShareId;
            }
            else
            {
                shareStrategy = _mapper.Map<ShareStrategy>(model);
            }

         

                if (toUpdate)
                {
                    if (model.IsFund)
                    {
                        _shareRespository.AddOrUpdate(fundStrategy, true);
                }
                    else
                    {
                        _shareRespository.AddOrUpdate(shareStrategy, true);
                }

                    

                }
                else
                {
                    if (model.IsFund)
                    {
                        _shareRespository.AddOrUpdate(fundStrategy, false);
                    }
                    else
                    {
                        _shareRespository.AddOrUpdate(shareStrategy, false);
                    }
               
                }

                

                if (await _shareRespository.SaveChangesAsync())
                {
                    return Created("", _mapper.Map<ShareStrategyModel>(model));
                }
            

                

                return Ok();
            //}
            //catch (Exception)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            //}

            return BadRequest();
        }

        [HttpGet("{shareId}")]
        public async Task<ActionResult<ShareStrategyModel>>RetrieveShareStrategy(int shareId) //parameter is what's returned by the api
        {
            try
            {
                var result = await _shareRespository.GetShareStrategy(shareId); //cmpany name

                if (result == null ) return NotFound();

                return _mapper.Map<ShareStrategyModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

        }


    }
}
