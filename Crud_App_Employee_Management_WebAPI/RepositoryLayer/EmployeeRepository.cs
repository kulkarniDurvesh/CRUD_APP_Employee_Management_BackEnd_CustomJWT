﻿using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryLayer.DataAccess;

namespace RepositoryLayer
{
    public class EmployeeRepository
    {
        private readonly DbConnection _connection;
        public EmployeeRepository(DbConnection dbContext)
        {
            _connection = dbContext;
        }
        public async Task<List<EmployeeClass>> GetAllEmployees() {
            return await _connection.EmployeeClass.ToListAsync();
        }

        public async Task<List<EmployeeClass>> GetAllEmployeesByAge(int age) {
            return await _connection.EmployeeClass.Where(x => x.EmployeeAge > age).OrderByDescending(x => x.EmployeeId).ToListAsync();
        }

        public async Task<EmployeeDTO> AddEmployee(EmployeeClass employee)
        {
            if (employee == null) {
                throw new ArgumentNullException(nameof(employee), "Employee data is null");
            }

            //FindAsync only works when you pass the primary key of the entity. Ensure that EmployeeId is correctly marked as the primary key in your EmployeeClass.

            var employeePresent = _connection.EmployeeClass.Where(e => e.EmployeeId == employee.EmployeeId).ToList();

            if (employeePresent.Count() != 0)
            {
                // Throw a more specific exception
                throw new InvalidOperationException($"Employee with ID {employee.EmployeeId} already exists");
            }

            try
            {
                // Add the new employee
                _connection.EmployeeClass.Add(employee);
                _connection.SaveChanges();  // Ensure async call is awaited
            }
            catch (Exception ex)
            {
                // Handle exceptions like database issues and provide more context
                throw new Exception("Server error occurred while adding the employee", ex);
            }
            //return _connection.EmployeeClass.ToList();
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                EmployeeFirstName = employee.EmployeeFirstName,
                EmployeeLastName = employee.EmployeeLastName
            };
        }

        public async Task<EmployeeClass> UpdateEmployeeDetails(EmployeeClass employee) 
        {
            if(employee == null) { throw new ArgumentNullException("Employee Data is null"); }
            
            try
            {
                var employeePresent =  _connection.EmployeeClass.Where(e => e.EmployeeId == employee.EmployeeId).ToList();

                if (employeePresent.Count == 1)
                {
                    employeePresent[0].EmployeeFirstName = employee.EmployeeFirstName;
                    employeePresent[0].EmployeeUserName = employee.EmployeeUserName;
                    employeePresent[0].EmployeePhone = employee.EmployeePhone;
                    employeePresent[0].EmployeeLastName = employee.EmployeeLastName;
                    employeePresent[0].EmployeeAge = employee.EmployeeAge;
                    employeePresent[0].EmployeeCity = employee.EmployeeCity;
                    employeePresent[0].EmployeeCountry = employee.EmployeeCountry;
                    employeePresent[0].EmployeeDesignation = employee.EmployeeDesignation;
                    employeePresent[0].EmployeePassword = employee.EmployeePassword;
                    employeePresent[0].EmployeeState = employee.EmployeeState;
                    employeePresent[0].EmployeeZipCode = employee.EmployeeZipCode;
                    //await _connection.SaveChangesAsync();
                    return employeePresent[0];
                }
                else if (employeePresent.Count > 1) {
                    throw new Exception($"There are more than 1 record with employeeId {employee.EmployeeId}");
                }
                else
                {
                    throw new KeyNotFoundException($"Employee with ID {employee.EmployeeId} not found");

                }

            }
            catch (Exception ex)
            {
                 // Log the exception
                Console.WriteLine($"Error updating employee: {ex.Message}");
                throw; // Re-throw the exception for further handling
            }
        }
    }
}