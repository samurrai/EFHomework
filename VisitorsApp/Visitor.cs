using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VisitorsApp
{
    public class Visitor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CertificateNumber { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime EnterTime { get; set; } = new DateTime();
        [Column(TypeName = "datetime2")]
        public DateTime ExitTime { get; set; } = new DateTime();
        public string VisitPurpose { get; set; }

        public Visitor()
        {
            Id = Guid.NewGuid();
        }
    }
}
