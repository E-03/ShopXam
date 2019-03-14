namespace ShopXam.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Data.Entities;
    using Data.Helper;

    public class ProductsController : Controller
    {
        private readonly IProductRepository _Productrepository;
        private readonly IUserHelper userHelper;

        public ProductsController(IProductRepository Productrepository,IUserHelper userHelper)
        {
            this._Productrepository = Productrepository;
            this.userHelper = userHelper;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(this._Productrepository.GetAll());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this._Productrepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                //TODO: Cambiando el logged user
                product.user = await this.userHelper.GetUserByEmailAsync("efabal@mardom.com");
                await this._Productrepository.CreateAsync(product);
                await this._Productrepository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this._Productrepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    product.user = await this.userHelper.GetUserByEmailAsync("efabal@mardom.com");
                    await this._Productrepository.UpdateAsync(product);
                    await this._Productrepository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this._Productrepository.ExistAsync(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this._Productrepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prod = await this._Productrepository.GetByIdAsync(id);
            await this._Productrepository.DeleteAsync(prod);
            await this._Productrepository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
