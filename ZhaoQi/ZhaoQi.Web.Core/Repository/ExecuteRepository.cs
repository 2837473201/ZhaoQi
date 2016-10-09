using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ZhaoQi.Web.Core.EFDataAccess;
using ZhaoQi.Web.Core.Models;

namespace ZhaoQi.Web.Core.Repository
{
    public class ExecuteRepository:IRepository<ExecuteModel>
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

        public IQueryable<ExecuteModel> Query
        {
            get
            {
                return _entitiy.ExecuteEntities.AsQueryable();
            }
        }

        public int Add(IEnumerable<ExecuteModel> models, bool isAutoSubmit = true)
        {
            _entitiy.ExecuteEntities.AddRange(models);
            if (isAutoSubmit)
                return SubmitChanges();

            return models.Count();
        }

        public int Delete(IEnumerable<ExecuteModel> models, bool isAutoSubmit = true)
        {
            _entitiy.ExecuteEntities.RemoveRange(
                _entitiy.ExecuteEntities.Where(r => models.Select(m => m.Id).ToArray().Contains(r.Id)).Select(r => r));

            if (isAutoSubmit)
                return SubmitChanges();

            return models.Count();
        }

        public int Modify(IEnumerable<ExecuteModel> models, bool isAutoSubmit = true)
        {
            foreach (var model in models)
            {
                var entityModel =
                    _entitiy.ExecuteEntities.Where(
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
                    entityModel.Flag = model.Flag;
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
