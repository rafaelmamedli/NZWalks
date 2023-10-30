using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public IRegionRepository regionRepository;
        public IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext,IRegionRepository  regionRepository,    IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        [HttpGet]   
        public async Task<IActionResult> GetAll()  
        {
            // Get Data with Domain Modes
            var regionsDomain =await regionRepository.GetAllAsync();

            
          var regionsDto =  mapper.Map<List<RegionDto>>(regionsDomain);
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {

            var regionDomain = await regionRepository.GetByIdAsync(id);
 
            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionsDto = mapper.Map<RegionDto>(regionDomain);    

            return Ok(regionDomain);  

        }


        //POST to Create New Region
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

          

                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                // Use Domain Model to create Region
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                var regionDTO = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
            
            
        }

        //Update Region
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]UpdateRegionRequestDtocs updateRegionRequestDtocs)
        {
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDtocs);

            //Check if region exist
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null) 
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

      
        
        [HttpDelete]
        [Route("{id:Guid}")]
        public async  Task<IActionResult> Delete([FromRoute] Guid id) 
        {

            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

   
            var regionDTO = mapper.Map<RegionDto> (regionDomainModel);

            return Ok(regionDTO);

        }

    }
}
