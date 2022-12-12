using Microsoft.AspNetCore.Mvc;
using Practice4School.Models;

namespace Practice4School.Controllers
{
    public class HomeController : Controller
    {
        public List<Item> MyItems = new List<Item>()
        { 
            new Item { Id=1  , Name="Item1" },
            new Item { Id=2  , Name="Item2" },
            new Item { Id=3  , Name="Item3" },
            new Item { Id=4  , Name="Item4" },
            new Item { Id=5  , Name="Item5" }
        };

        public IActionResult Index()
        {
            
            return View(MyItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            MyItems.Add(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Item ToEdit = MyItems.Where(x => x.Id == id).FirstOrDefault();
            return View(ToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Item itemModel)
        {
            Item item=MyItems.Where(x => x.Id == itemModel.Id).FirstOrDefault();
            item.Name=itemModel.Name;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Item ToDelete = MyItems.Where(x => x.Id == id).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Item item)
        {
            MyItems.Remove(item);
            return RedirectToAction("Index");
        }
        //TODO neshta ne se triqt probably doesnt need post i get i probabli ima problemi v html sushtoto vaji i za create i edit information passinga nqkude se gubi
    }
}
