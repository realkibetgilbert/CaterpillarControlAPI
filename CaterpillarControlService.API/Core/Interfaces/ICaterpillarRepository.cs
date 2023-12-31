﻿using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Dtos.Caterpillar;
using System.Drawing;
namespace CaterpillarControlService.API.Core.Interfaces
{
    public interface ICaterpillarRepository
    {
        Task<Caterpillar?> Add(Caterpillar caterpillar);
        Task<Caterpillar?> GetCaterpillar(long id);

        Task<List<Caterpillar>> GetCaterpillars();
        Task<Caterpillar?> UpdateCaterpillar(long id,Caterpillar caterpillar);
        bool IsCrossingBoundary(Caterpillar caterpillar, CaterpillarMovementDto movementDto, Planet planet);
        Bitmap GenerateRadarImage(Caterpillar caterpillar);
    }
}
