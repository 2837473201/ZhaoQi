using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ZhaoQi.Web.Core.EFDataAccess;
using ZhaoQi.Web.Core.Models;

namespace ZhaoQi.Web.Core.Repository
{
    public class RealDataRepository:IRepository<RealDataModel>
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

        public IQueryable<RealDataModel> Query
        {
            get
            {
                return _entitiy.RealDataEntities.AsQueryable();
            }
        }

        public int Add(IEnumerable<RealDataModel> models, bool isAutoSubmit = true)
        {
            _entitiy.RealDataEntities.AddRange(models);
            if (isAutoSubmit)
                return SubmitChanges();

            return models.Count();
        }

        public int Delete(IEnumerable<RealDataModel> models, bool isAutoSubmit = true)
        {
            _entitiy.RealDataEntities.RemoveRange(
                _entitiy.RealDataEntities.Where(r => models.Select(m => m.Id).ToArray().Contains(r.Id)).Select(r => r));

            if (isAutoSubmit)
              return  SubmitChanges();

            return models.Count();
        }

        public int Modify(IEnumerable<RealDataModel> models, bool isAutoSubmit = true)
        {
            foreach (var model in models)
            {
                var entityModel =
                    _entitiy.RealDataEntities.Where(
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
