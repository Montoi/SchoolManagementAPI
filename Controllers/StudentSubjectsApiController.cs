using AutoMapper;
using MagicVilla_VillaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Models.Dto;
using SchoolManagementAPI.Repository.IRepository;
using System.Net;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/StudentSubjects")]
    [ApiController]
    public class StudentSubjectsApiController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IStudentSubjectRepository _dbStudentSubject;
        private readonly IStudentRepository _dbStudent;
        private readonly IMapper _mapper;

        public StudentSubjectsApiController(IStudentSubjectRepository dbStudentSubject, IMapper mapper, IStudentRepository dbStudent)
        {
            _dbStudentSubject = dbStudentSubject;
            _mapper = mapper;
            this._response = new();
            _dbStudent = dbStudent;

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetStudentSubjects()
        {
            try
            {
                IEnumerable<Studentsubjects> studentsubjectsList = await _dbStudentSubject.GetAllAsync();
                _response.Result = _mapper.Map<List<StudentsubjectsDto>>(studentsubjectsList);
                _response.statusCode = HttpStatusCode.OK;
                _response.IsSucess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet("{id:int}", Name = "GetStudentSubject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetStudentSubject(int id)
        {
            try
            {
                if (id == 0)
                {
                    ModelState.AddModelError("CustomError", "El Id no puede ser 0");
                    return NotFound(ModelState);
                }
                var studentSubjects = await _dbStudentSubject.GetAsync(u => u.StudentId == id);
                if (studentSubjects == null)
                {
                    ModelState.AddModelError("CustomError", "Estudiante no encontrado");
                    return NotFound(ModelState);
                }
                _response.Result = _mapper.Map<StudentsubjectsDto>(studentSubjects);
                _response.statusCode = HttpStatusCode.OK;
                _response.IsSucess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateStudentSubject([FromBody] StudentsubjectsCreateDto createDTO)
        {
            try
            {
                if (await _dbStudentSubject.GetAsync(u => u.StudentId == createDTO.StudentId) != null)
                {
                    ModelState.AddModelError("CustomError", "Este estudiante ya se ha inscrito");
                    return BadRequest(ModelState);
                }
                if (await _dbStudent.GetAsync(u => u.StudentId == createDTO.StudentId) == null)
                {
                    ModelState.AddModelError("CustomError", "Estudiante no existe");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);

                }


                Studentsubjects studentSubjectsNumber = _mapper.Map<Studentsubjects>(createDTO);



                await _dbStudentSubject.CreateAsync(studentSubjectsNumber);
                _response.Result = _mapper.Map<StudentsubjectsDto>(studentSubjectsNumber);
                _response.statusCode = HttpStatusCode.Created;
                _response.IsSucess = true;
                return CreatedAtRoute("GetStudentSubject", new { id = studentSubjectsNumber.ID}, _response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteStudentSubject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var studentSubjects = await _dbStudentSubject.GetAsync(u => u.ID == id);
                if (studentSubjects == null)
                {
                    return NotFound();
                }

                await _dbStudentSubject.RemoveAsync(studentSubjects);

                _response.Result = _mapper.Map<StudentsubjectsDto>(studentSubjects);
                _response.statusCode = HttpStatusCode.NoContent;
                _response.IsSucess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        [HttpPut] 
        public async Task<ActionResult<APIResponse>> UpdateStudentSubject([FromBody] StudentsubjectsUpdateDto updateDTO)
        {
            try
            {


                if (await _dbStudent.GetAsync(u => u.StudentId == updateDTO.StudentId) == null)
                {
                    ModelState.AddModelError("CustomError", "Estudiante invalido");
                    return BadRequest(ModelState);
                }
                var studentSubjects = await _dbStudentSubject.GetAsync(u => u.StudentId == updateDTO.StudentId,tracked: false);

                Studentsubjects model = _mapper.Map<Studentsubjects>(updateDTO);
                model.ID = studentSubjects.ID;
                await _dbStudentSubject.UpdateAsync(model);
                _response.statusCode = HttpStatusCode.NoContent;
                _response.IsSucess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
