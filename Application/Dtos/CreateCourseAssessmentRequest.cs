using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public sealed record class CreateCourseAssessmentRequest(
        [Required]Guid CourseId,
        [Required]DateTime AssessmentDate
    );
    
}
