﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using SpacePark.FrontEnd.Services;
using System.Threading.Tasks;

namespace SpacePark.FrontEnd.Pages
{
    public class CheckOutVisitorModel : PageModel
    {

        private readonly CheckOutVisitorService _checkOutVisitorService;
        public bool PageCheck = false;


        public CheckOutVisitorModel(CheckOutVisitorService checkOutVisitorService)
        {

            _checkOutVisitorService = checkOutVisitorService;
        }

        public async Task OnPost()
        {
            string visitorName = Request.Form["visitorname"];
            string shipname = Request.Form["shipname"];

            var response = _checkOutVisitorService.DeleteVisitor(visitorName);
            if (response != null)
            {
                PageCheck = true;
            }
            else
            {
                PageCheck = false;
            }
        }
    }
}
