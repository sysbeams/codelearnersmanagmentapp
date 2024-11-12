using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Contracts;
using Domain.Exceptions;
using Domain.Paging;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class Topic : AuditableEntity<Guid>
    {
        public string Name { get; private set; } = default!;
        public Guid CurriculumId { get; private set; }
        public IReadOnlyList<Pratical> Praticals => _praticals.AsReadOnly();
        public IReadOnlyList<Exercise> Exercises => _exercises.AsReadOnly();
        private List<Pratical> _praticals = [];
        private List<Exercise> _exercises = [];


        public Topic(string name, Guid curriculumid, string exercisename, string exerciselink, string exercisecontent)
        {
            if (curriculumid == Guid.Empty) throw new ArgumentNullOrEmptyException("Curriculum Id  cannot be empty");
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullOrEmptyException("Topic name cannot be null or empty");
            Name = name;
            CurriculumId = curriculumid;
            AddExercise(exercisename, exerciselink, exercisecontent);
        }

        public void AddPratical(string name, string link, string content)
        {
            Pratical pratical = new Pratical(name, this.Id, link, content);
            _praticals.Add(pratical);
        }
        public void AddExercise(string name, string link, string content)
        {
            Exercise exercise = new Exercise(name, this.Id, link, content);
            _exercises.Add(exercise);
        }
        public void RemoveExercise(Exercise exercise)
        {
            if (_exercises.Count < 2) throw new OutOfSpecifiedRangeException("Exercises cannot be less than 1");
            _exercises.Remove(exercise);
        }
        public void RemovePratical(Pratical pratical)
        {
            if (_praticals.Count < 2) throw new OutOfSpecifiedRangeException("Praticals cannot be less than 1");
            _praticals.Remove(pratical);
        }
    }
    
}
