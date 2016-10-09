using System.Collections.Generic;
using System.Linq;
using ZhaoQi.Web.Core.Models;
using ZhaoQi.Web.Core.Repository;

namespace ZhaoQi.Web.Core.Business
{
    public class BllExecute
    {

        public BllExecute()
        {
        }

        public BllExecute(IRepository<ExecuteModel> entities)
        {
            _entities = entities;
        }



        private IRepository<ExecuteModel> _entities = new ExecuteRepository();

        public IRepository<ExecuteModel> Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }


        public int Excute(IEnumerable<ExecuteModel> models)
        {
            var existedIdList = _entities.Query.Select(e => e.Id).ToArray();
            var updateList = new List<ExecuteModel>();
            var insertList = new List<ExecuteModel>();
            foreach (var model in models)
            {
                if (existedIdList.Contains(model.Id))
                {
                    updateList.Add(model);
                }
                else
                {
                    insertList.Add(model);
                }
            }

            if (updateList.Any())
            {
                _entities.Modify(updateList);
            }

            if (insertList.Any())
            {
                _entities.Add(insertList);
            }

            if (updateList.Any() || insertList.Any())
            {
                return _entities.SubmitChanges();
            }
            return 0;
        }



    }
}
