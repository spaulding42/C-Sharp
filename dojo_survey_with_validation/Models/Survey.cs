using System.ComponentModel.DataAnnotations;

namespace DojoSurvey.Models;
#pragma warning disable CS8618


// Validation for the Comment data to allow empty or 20+ chars but throws an err if less than 20
public class CommentValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string? message = value.ToString();
            if (message == null){
                message = "";
            } 
            if(message.Length >=20 || message =="")
            {
                return ValidationResult.Success;
            }
        }
        if (value == null)
        {
            return ValidationResult.Success;
        }
        else{
            return new ValidationResult("Comment must either be empty or be 20+ chars");
        }
    }
}

//  -------------------- SURVEY class -------------
public class Survey
{

    [Required(ErrorMessage =  " is required.")]
    [MinLength(2, ErrorMessage ="must be at least 2 characers")]
    public string Name {get;set;}

    [Required(ErrorMessage =  " is required.")]
    public string Location {get;set;}

    [Required(ErrorMessage =  " is required.")]
    public string Language {get;set;}

    [CommentValidation]
    // [MinLength(20, ErrorMessage ="must be 20+ chars")]       made cusom validation so not needed
    public string? Comment {get;set;}

}

