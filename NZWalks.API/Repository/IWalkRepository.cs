﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IWalkRepository
    {
       Task<Walk> CreateAsync(Walk walk);
       Task<List<Walk>> GetAllAsync(string? filterON = null, string? filterQuery = null);
        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk?> UpdateAsync(Guid id, Walk walk);

        Task<Walk?> DeleteAsync(Guid id);
    }
}
