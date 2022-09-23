using MISA.Web08.Amis.API.Resources;

namespace MISA.Web08.Amis.API.Entities.DTO
{
    public class ErrorResult
    {
        private string text { get; set; }

        private string link { get; set; }

        private string a { get; set; }

        public AmisErrorCode AmisErrorCodes { get; set; }
        public  ErrorResult()
        {

        }

        public ErrorResult (AmisErrorCode AmisErrorCode, string text ,string link)
        {
           AmisErrorCodes = AmisErrorCode;
            this.text = text;
            this.link = link;
            
        }
    }
}
