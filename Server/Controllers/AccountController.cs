using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SurcosBlazor.Server.Context;
using SurcosBlazor.Server.Helpers;
using SurcosBlazor.Shared;
using SurcosBlazor.Shared.Entidades;

namespace ApiSurcos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly WebApiDbContext _context;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, WebApiDbContext context)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }
        [HttpPost("Crear")]
        public async Task<ActionResult<UserInfo>> CreateUser(UserInfo model)
        {
            var user = new ApplicationUser { UserName = model.username, Email = model.username };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                foreach (var rol in model.roles)
                {

                    await _userManager.AddToRoleAsync(user, rol.rol);
                }
                foreach (Vendedor vendedor in model.vendedores)
                {
                    _context.userVendedor.Add(new UserVendedor
                    {
                        Vendedor = await _context.vendedor.FirstAsync(x => x.Id == vendedor.Id),
                        userName = model.username
                    });
                }
                foreach (Deposito deposito in model.depositos)
                {
                    _context.userDeposito.Add(new UserDeposito
                    {
                        Deposito = await _context.deposito.FirstAsync(x => x.Id == deposito.Id),
                        userName = model.username
                    });
                }

                foreach (Caja caja in model.cajas)
                {
                    _context.userCaja.Add(new UserCaja
                    {
                        Caja = await _context.caja.FirstAsync(x => x.Id == caja.Id),
                        userName = model.username
                    });
                }
                await _context.SaveChangesAsync();
                return model;


            }
            else

            {
                return BadRequest("Username or password invalid");
            }

        }
       
        // CREAR EL USUARIO Y CLIENTE DESDE EL ECOMMERCE

        [HttpPost("CrearUserCliente")]
        public async Task<ActionResult<UserClienteInfo>> CrearUserCliente(UserClienteInfo model)
        {
            var user = new ApplicationUser { UserName = model.Cliente.email, Cliente = model.Cliente};
            if (await _userManager.FindByNameAsync(model.Cliente.email) != null) {

                return BadRequest("El email está en uso");

            }
            try
            {
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                   
                    await _userManager.AddToRoleAsync(user, "Cliente");

                                     
                    _context.SaveChanges();

                    return model;
                }
                else
                {
                    return BadRequest("Email o contraseña invalidos.");
                }

            }
            catch (Exception ex)
            {

                throw;
            }
          

        }
        [HttpPost("CambiarContraseña")]
        public async Task CambiarContraseña(UserInfo userInfo)
        {

            ApplicationUser user = await _context.Users.SingleAsync(w => w.UserName == userInfo.username);
            try
            {
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, userInfo.Password);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //Recupero de Contraseña
        [HttpGet("EstablecerTokenDeRecuperoDeContraseña")]
        public async Task<ActionResult<UserTokenRecovery>> EstablecerTokenDeRecuperoDeContraseña(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                return BadRequest("El Email no está registrado");
            }
            UserTokenRecovery userToken = new UserTokenRecovery { email = email, token = Convert.ToString(Guid.NewGuid()), fechaExpiracion = DateTime.Now.AddMinutes(15) };
            _context.userTokenRecovery.Add(userToken);
            await _context.SaveChangesAsync();

            SendEmail.Send($"<h2>Tu token de recupero es:</h2> <div><strong>{userToken.token}</strong></div>", "Recupero de contraseña Surcos", userToken.email);

            return userToken;

        }
        [HttpGet("ValidarTokenDeRecuperoDeContraseña")]
        public async Task<ActionResult<UserTokenRecovery>> ValidarTokenDeRecuperoDeContraseña(string email, string token)
        {
            var userTokenRecovery = await _context.userTokenRecovery.FirstOrDefaultAsync(x => x.email == email && x.token == token);
            if (userTokenRecovery == null)
            {
                return BadRequest("El Token es invalido");
            }

            return userTokenRecovery;

        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserInfo>> Login([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.username, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                userInfo.userToken = await BuildToken(userInfo);
                return userInfo;
            }
            else
            {
                Console.WriteLine("Error");
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest("Username or password invalid");
            }
        }

        [HttpPost("LoginECommerce")]
        public async Task<ActionResult<UserClienteInfo>> LoginECommerce([FromBody] UserInfo userInfo)
        {
            UserClienteInfo userClienteInfo = new UserClienteInfo();
            var result = await _signInManager.PasswordSignInAsync(userInfo.username, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var IdentityUser =  _context.Users.FirstOrDefault(x => x.UserName == userInfo.username);
                if (IdentityUser.ClienteId != null && IdentityUser.ClienteId != 0)
                {
                    userClienteInfo.ClienteId = (int)IdentityUser.ClienteId;
                    userClienteInfo.userToken = await BuildToken(userInfo, userClienteInfo.ClienteId);
                    return userClienteInfo;
                }
                else {
                    return BadRequest("Este usuario no es un cliente");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest("Username or password invalid");
            }
        }

        private async Task<UserToken> BuildToken(UserInfo userInfo, int ClienteId=0)
        {
            IdentityUser user =  _context.Users.Where(w => w.UserName == userInfo.username).Single();
            var roles =  _context.UserRoles.Where(x => x.UserId == user.Id).ToList();
            List<Claim> claims = new List<Claim> {  new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.username),
                                                    new Claim(ClaimTypes.Name, userInfo.username),
                                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                                    new Claim("ClienteId",ClienteId.ToString())
             };
            foreach (var r in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, r.RoleId));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tiempo de expiración del token. En nuestro caso lo hacemos de una hora.
            var expiration = DateTime.Now.AddHours(-3).AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        [HttpGet("Roles")]

        public async Task<ActionResult<List<Roles>>> getroles()
        {
            List<Roles> roles = new List<Roles>();
            var res =  _context.Roles.ToList();

            for (int i = 0; i < res.Count(); i++)
            {

                roles.Add(new Roles { id = res[i].Id, rol = res[i].Name });
            }

            return roles;
        }

        [HttpGet("Usuarios")]

        public async Task<ActionResult<List<UserInfo>>> getUsuarios()
        {
            List<UserInfo> users = new List<UserInfo>();
            try
            {
                List<ApplicationUser> usuario =  _context.Users.Include(x => x.Cliente).ToList();
                List<Roles> roles1 = new List<Roles>();
                List<Vendedor> vendedores = new List<Vendedor>();
                List<Deposito> depositos = new List<Deposito>();
                List<Caja> cajas = new List<Caja>();


                foreach (ApplicationUser identity in usuario)
                {
                    if (identity.ClienteId != 0) {
                        identity.Cliente =  _context.cliente.Find(identity.ClienteId);
                    }
                    vendedores = new List<Vendedor>();
                    depositos = new List<Deposito>();
                    cajas = new List<Caja>();

                    List<string> roles = await _userManager.GetRolesAsync(identity) as List<string>;
                    roles1 = new List<Roles>();

                    foreach (string rol in roles)
                    {
                        roles1.Add(new Roles { id = rol, rol = rol });
                    }

                    foreach (Vendedor vendedor in await UserVendedor(identity.UserName))
                    {
                        vendedores.Add(vendedor);
                    }
                    foreach (Deposito deposito in await UserDeposito(identity.UserName))
                    {
                        depositos.Add(deposito);
                    }
                    foreach (Caja caja in await UserCaja(identity.UserName))
                    {
                        cajas.Add(caja);
                    }
                    users.Add(new UserInfo
                    {
                        vendedores = vendedores,
                        depositos = depositos,
                        cajas = cajas,

                        username = identity.UserName,
                        id = identity.Id,
                        roles = roles1,
                        Cliente = identity.Cliente,
                        ClienteId = Convert.ToInt32(identity.ClienteId)
                        
                    }) ;

                }

            }
            catch (Exception ex)
            {

                throw;
            }
          
            

            return users;
        }
        [HttpGet("UserVendedor/{userName}")]
        public async Task<List<Vendedor>> UserVendedor(string userName)
        {
            List<Vendedor> vendedores = new List<Vendedor>();
            List<UserVendedor> userVendedores =   _context.userVendedor.Where(x => x.userName == userName && x.Vendedor.enabled).ToList();

            foreach (UserVendedor userVendedor in userVendedores) {
                vendedores.Add(_context.vendedor.Find(userVendedor.VendedorId));
            }
           

            return vendedores;
        }

        [HttpGet("UserDeposito/{userName}")]
        public async Task<List<Deposito>> UserDeposito(string userName)
        {
            List<Deposito> depositos = new List<Deposito>();
            List<UserDeposito> userDepositos = _context.userDeposito.Where(x => x.userName == userName && x.Deposito.enabled).ToList();

            foreach (UserDeposito userDeposito in userDepositos)
            {
                depositos.Add(_context.deposito.Find(userDeposito.DepositoId));
            }


            return depositos;
        }
        [HttpGet("UserCaja/{userName}")]
        public async Task<List<Caja>> UserCaja(string userName)
        {
            List<Caja> cajas = new List<Caja>();
            List<UserCaja> userCajas = _context.userCaja.Where(x => x.userName == userName && x.Caja.enabled).ToList();

            foreach (UserCaja userCaja in userCajas)
            {
                cajas.Add(_context.caja.Find(userCaja.CajaId));
            }


            return cajas;
        }
        [HttpPut("Editar/{id}")]
        public async Task<UserInfo> Editar(string id, [FromBody] UserInfo userInfo)
        {
            ApplicationUser identityUser = await _userManager.FindByIdAsync(id);
            identityUser.UserName = userInfo.username;
            List<string> rolesDelUsuario = await _userManager.GetRolesAsync(identityUser) as List<string>;
            try
            {
                List<UserVendedor> userVendedores = _context.userVendedor.Where(x => x.userName == userInfo.username).ToList();
                List<UserDeposito> userDepositos = _context.userDeposito.Where(x => x.userName == userInfo.username).ToList();
                List<UserCaja> userCajas = _context.userCaja.Where(x => x.userName == userInfo.username).ToList();

                _context.userVendedor.RemoveRange(userVendedores);
                foreach (Vendedor vendedor in userInfo.vendedores)
                {
                    _context.userVendedor.Add(new UserVendedor
                    {
                        Vendedor =  _context.vendedor.FirstOrDefault(x => x.Id == vendedor.Id),
                        userName = userInfo.username
                    });

                }
                _context.userDeposito.RemoveRange(userDepositos);
                foreach (Deposito deposito in userInfo.depositos)
                {
                    _context.userDeposito.Add(new UserDeposito
                    {
                        Deposito = _context.deposito.FirstOrDefault(x => x.Id == deposito.Id),
                        userName = userInfo.username
                    });

                }
                _context.userCaja.RemoveRange(userCajas);
                foreach (Caja caja in userInfo.cajas)
                {
                    _context.userCaja.Add(new UserCaja
                    {
                        Caja = _context.caja.FirstOrDefault(x => x.Id == caja.Id),
                        userName = userInfo.username
                    });

                }
                foreach (string rolAEliminar in rolesDelUsuario)
                {
                    await _userManager.RemoveFromRoleAsync(identityUser, rolAEliminar);
                }

                foreach (Roles rol in userInfo.roles)
                {

                    await _userManager.AddToRoleAsync(identityUser, rol.rol);
                }

                return userInfo;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        [HttpDelete("EliminarUsuario/{id}")]
        public async Task EliminarUsuario(string id)
        {
            int clienteId = 0;
            ApplicationUser identityUser = await _userManager.FindByIdAsync(id);
            if (identityUser.ClienteId != 0) {
                clienteId = Convert.ToInt32(identityUser.ClienteId);
            }
            await _userManager.DeleteAsync(identityUser);
            await EliminarCliente(clienteId);
        }

        public async Task EliminarCliente(int id) {
            if (id != 0) {
                Cliente cliente = _context.cliente.Find(id);
                _context.cliente.Remove(cliente);
               await _context.SaveChangesAsync();

            }
            
        }
    }
}