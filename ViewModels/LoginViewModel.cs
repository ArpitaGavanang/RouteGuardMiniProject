using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;

namespace RouteGuardProject.ViewModels
    
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "please Enter Valid Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please Enter Valid Password")]
        public string Password { get; set; }
    }
}
