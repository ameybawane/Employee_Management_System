using AutoFixture;
using EMS.Business.Abstraction;
using EMS.Business.Entities.Models;
using EMS.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingTestProject.Utilities;
using System.Net;

namespace EMS.Test
{
    public class DepartmentsControllerTests : ApiUnitTestBase<DepartmentsController>
    {
        private Mock<IDepartmentsRepository> mockDepartmentsRepository;
        public override void TestSetup()
        {
            mockDepartmentsRepository = this.CreateAndInjectMock<IDepartmentsRepository>();
            Target = new DepartmentsController(mockDepartmentsRepository.Object);
        }

        public override void TestTearDown()
        {
            mockDepartmentsRepository.VerifyAll();
        }

        [Fact]
        public async Task AllDepartments_returnValueFound()
        {
            // Arrange
            var departments = Fixture.CreateMany<Departments>();
            this.mockDepartmentsRepository.Setup(c => c.GetAllDepartments()).ReturnsAsync(departments);

            // Act
            var actionResult = Target.AllDepartments();

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as OkObjectResult;
            Assert.NotNull(actual);
            Assert.Equal(departments, actual.Value);
            this.mockDepartmentsRepository.Verify(c => c.GetAllDepartments(), Times.Once);
        }

        [Fact]
        public async Task AllDepartments_returnValueNotFound()
        {
            // Arrange
            IEnumerable<Departments> departments = null;
            this.mockDepartmentsRepository.Setup(c => c.GetAllDepartments()).ReturnsAsync(departments);

            // Act
            var actionResult = Target.AllDepartments();

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as OkObjectResult;
            Assert.Null(actual.Value);
            Assert.Equal(departments, actual.Value);
            this.mockDepartmentsRepository.Verify(c => c.GetAllDepartments(), Times.Once);
        }

        [Fact]
        public async Task DepartmentById_returnOk()
        {
            // Arrange
            int id = Fixture.Create<int>();
            var departments = Fixture.Create<Departments>();
            departments.Id = id;
            this.mockDepartmentsRepository.Setup(c => c.GetDepartmentById(id)).ReturnsAsync(departments);

            // Act
            var actionResult = Target.DepartmentById(id);

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as OkObjectResult;
            Assert.NotNull(actual);
            Assert.Equal(departments, actual.Value);
            Assert.Equal((int)HttpStatusCode.OK, actual.StatusCode);
            this.mockDepartmentsRepository.Verify(c => c.GetDepartmentById(id), Times.Once);
        }

        [Fact]
        public async Task DepartmentById_returnNotFound()
        {
            // Arrange
            int id = Fixture.Create<int>();
            Departments departments = null;
            this.mockDepartmentsRepository.Setup(c => c.GetDepartmentById(id)).ReturnsAsync(departments);

            // Act
            var actionResult = Target.DepartmentById(id);

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as NotFoundResult;
            Assert.Equal((int)HttpStatusCode.NotFound, actual.StatusCode);
            this.mockDepartmentsRepository.Verify(c => c.GetDepartmentById(id), Times.Once);
        }

        [Fact]
        public async Task EmployeeByDepartmentId_returnOk()
        {
            // Arrange
            int id = Fixture.Create<int>();
            var employee = Fixture.CreateMany<Employee>();
            this.mockDepartmentsRepository.Setup(c => c.GetEmployeeByDepartmentId(id)).ReturnsAsync(employee);

            // Act
            var actionResult = Target.EmployeeByDepartmentId(id);

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as OkObjectResult;
            Assert.NotNull(actual);
            Assert.Equal(employee, actual.Value);
            Assert.Equal((int)HttpStatusCode.OK, actual.StatusCode);
            this.mockDepartmentsRepository.Verify(c => c.GetEmployeeByDepartmentId(id), Times.Once);
        }

        [Fact]
        public async Task EmployeeByDepartmentId_returnNotFound()
        {
            // Arrange
            int id = Fixture.Create<int>();
            IEnumerable<Employee> employee = null;
            this.mockDepartmentsRepository.Setup(c => c.GetEmployeeByDepartmentId(id)).ReturnsAsync(employee);

            // Act
            var actionResult = Target.EmployeeByDepartmentId(id);

            // Assert
            var actual = await actionResult.ConfigureAwait(false) as NotFoundResult;
            Assert.Equal((int)HttpStatusCode.NotFound, actual.StatusCode);
            this.mockDepartmentsRepository.Verify(c => c.GetEmployeeByDepartmentId(id), Times.Once);
        }

        [Fact]
        public async Task DeleteDepartment_returnNoContent()
        {
            // Arrange
            var id = Fixture.Create<int>();
            var department = Fixture.Create<Departments>();
            department.Id = id;
            department.IsActive = false;
            this.mockDepartmentsRepository.Setup(c => c.DelDepartment(id)).Returns(department);

            // Act
            var actual = Target.DeleteDepartment(id) as StatusCodeResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.NoContent, actual.StatusCode);
            mockDepartmentsRepository.Verify(c => c.DelDepartment(id), Times.Once);
        }

        [Fact]
        public async Task DeleteDepartment_returnNotFound()
        {
            // Arrange
            int id = Fixture.Create<int>();
            Departments departments = null;
            this.mockDepartmentsRepository.Setup(c => c.DelDepartment(id)).Returns(departments);

            // Act
            var actionResult = Target.DeleteDepartment(id) as StatusCodeResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, actionResult.StatusCode);
            this.mockDepartmentsRepository.Verify(c => c.DelDepartment(id), Times.Once);
        }
    }
}
