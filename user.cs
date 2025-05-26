using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.String;

namespace crud;


public class user
{
    [JsonIgnore]
    public Guid ای_دی { get; set; }
    [Required(ErrorMessage = "وارد کردن نام الزامی است")] 
    [MaxLength(100)]
    public string نام { get; set; } 
    [Required(ErrorMessage = "وارد کردن شماره تلفن الزامی است")]
    [MaxLength(11)]
    public string شماره_تلفن { get; set; } 
    [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
    [MaxLength(500)]
    public string ایمیل {get;set;} 
}