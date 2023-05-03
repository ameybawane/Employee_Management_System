import { BoolToTextPipe } from './bool-to-text.pipe';

describe('BoolToTextPipe', () => {
  it('create an instance', () => {
    const pipe = new BoolToTextPipe();
    expect(pipe).toBeTruthy();
  });

  it('should display Active if value is True', () => {
    let pipe = new BoolToTextPipe();
    expect(pipe.transform(1)).toEqual('Active');
  });

  it('should display InActive if value is False', () => {
    let pipe = new BoolToTextPipe();
    expect(pipe.transform(0)).toEqual('InActive');
  });

});
