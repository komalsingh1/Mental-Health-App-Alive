using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health
{
    public interface IMentalHealthTestComponent
    {
        Task<Question> GetQuestion(Question question);
        Task<bool> SaveResponse(Answer answer);
        Task<Report> GetResult(Report result);
    }
}
