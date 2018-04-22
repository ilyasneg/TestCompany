using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestCompanyProject.Models
{
    public class StandInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; }
        public StandStatus Status { get; set; }
        public DateTime DateTime { get; set; }
        public string Error { get; set; }
        public string Name { get; set; }
    }

    public enum StandStatus
    {
        NotReady,
        Ready
    }
}
