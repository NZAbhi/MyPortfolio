using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyPortfolio.Data;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Pages
{
    public class CreateProfileModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CreateProfileModel(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }


        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LasttName { get; set; }
        [BindProperty]
        public string ProfileDiscription { get; set; }
        [BindProperty]
        public string Languages { get; set; }
        [BindProperty]
        public string MyProjectsLink { get; set; }
        [BindProperty]
        public int ContactNumber { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string LinkedInLink { get; set; }
        [BindProperty]
        public string School1 { get; set; }
        [BindProperty]
        public string Course1 { get; set; }
        [BindProperty]
        public string Course2 { get; set; }
        [BindProperty]
        public string Course3 { get; set; }
        [BindProperty]
        public string Course4 { get; set; }
        [BindProperty]
        public string Course5 { get; set; }
        [BindProperty]
        public string Course6 { get; set; }
        [BindProperty]
        public string Course7 { get; set; }
        [BindProperty]
        public string Course8 { get; set; }
        [BindProperty]
        public string Course9 { get; set; }
        [BindProperty]
        public string Course10 { get; set; }

        [BindProperty]
        public string School2 { get; set; }
        [BindProperty]
        public string School2Education { get; set; }

        [BindProperty]
        public string TecnicalCompitences { get; set; }

        [BindProperty]
        public string WorkExprience1 { get; set; }
        [BindProperty]
        public string WorkExprience2 { get; set; }
        [BindProperty]
        public string WorkExprience3 { get; set; }
        [BindProperty]
        public string WorkExprience4 { get; set; }
        [BindProperty]
        public string WorkExprience5 { get; set; }

        [BindProperty]
        public string WorkExpriences { get; set; }
        [BindProperty]
        public string References { get; set; }

        [BindProperty]
        public IFormFile UploadedImage { get; set; }


        public IList<MyPortfolioInfo> MyInfos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            MyInfos = await _context.MyPortfolioInfo.ToListAsync();


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (UploadedImage != null)
            {
                var fileFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                var uniqueFileName = UploadedImage.FileName;
                string filePath = Path.Combine(fileFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(fileStream);
                }
            }

            MyPortfolioInfo myInfo = new MyPortfolioInfo();
            //foodItem.Purchased = (Request.Form["Purchased"].ToString()).Contains("on") ? true : false;
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            myInfo.FirstName = FirstName;
            myInfo.LasttName = LasttName;
            myInfo.Image = UploadedImage != null ? UploadedImage.FileName : "";
            myInfo.ProfileDiscription = ProfileDiscription;
            myInfo.Languages = Languages;
            myInfo.MyProjectsLink = MyProjectsLink;
            myInfo.ContactNumber = ContactNumber;
            myInfo.Email = Email;
            myInfo.LinkedInLink = LinkedInLink;
            myInfo.School1 = School1;
            myInfo.Course1 = Course1;
            myInfo.Course2 = Course2;

            myInfo.Course3 = Course3;
            myInfo.Course4 = Course4;
            myInfo.Course5 = Course5;
            myInfo.Course6 = Course6;
            myInfo.Course7 = Course7;
            myInfo.Course8 = Course8;
            myInfo.Course9 = Course9;
            myInfo.Course10 = Course10;

            myInfo.School2 = School2;
            myInfo.School2Education = School2Education;


            myInfo.TecnicalCompitences = TecnicalCompitences;

            myInfo.WorkExprience1 = WorkExprience1;
            myInfo.WorkExprience2 = WorkExprience2;
            myInfo.WorkExprience3 = WorkExprience3;
            myInfo.WorkExprience4 = WorkExprience4;
            myInfo.WorkExprience5 = WorkExprience5;


            myInfo.References = References;





            _context.MyPortfolioInfo.Add(myInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
