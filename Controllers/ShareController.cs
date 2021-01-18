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
    public class ShareController : ControllerBase
    {
        //serialization should be done away from the controller
      
        //private readonly IShareRepository _shareRespository;
        private readonly IMapper _mapper;
        private readonly IShareRepository _shareRespository;

        
        public ShareController( IShareRepository shareRespository, IMapper mapper) //required for dependency injection
        {
            //_repository = respository;
            _shareRespository = shareRespository;
            _mapper = mapper;
         
        }

        [HttpPost("createShareStrategy")]
        public async Task<ActionResult<ShareStrategyModel>> CreateShare(ShareStrategyModel model) //parameter is what's returned by the api
        {
            //try
            //{

            var result = _mapper.Map<ShareStrategy>(model);


            _shareRespository.Add(result);

                if (await _shareRespository.SaveChangesAsync())
                 {
                    return Created("", _mapper.Map<ShareStrategyModel>(model));
                }

                return Ok();
            //}
            //catch (Exception)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            //}

            return BadRequest();
        }



        //        [HttpGet]
        //        public async Task<ActionResult<ShareModel[]>> Get()
        //        {
        //            try
        //            {
        //                var results = await _repository.GetAllCampsAsync();
        //                //these results need  to be of type Share

        //                return _mapper.Map<ShareModel[]>(results); //this code assumes that if the return type is of '
        //                //'ShareModel[]' then all is copaescent
        //            }
        //            catch (Exception)
        //            {
        //                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
        //            }

        //        }
        //        [HttpGet("{shareId}")] //extends API URL to Share/{shareId}, curly brackets seek a parameter value 
        //        public async Task<ActionResult<ShareModel>> GetShare(int shareId) //share Id equal to the attribute parameter as names match?
        //        {
        //            try
        //            {
        //                var result = await _repository.GetCampAsync(shareId.ToString()); //this would obvs be 

        //                if (result == null)
        //                    return NotFound();

        //                return _mapper.Map<ShareModel>(result);
        //            }
        //            catch (Exception)
        //            {
        //                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
        //            }
        //        }

        [HttpGet("getShares")] //extends API URL to Share/{shareId}, curly brackets seek a parameter value 
        public async Task<ActionResult<ShareModel[]>> GetShares() //share Id equal to the attribute parameter as names match?
        {
            //try
            //{
                var results = await _shareRespository.GetAllUserShares(DateTime.Now); //cmpany name

                 if (!results.Any()) return NotFound();

                return _mapper.Map<ShareModel[]>(results);
            //}
            //catch (Exception)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            //}
        }

        [HttpPut("createCompany/{toUpdate}")]
        public async Task<ActionResult<CompanyModel>>
            CreateCompany(CompanyModel model, bool toUpdate) //parameter is what's returned by the api
        {
            //try
            //{
            var result = _mapper.Map<Company>(model);


            if (toUpdate)
            {
                _shareRespository.AddOrUpdate(result, true);
            }
            else
            {
                _shareRespository.AddOrUpdate(result, false);
            }

        if (await _shareRespository.SaveChangesAsync())
            {
                return Created("", _mapper.Map<CompanyModel>(model));
            }

            return Ok();
            //}
            //catch (Exception)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            //}

            return BadRequest();
        }

     

        [HttpPost("createShare")]
        public async Task<ActionResult<ShareModel>> CreateShare(ShareModel model) //parameter is what's returned by the api
        {
            //try
            //{
         
                model.ShareEntryDate = DateTime.Now.ToShortTimeString();


                var result = _mapper.Map<Share>(model);


                _shareRespository.Add(result);

                if (await _shareRespository.SaveChangesAsync())
                {
                    return Created("", _mapper.Map<ShareModel>(model));
                }

                return Ok();
            //}
            //catch (Exception)
            //{
            //    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            //}

            return BadRequest();
        }


    }
}
