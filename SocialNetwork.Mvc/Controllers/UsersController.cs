using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Models;
using SocialNetwork.Data;
using SocialNetwork.Data.Models.ViewModels;
using SocialNetwork.Mvc.Extensions;

namespace SocialNetwork.Mvc.Controllers;

public class UsersController : Controller
{
    private readonly SocialNetworkDbContext applicationDbContext;


    public UsersController(SocialNetworkDbContext contexto)
    {
        applicationDbContext = contexto;
    }

    public async Task<IActionResult> Index()
    {
        List<User> users = await applicationDbContext.Users.ToListAsync();
        return View(users);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        List<User> users = await applicationDbContext.Users.ToListAsync();
        foreach (var user in users)
        {
            if (loginViewModel.User == user.Login && user.Password == loginViewModel.Password)
            {
                User usuarioLogeado = user;
                HttpContext.Session.SetObect("UsuarioEnSession", usuarioLogeado);
                return RedirectToAction("Index", "Articles");
            }
        }
        return View();
    }

    [HttpGet]
    public IActionResult PreviousVerification()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> PreviousVerification(PreviousVerificationViewModel previousVerificationVM)
    {
        if (previousVerificationVM.action == "confirm")
        {
            // Buscar el usuario en la base de datos
            var user = await applicationDbContext.Users.FirstOrDefaultAsync(u => u.Login == previousVerificationVM.User && u.Email == previousVerificationVM.Email);

            if (user == null)
            {
                // Si el usuario no existe o el correo electrónico no coincide, mostrar un mensaje de error
                ViewData["ErrorMessage"] = "User or email not found.";
                return View();
            }

            // Redirigir a la vista RestorePassword
            return RedirectToAction("RestorePassword", "Users", new { User = previousVerificationVM.User }); // Pasa el nombre de usuario como parámetro
        }
        else
        {
            // Si se cancela, redirigir a la página de inicio de sesión
            return RedirectToAction("Login", "Account");
        }
    }


    [HttpGet]
    public IActionResult RestorePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RestorePassword(RestorePasswordViewModel restorePasswordVM)
    {
        if (restorePasswordVM.action2 == "confirm2")
        {
            // Buscar al usuario por su nombre de usuario
            var user = applicationDbContext.Users.FirstOrDefault(u => u.Login == restorePasswordVM.User);

            // Verificar si se encontró al usuario
            if (user == null)
            {
                ViewData["ErrorMessage"] = "User not found.";
                return View();
            }

            // Verificar si las contraseñas coinciden
            if (restorePasswordVM.newPassword != restorePasswordVM.confirmPassword)
            {
                ViewData["ErrorMessage"] = "New passwords do not match.";
                return View();
            }

            // Cambiar la contraseña del usuario
            user.Password = restorePasswordVM.newPassword;

            // Guardar los cambios en la base de datos
            applicationDbContext.Update(user);
            await applicationDbContext.SaveChangesAsync();

            // Redirigir a alguna página de éxito o mostrar un mensaje de éxito.
            //return RedirectToAction("Login", "Users");
            return RedirectToAction("Index", "Articles");
        }
        else
        {
            return RedirectToAction("Login", "Users"); // O ajusta la ruta según tu configuración de enrutamiento.
        }
    }



    [HttpGet]
    public IActionResult Details()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Edit()
    {
        User usuarioLogeado = HttpContext.Session.GetObject<User>("UsuarioEnSession");
        return View(usuarioLogeado);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(User usuario)
    {
        User usuarioLogeado = HttpContext.Session.GetObject<User>("UsuarioEnSession");

        applicationDbContext.Update(usuario);
        await applicationDbContext.SaveChangesAsync();

        if (usuarioLogeado.Id == usuario.Id)
        {
            HttpContext.Session.SetObect("UsuarioEnSession", usuario);
        }

        return RedirectToAction("Details", "Users");
    }


    [HttpGet]
    public IActionResult LogOut()
    {
        HttpContext.Session.Remove("UsuarioEnSession");
        return RedirectToAction("Index", "Articles");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(User user)
    {
        if (ModelState.IsValid)
        {
            // Verificar si el login ya existe
            var loginExistente = await applicationDbContext.Users.FirstOrDefaultAsync(u => u.Login == user.Login);
            if (loginExistente != null)
            {
                ModelState.AddModelError("Login", "El login ya está registrado.");
                // Devolvemos la vista con el error
                return View(user);
            }

            // Verificar si el email ya existe
            var emailExistente = await applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (emailExistente != null)
            {
                ModelState.AddModelError("Email", "El correo electrónico ya está registrado.");
                // Devolvemos la vista con el error
                return View(user);
            }

            applicationDbContext.Users.Add(user);
            await applicationDbContext.SaveChangesAsync();
            HttpContext.Session.SetObect("UsuarioEnSession", user);
            return RedirectToAction("Index", "Articles");
        }

        return View();
    }

}
