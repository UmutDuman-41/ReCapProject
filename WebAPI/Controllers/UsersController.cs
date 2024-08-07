﻿using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{
        //    var result = _userService.GetAll();
        //    if (result.Success)
        //    {
        //        return Ok();
        //    }
        //    return BadRequest();
        //}

        //[HttpGet("getid")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _userService.GetById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        ////[HttpPost("add")]
        ////public IActionResult Insert(User user)
        ////{
        ////    var result = _userService.Add(user);
        ////    if (result.Success)
        ////    {
        ////        return Ok(result);
        ////    }
        ////    return BadRequest(result);
        ////}

        //[HttpPost("Delete")]
        //public IActionResult Delete(User user)
        //{
        //    var result = _userService.Delete(user);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpPost("Update")]
        //public IActionResult Update(User user)
        //{
        //    var result = _userService.Update(user);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

    }
}
