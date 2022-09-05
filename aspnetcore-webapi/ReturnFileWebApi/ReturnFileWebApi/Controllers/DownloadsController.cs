﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReturnFileWebApi.Interface;

namespace ReturnFileWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadsController : ControllerBase
    {
        private readonly IFileService _fileService;
        private const string _mimeType = "image/png";
        private const string _fileName = "CM-Logo.png";

        public DownloadsController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("images-byte")]
        public IActionResult ReturnByteArray()
        {
            var image = _fileService.GetImageAsByteArray();

            return File(image, _mimeType, _fileName);
        }

        [HttpGet("images-stream")]
        public IActionResult ReturnStream()
        {
            var image = _fileService.GetImageAsStream();

            return File(image, _mimeType, _fileName);
        }
    }
}
