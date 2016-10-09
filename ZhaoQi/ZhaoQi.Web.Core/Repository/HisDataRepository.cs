using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ZhaoQi.Web.Core.EFDataAccess;
using ZhaoQi.Web.Core.Models;

namespace ZhaoQi.Web.Core.Repository
{
    public class HisDataRepository:IRepository<HisDataModel>
    {
        private ZhaoQiEntities _entitiy = new ZhaoQiEntities();
        public DbContext Entity
        {
            get
            {
                return _entitiy;
            }
            set
            {
                _entitiy = value as ZhaoQiEntities;
            }
        }

        public IQueryable<HisDataModel> Query
        {
            get
            {
                return _entitiy.HisDataEntities.AsQueryable();
            }
        }

        public int Add(IEnumerable<HisDataModel> models, bool isAutoSubmit = true)
        {
            _entitiy.HisDataEntities.AddRange(models);
            if (isAutoSubmit)
                return SubmitChanges();

            return models.Count();
        }

        public int Delete(IEnumerable<HisDataModel> models, bool isAutoSubmit = true)
        {
            _entitiy.HisDataEntities.RemoveRange(
                _entitiy.HisDataEntities.Where(r => models.Select(m => m.Id).ToArray().Contains(r.Id)).Select(r => r));

            if (isAutoSubmit)
                return SubmitChanges();

            return models.Count();
        }

        public int Modify(IEnumerable<HisDataModel> models, bool isAutoSubmit = true)
        {
            foreach (var model in models)
            {
                var entityModel =
                    _entitiy.HisDataEntities.Where(
                        r => r.Id==model.Id)
                        .Select(r => r)
                        .FirstOrDefault();

                if (entityModel != null)
                {
                    entityModel.ProjectId = model.ProjectId;
                    entityModel.Tag = model.Tag;
                    entityModel.TagDesc = model.TagDesc;
                    entityModel.TagUint = model.TagUint;
                    entityModel.TagValue = model.TagValue;
                    entityModel.UpdateTime = string.IsNullOrEmpty(model.UpdateTime)
                        ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        : model.UpdateTime;
                }
            }

            if (isAutoSubmit)
                return SubmitChanges();

            return models.Count();
        }

        public int SubmitChanges()
        {
            return _entitiy.SaveChanges();
        }
    }
}
