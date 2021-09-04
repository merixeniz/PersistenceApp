﻿using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.DataAccess
{
    public interface IBoardsRepository : ICustomRepository
    {
        Task<List<GetBoardsDto>> GetBoardsAsync(CancellationToken token);
        Task<List<GetBoardsDto>> GetBoardsByNameAsync(string boardName, CancellationToken token);
    }
}
