using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Horticlima.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Horticlima.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("UsuarioId, UsuarioSenha")] Usuario usuario)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == usuario.UsuarioId);

            if (user == null)
            {
                ViewBag.Message = "Usuário e/ou senha inválido!";
                return View();
            }

            bool isSenhaOk = BCrypt.Net.BCrypt.Verify(usuario.UsuarioSenha, user.UsuarioSenha);

            if (isSenhaOk)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UsuarioNome),
                    new Claim(ClaimTypes.NameIdentifier, user.UsuarioNome!),
                    new Claim(ClaimTypes.Role, user.Perfil.ToString()),
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new(userIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7),
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/Produtos");
            }

            return View();
        }

        public IActionResult AcessDenied()
        {
            return View();
        }


        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,UsuarioNome,UsuarioSenha,Perfil")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.UsuarioSenha = BCrypt.Net.BCrypt.HashPassword(usuario.UsuarioSenha);
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,UsuarioNome,UsuarioSenha,Perfil")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.UsuarioSenha = BCrypt.Net.BCrypt.HashPassword(usuario.UsuarioSenha);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioId))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
