using ASPLesson4.Entities;
using ASPLesson4.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPLesson4.Pages.Product
{
    public class IndexModel : PageModel
    {


        private readonly ProductDbContext _context;
        public IndexModel(ProductDbContext context)
        {

            _context = context;
        }
        public string Message { get; set; }
        public List<Entities.Product> Products { get; set; }
        public void OnGet()
        {
            Message = $"Today is {DateTime.Now.DayOfWeek}";
            Products = _context.Products.ToList();
        }
        [BindProperty]
        public Entities.Product Product { get; set; }
        public IActionResult OnPost()
        {
            _context.Products.Add(Product);
            _context.SaveChanges();

            Message = $"{Product.Name} was added successfully!";
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var productToDelete = _context.Products.SingleOrDefault(p => p.Id == id);
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return RedirectToPage("Index"); 
        }
    }
}
