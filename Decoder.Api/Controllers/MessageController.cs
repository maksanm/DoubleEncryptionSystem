﻿using Decoder.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Decoder.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IDecryptorService _decryptorService;

        public MessageController(IDecryptorService decryptorService)
        {
            _decryptorService = decryptorService;
        }

        [HttpGet("{key}")]
        public ActionResult<string> DecryptMessage([FromRoute] string key)
        {
            key = Uri.UnescapeDataString(key);
            var message = _decryptorService.Decrypt(key);
            return StatusCode(418, message);
        }
    }
}
