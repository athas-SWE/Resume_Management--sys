﻿using AutoMapper;
using Backend_Management.Core.Dtos.Candidate;
using Backend_Management.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Backend_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        // Firt => Save pdf to Server
        // Then => save url into our entity
        var fiveMegaByte = 5 * 1024 * 1024;
        var pdfMimeType = "application/pdf";

            if (pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
            {
                return BadRequest("File is not valid");
    }

    var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", resumeUrl);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
}
var newCandidate = _mapper.Map<Candidate>(dto);
newCandidate.ResumeUrl = resumeUrl;
await _context.Candidates.AddAsync(newCandidate);
await _context.SaveChangesAsync();

return Ok("Candidate Saved Successfully");
        }

        // Read
        [HttpGet]
[Route("Get")]
public async Task<ActionResult<IEnumerable<CandidateGetDto>>> GetCandidates()
{
    var candidates = await _context.Candidates.Include(c => c.Job).OrderByDescending(q => q.CreatedAt).ToListAsync();
    var convertedCandidates = _mapper.Map<IEnumerable<CandidateGetDto>>(candidates);

    return Ok(convertedCandidates);
}

// Read (Download Pdf File)
[HttpGet]
[Route("download/{url}")]
public IActionResult DownloadPdfFile(string url)
{
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", url);

    if (!System.IO.File.Exists(filePath))
    {
        return NotFound("File Not Found");
    }

    var pdfBytes = System.IO.File.ReadAllBytes(filePath);
    var file = File(pdfBytes, "application/pdf", url);
    return file;
}

        // Read (Get Candidate By ID)

        // Update 

        // Delete
    }
}
