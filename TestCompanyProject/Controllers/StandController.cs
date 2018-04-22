using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using TestCompanyProject.Data;
using TestCompanyProject.Models;

namespace TestCompanyProject.Controllers
{
    [Produces("application/json")]
    [Route("api/Stand")]
    public class StandController : Controller
    {
        private Context _db;

        public StandController(Context dbContext)
        {
            try
            {
                _db = dbContext;
                if (!_db.StandInfos.Any())
                {
                    _db.StandInfos.Add(new StandInfo
                    {
                        DateTime = DateTime.Now,
                        Error = String.Empty,
                        Name = "FirstStand",
                        Status = StandStatus.NotReady,
                        Url = "127.0.0.1"
                    });

                    _db.StandInfos.Add(new StandInfo
                    {
                        DateTime = DateTime.Now,
                        Error = String.Empty,
                        Name = "SecondStand",
                        Status = StandStatus.Ready,
                        Url = "127.0.0.2"
                    });

                    _db.SaveChanges();
                }
            }
            catch
            {
                _db = null;
            };
        }

        [HttpPut]
        public IActionResult Put([FromBody]StandInfo standInfo)
        {
            try
            {
                if (standInfo == null)
                {
                    return BadRequest();
                }

                var stand = _db.StandInfos.FirstOrDefault(d => d.Name == standInfo.Name && d.Url == standInfo.Url);

                if (stand == null) return BadRequest();

                stand.DateTime = DateTime.Now;
                stand.Status = standInfo.Status;
                stand.Error = standInfo.Error;

                _db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("register")]
        public IActionResult Register([FromBody]Stand stand)
        {
            try
            {
                if (string.IsNullOrEmpty(stand.Url) || string.IsNullOrEmpty(stand.Name))
                {
                    return BadRequest();
                }

                if (_db.Stands == null || _db.Stands != null &&
                    _db.Stands.Any(d => d.Name == stand.Name && d.Url == stand.Url)) return BadRequest("The stand had already added!");
                _db.Stands.Add(new Stand {Name = stand.Name, Url = stand.Url});

                _db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var list = _db.StandInfos.ToList();
                return new JsonResult(list);
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("{url}")]
        public JsonResult Get(string url)
        {
            try
            {
                var list = _db.StandInfos.Where(d => d.Url == url).ToList();
                return new JsonResult(list);
            }
            catch
            {
                return null;
            }
        }
        [HttpGet("now/{url}")]
        public JsonResult Now(string url)
        {
            try
            {
                var obj = _db.StandInfos.LastOrDefault(d => d.Url == url);
                return new JsonResult(obj);
            }
            catch
            {
                return null;
            }
        }
    }
}