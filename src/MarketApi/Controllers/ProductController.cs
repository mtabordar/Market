﻿namespace MercadoApi.Controllers
{
    using AutoMapper;
    using MarketApi.Models;
    using MarketApi.Models.Interfaces;
    using MarketApi.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        private ILogger<ProductController> _logger;

        public ProductController(IProductRepository productRepository, IMapper mapper, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAll()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }

        }

        // GET api/product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_mapper.Map<ProductViewModel>(_productRepository.Find(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/product
        [HttpPost]
        public IActionResult Post([FromBody]ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(_mapper.Map<Product>(product));
                return Created("", product);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productRepository.Update(_mapper.Map<Product>(product));
                    return Created("", product);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productRepository.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
