using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace KosApi.Model
{
    public class CapcthaViewModel

    {
        [Required]
        public string Captcha { get; set; }
    }
}
