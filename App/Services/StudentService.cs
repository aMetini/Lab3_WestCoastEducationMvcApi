using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using App.Interfaces;
using App.Models;
using App.ViewModels;
using Microsoft.Extensions.Configuration;

namespace App.Services
{
  public class StudentService : IStudentService
  {
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _options;
    private readonly HttpClient _http;

    public StudentService(IConfiguration config, HttpClient http)
    {
      _http = http;
      _baseUrl = config.GetSection("api:baseUrl").Value + "/students";

      _options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };
    }

    public async Task<bool> AddStudent(StudentModel model)
    {
      try
      {
        var url = _baseUrl;
        var data = JsonSerializer.Serialize(model);

        var response = await _http.PostAsync(url, new StringContent(data, Encoding.Default, "application/json"));

        if (response.IsSuccessStatusCode)
        {
          return true;
        }
        else
        {
          var error = await response.Content.ReadAsStringAsync();
          throw new Exception(error);
        }
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<bool> DeleteStudent(string studentEmail)
    {
      try
      {
        var url = $"{_baseUrl}/{studentEmail}";
        var response = await _http.DeleteAsync(url);

        if (response.IsSuccessStatusCode)
        {
          return true;
        }
        else
        {
          var error = await response.Content.ReadAsStringAsync();
          throw new Exception(error);
        }
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task<StudentModel> GetStudentAsync(int id)
    {
      var response = await _http.GetAsync($"{_baseUrl}/{id}");

      if (response.IsSuccessStatusCode)
      {
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<StudentModel>(data, _options);
        return result;
      }
      else
      {
        throw new Exception("Unable to process your request!");
      }
    }

    public async Task<StudentModel> GetStudentAsync(string studentEmail)
    {
      var response = await _http.GetAsync($"{_baseUrl}/find/{studentEmail}");

      if (response.IsSuccessStatusCode)
      {
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<StudentModel>(data, _options);
        return result;
      }
      else
      {
        throw new Exception("Unable to process your request!");
      }
    }

    public async Task<List<StudentModel>> GetStudentsAsync()
    {
      var response = await _http.GetAsync($"{_baseUrl}");

      if (response.IsSuccessStatusCode)
      {
        var data = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<StudentModel>>(data, _options);
        return result;
      }
      else
      {
        throw new Exception("Unable to process your request!");
      }
    }

    public async Task<bool> UpdateStudent(int id, UpdateStudentViewModel model)
    {
      try
      {
        var url = $"{_baseUrl}/{id}";
        var data = JsonSerializer.Serialize(model);
        var response = await _http.PutAsync(url, new StringContent(data, Encoding.Default, "application/json"));

        if (response.IsSuccessStatusCode)
        {
          return true;
        }
        else
        {
          var error = await response.Content.ReadAsStringAsync();
          throw new Exception(error);
        }
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }
  }
}