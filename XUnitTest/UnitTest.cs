using System;
using Microsoft.AspNetCore.Mvc;
using TestCompanyProject.Controllers;
using TestCompanyProject.Data;
using TestCompanyProject.Models;
using Xunit;

namespace XUnitTest
{
    public class UnitTest
    {
        private readonly StandController _standController;

        public UnitTest(Context context)
        {
            _standController = new StandController(context);
        }
        
        public void TestPut(StandInfo standInfo)
        {
            var result = _standController.Put(standInfo);
            Assert.IsType<OkResult>(result);
        }
        
        public void TestRegister(Stand stand)
        {
            var result = _standController.Register(stand);
            Assert.IsType<OkResult>(result);
        }

        public void TestGet()
        {
            var result = _standController.Get();
            Assert.Null(result);
        }

        public void TestGet(string url)
        {
            var result = _standController.Get(url);
            Assert.Null(result);
        }

        public void TestNow(string url)
        {
            var result = _standController.Now(url);
            Assert.Null(result);
        }
    }
}
