﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
           var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);


            await walkRepository.CreateAsync(walkDomainModel);

            // Map domainModel to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
          var walksDomainModel =  await walkRepository.GetAllAsync();

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));

        }

    }
}
