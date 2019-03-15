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
    using ShopXam.Web.Models;
    using System.IO;

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
        public async Task<IActionResult> Create(ProductViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;
                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), 
                           "wwwroot\\images\\Products",
                           view.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }
                    path = $"~/images/Products/{view.ImageFile.FileName}";
                }

                var product = this.ToProduct(view, path);
                //TODO: Cambiando el logged user
                product.user = await this.userHelper.GetUserByEmailAsync("efabal@mardom.com");
                await this._Productrepository.CreateAsync(product);
                await this._Productrepository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Product ToProduct(ProductViewModel view, string path)
        {
            return new Product
            {
                Id = view.Id,
                ImageUrl = path,
                Disponible = view.Disponible,
                UltimaCompra = view.UltimaCompra,
                UltimaVenta = view.UltimaVenta,
                Nombre = view.Nombre,
                Precio = view.Precio,
                Stock = view.Stock,
                user = view.user
            };
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this._Productrepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            var view = this.ToProductViewModel(product);
            return View(view);
        }

        private ProductViewModel ToProductViewModel(Product product)
        {
           return new ProductViewModel
           {
                Id = product.Id,       
                Disponible = product.Disponible,
                UltimaCompra = product.UltimaCompra,
                UltimaVenta = product.UltimaVenta,
                ImageUrl = product.ImageUrl,
                Nombre = product.Nombre,
                Precio = product.Precio,
                Stock = product.Stock,
                user = product.user
            };
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;
                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        path = Path.Combine(Directory.GetCurrentDirectory(),
                               "wwwroot\\images\\Products",
                               view.ImageFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }
                        path = $"~/images/Products/{view.ImageFile.FileName}";
                    }

                    var product = this.ToProduct(view,path);
                    product.user = await this.userHelper.GetUserByEmailAsync("efabal@mardom.com");
                    await this._Productrepository.UpdateAsync(product);
                    await this._Productrepository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this._Productrepository.ExistAsync(view.Id))
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
            return View(view);
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
