using System.ComponentModel.DataAnnotations;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class FAQCreateVM
    {
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string QuestionAZ { get; set; }  
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string AnswerAZ { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string QuestionRU { get; set; }  
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string AnswerRU { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string QuestionEN { get; set; }  
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string AnswerEN { get; set; }
        public bool IsActive { get; set; }
    }
}
