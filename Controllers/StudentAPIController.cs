using AutoMapper;
using MagicVilla_VillaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Models.Dto;
using SchoolManagementAPI.Repository.IRepository;
using System.Net;

namespace SchoolManagementAPI.Controllers
{
     [Route("api/StudentAPI")]
     [ApiController]   
    public class StudentAPIController : ControllerBase
    {
            protected APIResponse _response;
            private readonly IStudentRepository _dbStudent;
            private readonly IMapper _mapper;

            public StudentAPIController(IStudentRepository dbStudent, IMapper mapper)
            {
                _dbStudent = dbStudent;
                _mapper = mapper;
                this._response = new();

            }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<APIResponse>> GetStudent()
            {
                try
                {


                    IEnumerable<Student> StudentList = await _dbStudent.GetAllAsync();
                    _response.Result = _mapper.Map<List<StudentDto>>(StudentList);
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



        [HttpGet("{id:int}", Name = "GetStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetStudent(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                var student = await _dbStudent.GetAsync(u => u.StudentId == id);
                if (student == null)
                {
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<StudentDto>(student);
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
        public async Task<ActionResult<APIResponse>> CreateStudent([FromBody] StudentCreateDto createDTO)
        {
            try
            {

                //if (await _dbStudent.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Estudiante ya existe");
                //    return BadRequest(ModelState);
                //}
                if (createDTO == null)
                {
                    return BadRequest(createDTO);

                }


                Student student = _mapper.Map<Student>(createDTO);
                await _dbStudent.CreateAsync(student);
                _response.Result = _mapper.Map<StudentDto>(student);
                _response.statusCode = HttpStatusCode.Created;
                _response.IsSucess = true;
                return CreatedAtRoute("GetStudent", new { id = student.StudentId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteStudent(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var student = await _dbStudent.GetAsync(u => u.StudentId == id);
                if (student == null)
                {
                    return NotFound();
                }

                await _dbStudent.RemoveAsync(student);

                _response.Result = _mapper.Map<StudentDto>(student);
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

        [HttpPut("{id:int}", Name = "UpdateStudent")]
        public async Task<ActionResult<APIResponse>> UpdateStudent(int id, [FromBody] StudentUpdateDto updateDTO)
        {
            try
            {


                if (updateDTO == null || id != updateDTO.StudentId)
                {
                    return BadRequest();
                }

                Student model = _mapper.Map<Student>(updateDTO);
                

                await _dbStudent.UpdateAsync(model);
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
