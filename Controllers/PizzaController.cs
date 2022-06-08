using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public static ListaPizze lPizze = null;
        public IActionResult Index()
        {


            if (lPizze == null)
            {
             
                // Pizzeria pizzeria = new Pizzeria("Pizzeria del Corso");

                Pizza Margherita = new Pizza(1, "Margherita", "La più semplice, la più classica ,la più famosa, la meno costosa", "https://www.buttalapasta.it/wp-content/uploads/2017/11/pizza-margherita.jpg", 6.00);
                Pizza MortazzaPazza = new Pizza(2, "Mortazza Pazza", "Con mortadella a valanghe , una volta che l'assaggi non torni più indietro", "https://www.cuochemabuone.it/wp-content/uploads/2022/01/pizza-con-mortadella-e-pistacchi.jpg", 15.50);
                Pizza Favolosa = new Pizza(3, "Favolosa", "Unica, gustosa e la più costosa", "https://www.mysocialrecipe.com/files/admin/immagini/3007364018926424174124608555418249065307469o-master.jpg", 19.50);
                Pizza quattroFormaggi =new Pizza(4, "4 Formaggi", "Formaggiosa , incredibilmente filante e gustosa ", "https://www.unmondodisapori.it/wp-content/uploads/2017/10/4formaggi.jpg", 9.50);
          
                lPizze = new();
               
                lPizze.pizze.Add(Margherita);
                lPizze.pizze.Add(MortazzaPazza);
                lPizze.pizze.Add(Favolosa);
                lPizze.pizze.Add(quattroFormaggi);
            }

           
           

            return View(lPizze);
            
        }

        public IActionResult ShowPizza(Pizza pizza)
        {

            if (!ModelState.IsValid)
            {
                return View("CreaPizza", pizza);
            }

           Pizza newPizza = new Pizza()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                Url = pizza.Url,
                Price = pizza.Price,

            };
            lPizze.pizze.Add(newPizza);
            return View("ShowPizza", newPizza);
        }

        public IActionResult AggiornaPizza(Pizza pizza)
        {

            return View("AggiornaPizza", pizza);
        }

        public IActionResult EditPizza(Pizza pizza)
        {
            //Pizza updatePizza = new Pizza();
            //updatePizza = (Pizza)pizze.pizzas.Where(x => x.Id == pizza.Id);

            Pizza updatePizza = lPizze.pizze.Find(x => x.Id == pizza.Id);

            updatePizza.Name = pizza.Name;
            updatePizza.Description = pizza.Description;
            updatePizza.Price = pizza.Price;
            if (updatePizza.Url != pizza.Url)
            {
                updatePizza.Url = pizza.Url;
            }

            return View("Show", updatePizza);

        }

        public IActionResult CreaNuovaPizza()
        {
            Pizza nuovaPizza = new Pizza()
            {
                Id = 0,
                Name = "",
                Description = "",
                Url = "",
                Price = 0.0,

            };

            return View("CreaPizza",nuovaPizza);
        }

        [HttpPost]
        public IActionResult RimuoviPizza(Pizza pizza)
        {
            Pizza updatePizza = lPizze.pizze.Find(x => x.Id == pizza.Id);
            if (updatePizza.Id == pizza.Id)
            {
                var ok = lPizze.pizze.Remove(updatePizza);
                Console.WriteLine(ok);
            }
            return RedirectToAction("Index");
        }



       

    }
}
