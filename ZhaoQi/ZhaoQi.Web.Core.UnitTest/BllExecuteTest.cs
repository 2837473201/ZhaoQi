using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZhaoQi.Web.Core.Business;
using ZhaoQi.Web.Core.Models;
using ZhaoQi.Web.Core.Repository.Fakes;

namespace ZhaoQi.Web.Core.UnitTest
{
    [TestClass]
    public class BllExecuteTest
    {
        [TestMethod]
        public void ExecuteCommandTest()
        {
             
            //var rep = new StubIRepository<ExecuteModel>();
            //rep.QueryGet = () =>
            //{
            //    var simData = new List<HisDataModel>();
            //    for (var i = 0; i < 10; i++)
            //    {
            //        simData.Add(new HisDataModel
            //        {
            //            Id = "Id" + i,
            //            ProjectId = "ProjectId" + i,
            //            Tag = "Tag" + i,
            //            TagDesc = "TagDesc" + i,
            //            TagUint = "TagUint" + i,
            //            TagValue = "TagValue" + i,
            //            UpdateTime = string.Empty,
            //        });
            //    }
            //    return simData.AsQueryable();
            //};


            //var bll = new BllExecute(rep);
            //var queryResult = bll.Excute(null);
            //Assert.AreEqual(10, queryResult.Count);




        }
    }
}
