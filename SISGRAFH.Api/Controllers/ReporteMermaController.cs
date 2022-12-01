using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Reporte_Merma;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Infraestructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteMermaController:ControllerBase
    {
        private static IReporteMermaService _reporteMermaService;
        private static IMapper _mapper;
        public ReporteMermaController(IReporteMermaService reporteMermaService, IMapper mapper)
        {
            _reporteMermaService = reporteMermaService;
            _mapper = mapper;
        }
        [HttpGet("GetReportesMerma")]
        public async Task<IActionResult> GetReporteMerma()
        {
            var reporteMermas = await _reporteMermaService.GetReporteMerma();
            var response = new ApiResponse<IEnumerable<beReporteMerma>>(reporteMermas);
            return Ok(response);
        }

        [HttpPost("PostReportesMerma")]
        public async Task<IActionResult> PostReportesMerma(beReporteMerma reporteMerma)
        {
            var reporteMermaPosteado = await _reporteMermaService.PostReporteMerma(reporteMerma);
            return Ok(reporteMermaPosteado);
        }

        [HttpGet("GetReportesMermaById")]
        public async Task<IActionResult> GetReportesMermaById(string id)
        {
            var reportMermaId = await _reporteMermaService.GetReporteMermaById(id);
            var response = new ApiResponse<object>(reportMermaId);
            return Ok(response);
        }

        [HttpPut("UpdateReportesMerma")]
        public async Task<IActionResult> UpdateReportesMerma(ReporteMermaDto reporteMermaDto)
        {
            var reportemerma = _mapper.Map<beReporteMerma>(reporteMermaDto);
            var reporteMermaPosted = await _reporteMermaService.UpdateReporteMerma(reportemerma);

            reporteMermaDto = _mapper.Map<ReporteMermaDto>(reporteMermaPosted);
            var response = new ApiResponse<ReporteMermaDto>(reporteMermaDto);
            return Ok(response);
        }
    }
}
