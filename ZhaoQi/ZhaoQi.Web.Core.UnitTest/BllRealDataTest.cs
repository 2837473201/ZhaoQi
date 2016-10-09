using System;
using System.Collections;
using System.Data.Entity;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.QualityTools.Testing.Fakes.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZhaoQi.Web.Core.Business;
using ZhaoQi.Web.Core.Models;
using ZhaoQi.Web.Core.Repository;
using ZhaoQi.Web.Core.Repository.Fakes;

namespace ZhaoQi.Web.Core.UnitTest
{
    /// <summary>
    /// BllRealDataTest 的摘要说明
    /// </summary>
    [TestClass]
    public class BllRealDataTest
    {
        public BllRealDataTest()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion



        [TestMethod]
        public void GetRealDataTest()
        {
            var rep = new StubIRepository<RealDataModel>();
            rep.QueryGet = () =>
            {
                var simData = new List<RealDataModel>();
                for (var i = 0; i < 10; i++)
                {
                    simData.Add(new RealDataModel
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


            var bll = new BllRealData();
            var queryResult = bll.Query(null);
            Assert.AreEqual(10, queryResult.Count);
        }


        [TestMethod]
        public void GetRealDataTestWithFilter()
        {
            var rep = new StubIRepository<RealDataModel>();
            rep.QueryGet = () =>
            {
                var simData = new List<RealDataModel>();
                for (var i = 0; i < 10; i++)
                {
                    simData.Add(new RealDataModel
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


            var bll = new BllRealData(rep);
            var queryResult = bll.Query(new Hashtable
            {
                {"Id","Id0"}
            });
            Assert.AreEqual(1, queryResult.Count);
            
        }




    }
}
