using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
            return View(userlist);
        }

        public ActionResult Details(int id)
        {
            // Find the user in the userlist by the provided id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user object to the Details view
            return View(user);
        }


        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            return View();
        }
 
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Add the new user to the userlist
                userlist.Add(user);

                // Redirect to the Index action to display the list of users
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the same view to display validation errors
            return View(user);
        }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Find the user in the userlist by the provided id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user object to the Edit view
            return View(user);
        }


        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // First, check if the provided user model is valid
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the Edit view with the user object to display validation errors
                return View(user);
            }

            // Find the existing user in the userlist by the provided id
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                // If no user is found with the provided ID, return a HttpNotFound result
                return HttpNotFound();
            }

            // Update the existing user's properties with the values from the form
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            // Continue updating other properties as necessary

            // After updating the user, redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Find the user in the userlist by the provided id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFound result
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user object to the Delete view
            return View(user);
        }

        // GET: User/Delete/5


        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // Find the user in the userlist by the provided id
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                // Remove the user from the list
                userlist.Remove(user);
            }

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
    }
}
