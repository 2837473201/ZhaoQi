using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZhaoQi.Web.Core.Business;
using ZhaoQi.Web.Core.Models;
using ZhaoQi.Web.Core.Repository.Fakes;

namespace ZhaoQi.Web.Core.UnitTest
{
    [TestClass]
    public class BllHisDataTest
    {


        [TestMethod]
        public void GetHisDataTest()
        {
            var rep = new StubIRepository<HisDataModel>();
            rep.QueryGet = () =>
            {
                var simData = new List<HisDataModel>();
                for (var i = 0; i < 10; i++)
                {
                    simData.Add(new HisDataModel
                    {
                        Id = i,
                        ProjectId = "ProjectId" + i,
                        Tag = "Tag" + i,
                        TagDesc = "TagDesc" + i,
                        TagUint = "TagUint" + i,
                        TagValue = "TagValue" + i,
                        UpdateTime = string.Empty,
                    });
                }
                return simData.AsQueryable();
            };


            var bll = new BllHisData(rep);
            var queryResult = bll.Query(null);
            Assert.AreEqual(10, queryResult.Count);
        }


        [TestMethod]
        public void GetHisDataTestWithFilter()
        {
            var rep = new StubIRepository<HisDataModel>();
            rep.QueryGet = () =>
            {
                var simData = new List<HisDataModel>();
                for (var i = 0; i < 10; i++)
                {
                    simData.Add(new HisDataModel
                    {
                        Id =  i,
                        ProjectId = "ProjectId" + i,
                        Tag = "Tag" + i,
                        TagDesc = "TagDesc" + i,
                        TagUint = "TagUint" + i,
                        TagValue = "TagValue" + i,
                        UpdateTime = string.Empty,
                    });
                }
                return simData.AsQueryable();
            };


            var bll = new BllHisData(rep);
            var queryResult = bll.Query(new Hashtable
            {
                {"Id","Id0"}
            });
            Assert.AreEqual(1, queryResult.Count);

        }

    }
}
