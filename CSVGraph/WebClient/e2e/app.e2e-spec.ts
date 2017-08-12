import { CSVGraphPage } from './app.po';

describe('csvgraph App', () => {
  let page: CSVGraphPage;

  beforeEach(() => {
    page = new CSVGraphPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
