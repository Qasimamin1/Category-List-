using BulkyBookNew.Data;
using BulkyBookNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookNew.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            //so it will go to the base and retrieve all the Categories. 

            IEnumerable<Category> objCategoryList = _db.Categories;

            return View(objCategoryList);
            }

        //Get
            public IActionResult Create()
            {
                //so it will go to the base and retrieve all the Categories. 

                return View();
            
            }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Create Successfully";
                return RedirectToAction("Index");
            }



            return View(obj);
        
        
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {

                return NotFound();
            }
            //so it will go to the base and retrieve all the Categories. 
            var categoryFromDb= _db.Categories.Find(id);
           // var categoryFromDbFirst= _db.Categories.FirstOrDefault(c => c.Id==id);
            //var categoryFromDbSingle= _db.Categories.SingleOrDefault(c => c.Id==id);
            if(categoryFromDb==null)
            {

                return NotFound();
            }
            
            return View(categoryFromDb);

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edit Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }
            //so it will go to the base and retrieve all the Categories. 
            var categoryFromDb = _db.Categories.Find(id);
            // var categoryFromDbFirst= _db.Categories.FirstOrDefault(c => c.Id==id);
            //var categoryFromDbSingle= _db.Categories.SingleOrDefault(c => c.Id==id);
            if (categoryFromDb == null)
            {

                return NotFound();
            }

            return View(categoryFromDb);

        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            
                 
                if (obj == null)
                {

                    return NotFound();
                }
            
           
            
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
            
            


        }

    }
}

