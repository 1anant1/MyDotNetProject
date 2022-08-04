using System.ComponentModel.DataAnnotations;

namespace Registration_Form.Models
{
    public class ExamQuestions
    {
        [Key]
        public int ExamQuestionId { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Answer { get; set; }
    }
}
