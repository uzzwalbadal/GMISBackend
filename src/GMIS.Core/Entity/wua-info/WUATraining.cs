using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.wua_info
{
    [Table("DOI_WUATrainings")]
    public class WUATraining : FullAuditedEntity<int>
    {
        public string TrainingName { get; set; }
        public int NoOfParticipants { get; set; }
        public int TrainingPeriod { get; set; }
        public int NoOfFemaleParticipant { get; set; }
        [Column(TypeName = "date")]
        public DateTime TrainingDate { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
