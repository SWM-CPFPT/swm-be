﻿
using be.Services.ModService;
using Microsoft.AspNetCore.Mvc;
using be.DTOs;
using be.Services.UserService;
using be.Models;
using be.Helper;
using Microsoft.AspNetCore.Authorization;

namespace be.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IModService _modService;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly Defines _Defines;

        public AccountController(IConfiguration configuration, IModService modService, IUserService userService)
        {
            _modService = modService;
            _configuration = configuration;
            _userService = userService;
            _Defines = new Defines();
        }

        #region - Manage Mod

        [HttpGet("getAllMod")]
        public async Task<ActionResult> GetAllMod()
        {
            try
            { 
                var data = await _modService.GetAllMod();
                return Ok(data);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getModDetail")]
        public async Task<ActionResult> GetModById(int accountId)
        {
            try
            {
                var result = _modService.GetModById(accountId);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("addMod")]
        public async Task<ActionResult> AddMod([FromBody]AccountDTO addAccount)
        {
            try
            {
                var account = new Account();
                account.Email = addAccount.Email;
                account.Status = _Defines.ACTIVE_STRING;
                account.Gender = addAccount.Gender;
                account.FullName = addAccount.FullName;
                account.BirthDay = addAccount.BirthDay;
                account.Phone = addAccount.Phone;
                account.CreateDate = DateTime.Now;
                account.RoleId = 3;
                var result = _modService.AddMod(account);
                return Ok(result);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPost("changeStatus")]
        public async Task<ActionResult> ChangeStatus(int accountId, string status)
        {
            try
            {
                var result = _modService.ChangeStatus(accountId, status);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("updateMod")]
        public async Task<ActionResult> UpdateMod(int accountId, Account account)
        {
            try
            {
                if (accountId != account.AccountId)
                {
                    return BadRequest();
                }
                var result = _modService.UpdateMod(account);
                return Ok(result);
            } catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("getAllEmail")]
        public async Task<ActionResult> GetAllEmail()
        {
            try
            {
                var data = _modService.GetAllEmail();
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region - Manage User

        [HttpGet("getAllAccountUser")]
        public async Task<ActionResult> GetAllAccountUser()
        {
            try
            {
                var result = _userService.GetAllAccountUser();
                return Ok(result);
            }
            catch { return BadRequest(); }
        }

        [HttpPost("UpdateAccountUser")]
        public async Task<ActionResult> UpdateAccountUser(AccountDTO user)
        {
            try
            {
                var result = _userService.UpdateAccountUser(user);
                return Ok(result);
            }
            catch
            {
                return BadRequest();    
            }
        }

        #endregion
    }
}
