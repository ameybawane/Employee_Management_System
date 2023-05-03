import { SearchEmployeePipe } from './search-employee.pipe';

describe('SearchEmployeePipe', () => {
  it('create an instance', () => {
    const pipe = new SearchEmployeePipe();
    expect(pipe).toBeTruthy();
  });

  // it('should filter employee name in lowercase if value is uppercase', () => {
  //   const pipe = new SearchEmployeePipe();
  //   expect(pipe).toBeTruthy();
  // });
});
