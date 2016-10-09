using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZhaoQi.Web.Core.Models;
using ZhaoQi.Web.Core.Repository;

namespace ZhaoQi.Web.Core.Business
{
    public class BllHisData
    {
        public BllHisData()
        {
        }

        public BllHisData(IRepository<HisDataModel> entities)
        {
            _entities = entities;
        }



        private IRepository<HisDataModel> _entities = new HisDataRepository();

        public IRepository<HisDataModel> Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }


        public List<HisDataModel> Query(Hashtable filters)
        {
            if (filters == null || filters.Count == 0)
            {
                return Entities.Query.ToList();
            }

            var modelType = typeof (HisDataModel);
            var queryResult = Entities.Query;
            foreach (DictionaryEntry de in filters)
            {
                if (modelType.GetProperty(de.Key.ToString()) == null)
                {
                    continue;
                }
                var columnName = modelType.GetProperty(de.Key.ToString()).Name;
                switch (columnName)
                {
                    case "Id":
                    {
                        queryResult = Entities.Query.Where(
                            e => e.Id == Convert.ToInt32(de.Value));
                    }
                        break;
                    case "Tag":
                    {
                        queryResult = Entities.Query.Where(
                            e => e.Tag.Equals(de.Value.ToString(), StringComparison.CurrentCultureIgnoreCase));
                    }
                        break;
                    case "ProjectId":
                    {
                        queryResult = Entities.Query.Where(
                            e => e.ProjectId.Equals(de.Value.ToString(), StringComparison.CurrentCultureIgnoreCase));
                    }
                        break;
                    case "TagUint":
                    {
                        queryResult = Entities.Query.Where(
                            e => e.TagUint.Equals(de.Value.ToString(), StringComparison.CurrentCultureIgnoreCase));
                    }
                        break;
                    default:
                        continue;
                }
            }

            return queryResult.ToList();
        }



    }
}
