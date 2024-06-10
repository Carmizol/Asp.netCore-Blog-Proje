﻿using jwt_project.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_project.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : Controller
	{
		[HttpGet("[action]")]
		
			public IActionResult Login()
			{
				return Created("",new BuildToken().CreateToken());

			}
		[Authorize]
		[HttpGet("[action]")]
		public IActionResult Page1()
		{
			return Ok("Sayfa 1 için Giriş Başarılı");

		}

	}
}
