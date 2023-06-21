using Horticlima.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Horticlima.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([Bind("UsuarioNome, UsuarioSenha")] Usuario usuario)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioNome == usuario.UsuarioNome);

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
                    new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Name, user.UsuarioNome),
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
            else
            {
                ViewBag.Message = "Usuário e/ou senha inválido!";
                return View();
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Produtos");
        }

        [AllowAnonymous]
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

        // NAME, CPF AND CNPJ VERIFICATION
        private bool NameAlredyExist(string UsuarioNome)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.UsuarioNome == UsuarioNome);

            return usuario != null;
        }

        private bool CpfAlredyExist(string cpf)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CPF == cpf);

            return usuario != null;
        }

        private bool CnpjAlredyExist(string cnpj)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CNPJ == cnpj);

            return usuario != null;
        }

        [AllowAnonymous]
        public IActionResult CreateManager()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateManager([Bind("UsuarioId,UsuarioNome,UsuarioSenha,CNPJ,Perfil")] Usuario usuario)
        {
            if (NameAlredyExist(usuario.UsuarioNome))
            {
                ViewBag.Message = "Nome já existe";
                return View(usuario);
            }

            if (CnpjAlredyExist(usuario.CNPJ))
            {
                ViewBag.Message = "CNPJ já existe";
                return View(usuario);
            }

            if (ModelState.IsValid)
            {
                usuario.UsuarioSenha = BCrypt.Net.BCrypt.HashPassword(usuario.UsuarioSenha);
                usuario.Perfil = Perfil.Gerente;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Produtos");
            }

            return View(usuario);
        }

        [AllowAnonymous]
        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,UsuarioNome,UsuarioSenha,CPF,Perfil")] Usuario usuario)
        {
            if (NameAlredyExist(usuario.UsuarioNome))
            {
                ViewBag.Message = "Nome já existe";
                return View(usuario);
            }

            if (CnpjAlredyExist(usuario.CPF))
            {
                ViewBag.Message = "CPF já existe";
                return View(usuario);
            }

            if (ModelState.IsValid)
            {
                usuario.UsuarioSenha = BCrypt.Net.BCrypt.HashPassword(usuario.UsuarioSenha);
                usuario.Perfil = Perfil.User;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Produtos");
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
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,UsuarioNome,UsuarioSenha,CPF,CNPJ,Perfil")] Usuario usuario)
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
