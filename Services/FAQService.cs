using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthAtHeart.Models;

namespace YouthAtHeart.Services
{
    public class FAQService
    {
        private Models.YouthAtHeartContext _context;
        public FAQService(Models.YouthAtHeartContext context)
        {
            _context = context;
        }
        public List<FAQ> GetAllQuestion()
        {
            List<FAQ> AllFAQ = _context.FAQs.ToList();
            return AllFAQ;
        }
        private bool FAQExist(string qn)
        {
            return _context.FAQs.Any(e => e.Question == qn);
        }
        public bool AddQuestion (FAQ newQuestion)
        {
            if (FAQExist(newQuestion.Question))
            {
                return false;
            }
            _context.Add(newQuestion);
            _context.SaveChanges();
            return true;
        }
        public FAQ GetFAQbyQuestion(string Qn)
        {
            FAQ theQuestion = _context.FAQs.Where(e => e.Question == Qn).FirstOrDefault();
            return theQuestion;
        }
    }
}
