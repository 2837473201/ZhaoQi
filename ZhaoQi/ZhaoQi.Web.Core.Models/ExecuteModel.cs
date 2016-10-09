using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZhaoQi.Web.Core.Models
{
    [Table("ZHANGLI.Execute")]
    public class ExecuteModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Tag { get; set; }
        [StringLength(50)]
        public string TagValue { get; set; }
        [StringLength(50)]
        public string ProjectId { get; set; }
        [StringLength(50)]
        public string TagUint { get; set; }
        [StringLength(50)]
        public string TagDesc { get; set; }
        [StringLength(50)]
        public string UpdateTime { get; set; }
        [StringLength(50)]
        public string Flag { get; set; }
        [StringLength(50)]
        public string ExecuteTime { get; set; }


        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }



    }
}
