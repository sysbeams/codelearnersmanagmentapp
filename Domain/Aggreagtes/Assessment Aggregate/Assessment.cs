using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggreagtes.Assessment_Aggregate;

    public class Assessment : AuditableEntity<Guid>, IAggregateRoot
    {
        public DateTime AssessmentDate { get; private set; }
        public string Batch { get; private set; } 
      internal Assessment(DateTime assessmentDate, string batch)
      {
        AssessmentDate = assessmentDate;
        Batch = batch;
      }

    }


