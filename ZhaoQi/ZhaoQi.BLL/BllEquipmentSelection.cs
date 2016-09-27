using System.Collections.Generic;
using System.Linq;
using System.Data;
using ZhaoQi.Model;
using ZhaoQi.DAL;

namespace ZhaoQi.BLL
{
    public class BllEquipmentSelection
    {
        protected DalEquipment DalEquipment = new DalEquipment();
        protected DalLogin DalLogin = new DalLogin();

        public IEnumerable<EquipmentModel> GetEquipments(int userId)
        {
            var dtLogin = DalLogin.GetUser(userId);
            if (dtLogin.Rows.Count==0)
            {
                return new List<EquipmentModel>();
            }
            var dtEquipment = DalEquipment.GetEquipmentList();

            //var dtEquipment = new DataTable();
            //if (dtLogin.Rows[0]["UserType"].ToString() == "1")
            //{
            //    dtEquipment = DalEquipment.GetEquipmentList();
            //}
            //else
            //{
            //    dtEquipment = DalEquipment.GetEquipmentList(UserId.ToString());
            //}
            return dtEquipment.AsEnumerable().Select(dr => new EquipmentModel {
                EquipmentId = dr["EquipmentId"].ToString(),
                EquipmentName = dr["EquipmentName"].ToString(),
                Description = dr["Description"].ToString()
            }).ToList();
        }
    }
}
