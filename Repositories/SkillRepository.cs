using RecruitmentSolution.Data;
using RecruitmentSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSolution.Repositories
{
    public class SkillRepository : GenericRepository<Skill>, IRepository<Skill>
    {
        public SkillRepository(RecruitmentContext context) : base(context)
        {
        }
    }


    //public interface ISkillRepository : IRepository<Skill>
    //{
    //    public Skill GetEmployeeSkill(int skillCode);
    //}
    //public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    //{
    //    public SkillRepository(RecruitmentContext context) : base(context)
    //    {
    //    }
    //    public Skill GetEmployeeSkill(int skillCode)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
