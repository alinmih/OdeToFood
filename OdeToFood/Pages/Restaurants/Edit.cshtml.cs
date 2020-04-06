using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurant;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<SelectListItem> Cuisines { get; set; }
        
        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public EditModel(IRestaurantData restaurant, IHtmlHelper htmlHelper)
        {
            this.restaurant = restaurant;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restaurantId)
        {

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            Restaurant = restaurant.GetRestaurantById(restaurantId);
            if (Restaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                restaurant.Update(Restaurant);
                restaurant.Commit();
            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            
            return Page();
        }
    }
}