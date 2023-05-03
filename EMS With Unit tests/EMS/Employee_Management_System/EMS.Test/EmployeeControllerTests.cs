using AutoFixture;
using EMS.Business.Abstraction;
using EMS.Business.Entities.Entity;
using EMS.Business.Entities.Models;
using EMS.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingTestProject.Utilities;
using System.Net;

namespace EMS.Test
{
    public class EmployeeControllerTests : ApiUnitTestBase<EmployeeController>
    {
        private Mock<IEmployeeRepository> mockEmployeeRepository;
        public override void TestSetup()
        {
            mockEmployeeRepository = this.CreateAndInjectMock<IEmployeeRepository>();
            Target = new EmployeeController(mockEmployeeRepository.Object);
        }

        public override void TestTearDown()
        {
            mockEmployeeRepository.VerifyAll();
        }
        
        [Fact]
        public async Task GetEmployees_returnValueFound()
        {
            // Arrange
            var employees = Fixture.CreateMany<Employee>();
            this.mockEmployeeRepository.Setup(c => c.GetAll()).ReturnsAsync(employees);

            // Act
            var actionResult = Target.GetEmployees();

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as OkObjectResult;
            Assert.NotNull(actual);
            Assert.Equal(employees, actual.Value);
            this.mockEmployeeRepository.Verify(c => c.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetEmployees_returnValueNotFound()
        {
            // Arrange
            IEnumerable<Employee> employees = null;
            this.mockEmployeeRepository.Setup(c => c.GetAll()).ReturnsAsync(employees);

            // Act
            var actionResult = Target.GetEmployees();

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as OkObjectResult;
            Assert.Null(actual.Value);
            Assert.Equal(employees, actual.Value);
            this.mockEmployeeRepository.Verify(c => c.GetAll(), Times.Once);
        }

        [Fact]
        public async Task EmployeeById_returnValueFound()
        {
            // Arrange
            int id = Fixture.Create<int>();
            var employee = Fixture.Create<Employee>();
            employee.Id = id;
            this.mockEmployeeRepository.Setup(c => c.GetById(id)).ReturnsAsync(employee);

            // Act
            var actionResult = Target.EmployeeById(id);

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as OkObjectResult;
            Assert.NotNull(actual);
            Assert.Equal(employee, actual.Value);
            Assert.Equal((int)HttpStatusCode.OK, actual.StatusCode);
            this.mockEmployeeRepository.Verify(c => c.GetById(id), Times.Once);
        }

        [Fact]
        public async Task EmployeeById_returnValueNotFound()
        {
            // Arrange
            int id = Fixture.Create<int>();
            Employee employee = null;
            this.mockEmployeeRepository.Setup(c => c.GetById(id)).ReturnsAsync(employee);

            // Act
            var actionResult = Target.EmployeeById(id);

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as NotFoundResult;
            Assert.Equal((int)HttpStatusCode.NotFound, actual.StatusCode);
            this.mockEmployeeRepository.Verify(c => c.GetById(id), Times.Once);
        }

        [Fact]
        public async Task Post_returnCreatedAtRoute()
        {
            // Arrange
            AddEmployee addEmployee = Fixture.Create<AddEmployee>();
            this.mockEmployeeRepository.Setup(c => c.Add(addEmployee)).Returns(Task.CompletedTask);

            // Act
            var actionResult = Target.post(addEmployee);

            // Assert.
            var actual = await actionResult.ConfigureAwait(false) as CreatedAtRouteResult;
            Assert.Equal(addEmployee, actual.Value);
            Assert.Equal((int)HttpStatusCode.Created, actual.StatusCode);
            this.mockEmployeeRepository.Verify(c => c.Add(addEmployee), Times.Once);
        }

        [Fact]
        public async Task Post_returnBadRequest()
        {
            // Arrange
            AddEmployee addEmployee = null;

            // Act
            var actionResult = Target.post(addEmployee);

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as BadRequestResult;
            Assert.Equal((int)HttpStatusCode.BadRequest, actual.StatusCode);
            this.mockEmployeeRepository.Verify(c => c.Add(addEmployee), Times.Never);
        }

        [Fact]
        public async Task Put_returnNoContent()
        {

            // Arrange
            int id = Fixture.Create<int>();
            var employee = Fixture.Create<AddEmployee>();
            employee.Id = id;
            this.mockEmployeeRepository.Setup(c => c.UpdateData(id, employee)).Returns(Task.CompletedTask);

            // Act
            var actionResult = Target.put(id, employee);

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as StatusCodeResult;
            Assert.NotNull(actual);
            Assert.Equal((int)HttpStatusCode.NoContent, actual.StatusCode);
            mockEmployeeRepository.Verify(c => c.UpdateData(id, employee), Times.Once);
        }

        [Fact]
        public async Task Put_returnBadRequest()
        {
            // Arrange
            var id = Fixture.Create<int>();
            var product = Fixture.Create<AddEmployee>();

            // Act
            var actionResult = Target.put(id, product);

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as BadRequestResult;
            Assert.NotNull(actual);
            Assert.Equal((int)HttpStatusCode.BadRequest, actual.StatusCode);
        }
    }
}